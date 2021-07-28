using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using ITVitaeSVS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITVitaeSVS.UI.Web.Areas.Topics.Pages
{
    [Authorize(Policy = Permissions.ManageContent)]
    public class CreateEditModel : PageModel
    {
        private readonly ITopicService topics;
        private readonly ILevelService levels;
        private readonly IWorkMethodService workMethods;
        private readonly ICertificateService certificates;

        [BindProperty]
        public Topic Topic { get; set; }
        public IEnumerable<SelectListItem> Levels { get; set; }
        public IEnumerable<SelectListItem> WorkMethods { get; set; }
        public IEnumerable<SelectListItem> Certificates { get; set; }
        public CreateEditModel(ITopicService topics,
            ILevelService levels,
            IWorkMethodService workMethods,
            ICertificateService certificates) {
            this.topics = topics;
            this.levels = levels;
            this.workMethods = workMethods;
            this.certificates = certificates;
        }
        public void OnGet(int? id) {
            if (id != null) {
                Topic = topics.GetById(id.Value);
            } else
                Topic = new();

            Levels = levels.GetAll().Select(l => new SelectListItem(l.Name, l.Id.ToString()));
            WorkMethods = workMethods.GetAll().Select(wm => new SelectListItem(wm.Name, wm.Id.ToString()));
            Certificates = certificates.GetAll().Select(cert => new SelectListItem(cert.Name, cert.Id.ToString()));
        }

        public IActionResult OnPost(int? id) {
            if (id == null) {
                topics.Add(Topic);
            } else {
                topics.Update(Topic);
            }
            return RedirectToPage("Details", new { Topic.Id });
        }
    }
}
