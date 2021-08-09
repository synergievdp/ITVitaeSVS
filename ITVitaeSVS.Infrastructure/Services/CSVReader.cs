using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Services {
    public class CSVReader : ICSVReader {
        private const char LF = '\n';
        private readonly char[] TrimChars = {' ', '*', '"', '-', '•'};
        private readonly ITopicService topics;
        private readonly IWorkMethodService workMethods;
        private readonly ILevelService levels;
        private readonly ITagService tags;
        private readonly ICertificateService certificates;

        public CSVReader(ITopicService topics,
            IWorkMethodService workMethods,
            ILevelService levels,
            ITagService tags,
            ICertificateService certificates) {
            this.topics = topics;
            this.workMethods = workMethods;
            this.levels = levels;
            this.tags = tags;
            this.certificates = certificates;
        }
        public void ReadTopicCSV(Stream file, char seperator) {
            using (var sr = new StreamReader(file)) {

                var headers = sr.ReadLine().Split(seperator)
                    .Select(header => header.Trim(TrimChars))
                    .ToList();

                string line;
                while ((line = sr.ReadLine()) != null) {
                    var cells = line.Split(seperator)
                        .Select(cell => cell.Trim(TrimChars))
                        .ToList();

                    while (cells.Count < headers.Count) {
                        var nextLine = sr.ReadLine();
                        var nextCells = nextLine.Split(seperator)
                            .Select(cell => cell.Trim(TrimChars))
                            .ToList();

                        cells[^1] = cells[^1] + nextCells[0];
                        cells.AddRange(nextCells.Skip(1));
                    }

                    var code = cells[1];
                    Topic topic = topics.GetByNameCode(code) ?? new() { Code = code };
                    for (int i = 2; i < headers.Count; i++) {
                        switch (headers[i]) {
                            case "Niveau":
                                topic.Level = levels.GetByName(cells[i]);
                                break;
                            case "Topic":
                                topic.Name = cells[i];
                                break;
                            case "Duur":
                                int duration = cells[i].Count() >= 1 ? int.Parse(cells[i][0]+"") * 3 : 0;
                                topic.Duration = new TimeSpan(duration, 0, 0);
                                break;
                            case "Werkvorm(en)":
                                topic.WorkMethod = workMethods.GetByName(cells[i]);
                                break;
                            case "Leerdoel(en)":
                                topic.Objective = cells[i];
                                break;
                            case "Certificering":
                                topic.Certificate = certificates.GetByName(cells[i]);
                                break;
                            case "Benodigde voorkennis":
                                topic.AddPrerequisite(topics.GetByNameCode(cells[i]));
                                break;
                            case "Percipio links":
                                topic.AddLink(new Link() { Name = cells[i] });
                                break;
                            case "Tags 1":
                                topic.AddTag(tags.GetByName(cells[i]));
                                break;
                            case "Tags 2":
                                topic.AddTag(tags.GetByName(cells[i]));
                                break;
                            case "Tags 3":
                                topic.AddTag(tags.GetByName(cells[i]));
                                break;
                            default:
                                break;
                        }
                    }
                    if (topic.Id == 0) topics.Add(topic);
                    else topics.Update(topic);
                }
            }

        }

        public void ReadDropDownCSV(Stream file, char seperator) {
            List<string> headers = new(), cells = new();
            using (var sr = new StreamReader(file)) {

                headers = sr.ReadLine().Split(seperator)
                    .Select(header => header.Trim(TrimChars))
                    .ToList();

                string line;
                while ((line = sr.ReadLine()) != null) {
                    cells = line.Split(seperator)
                        .Select(cell => cell.Trim(TrimChars))
                        .ToList();

                    for (int i = 0; i < cells.Count; i++) {
                        if (String.IsNullOrWhiteSpace(cells[i]))
                            continue;
                        switch (headers[i]) {
                            case "Werkvormen":
                                if(workMethods.GetByName(cells[i]) is null)
                                    workMethods.Add(new WorkMethod() { Name = cells[i] });
                                break;
                            case "Niveau":
                                if(levels.GetByName(cells[i]) is null)
                                    levels.Add(new Level() { Name = cells[i] });
                                break;
                            case "Tags":
                                if(tags.GetByName(cells[i]) is null)
                                    tags.Add(new Tag() { Name = cells[i] });
                                break;
                            case "Certificeringen Infra":
                                if(certificates.GetByName(cells[i]) is null)
                                    certificates.Add(new Certificate() { Name = cells[i] });
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            
        }
    }
}
