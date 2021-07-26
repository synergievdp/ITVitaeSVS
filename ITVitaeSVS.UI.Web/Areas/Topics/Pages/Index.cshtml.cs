using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using ITVitaeSVS.Infrastructure.Identity.Models;
using ITVitaeSVS.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Topics.Pages
{
    [Authorize(Policy = Permissions.ManageContent)]
    public class IndexModel : PageModel
    {
        private readonly ITopicService topics;
        private readonly ICSVReader csvReader;

        public IEnumerable<Topic> Topics { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 15;
        public IndexModel(ITopicService topics,
            ICSVReader csvReader) {
            this.topics = topics;
            this.csvReader = csvReader;
        }
        public void OnGet()
        {
            Topics = topics.GetAll((CurrentPage - 1) * PageSize, PageSize);
            Count = topics.Count();
        }

        public IActionResult OnPostCSV(IFormFile file) {
            using (var stream = file.OpenReadStream()) {
                if (file.FileName.Contains("Topic")) {
                    csvReader.ReadTopicCSV(stream, '$');
                    TempData["OnPostCSV"] = new string[] { AlertType.Info, "Submitted Topics file." };
                } else if (file.FileName.Contains("Dropdown")) {
                    csvReader.ReadDropDownCSV(stream, '$');
                    TempData["OnPostCSV"] = new string[] { AlertType.Info, "Submitted Dropdown file." };
                } else
                {
                    TempData["OnPostCSV"] = new string[] { AlertType.Warning, "Did not read file." };
                }
            }
            return RedirectToPage("Index");
        }
    }
}
