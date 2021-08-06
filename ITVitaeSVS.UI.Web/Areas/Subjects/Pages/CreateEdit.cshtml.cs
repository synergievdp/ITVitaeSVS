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

namespace ITVitaeSVS.UI.Web.Areas.Subjects.Pages
{
    [Authorize(Policy = Permissions.ManageContent)]
    public class CreateEditModel : PageModel
    {
        private readonly ISubjectService subjects;
        private readonly ITopicService topics;

        [BindProperty]
        public Subject Subject { get; set; }
        public IEnumerable<Topic> Topics { get; set; }
        public CreateEditModel(ISubjectService subjects, ITopicService topics)
        {
            this.subjects = subjects;
            this.topics = topics;
        }
        public void OnGet(int? id)
        {
            if (id == null)
                Subject = new();
            else
            {
                Subject = subjects.GetById(id.Value);
            }

            Topics = topics.GetAll();
        }

        public IActionResult OnPost(int? id, IEnumerable<int> topicIds)
        {
            if (id == null)
                subjects.Add(Subject);
            else
                subjects.Update(Subject);

            subjects.SetTopics(Subject.Id, topicIds);

            return RedirectToPage("Index");
        }
    }
}
