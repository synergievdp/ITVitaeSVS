using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Topics.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITopicService topics;
        private readonly ICSVReader csvReader;

        public IEnumerable<Topic> Topics { get; set; }
        public IndexModel(ITopicService topics,
            ICSVReader csvReader) {
            this.topics = topics;
            this.csvReader = csvReader;
        }
        public void OnGet()
        {
            Topics = topics.GetAll();
        }

        public IActionResult OnPostCSV(IFormFile file) {
            using (var stream = file.OpenReadStream()) {
                if (file.FileName.Contains("Topic")) {
                    csvReader.ReadTopicCSV(stream, '$');
                } else if (file.FileName.Contains("Dropdown")) {
                    csvReader.ReadDropDownCSV(stream, '$');
                }
            }
            return RedirectToPage("Index");
        }
    }
}
