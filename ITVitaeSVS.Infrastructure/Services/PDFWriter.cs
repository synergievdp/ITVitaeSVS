using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Services
{
    public class PDFWriter : IPDFWriter
    {
        private Document document;
        public void CreateDocument(string path, string logoPath, Student student)
        {
            document = new Document();

            CreatePage(logoPath, student);

            var pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.Save(path);
        }

        private void CreatePage(string logoPath, Student student)
        {
            var section = document.AddSection();
            var image = section.AddImage(logoPath);
            image.Height = "1.5cm";
            image.WrapFormat.Style = WrapStyle.TopBottom;

            var name = section.AddParagraph(student.Name);
            var headers = new string[]{ "Topic", "Objective", "Certificate", "Progress" };

            var table = section.AddTable();
            foreach (var header in headers)
            {
                table.AddColumn();
            }

            var headerRow = table.AddRow();
            headerRow.HeadingFormat = true;
            for(int i = 0; i < headers.Length; i++)
            {
                headerRow.Cells[i].AddParagraph(headers[i]);
            }

            Row row;
            foreach(var topic in student.GetTopics())
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph(topic.Name);
                row.Cells[1].AddParagraph(topic.Objective ?? String.Empty);
                row.Cells[2].AddParagraph(topic.Certificate?.Name ?? String.Empty);
                row.Cells[3].AddParagraph(student.GetProgress(topic)?.ToString());
            }

        }
    }
}
