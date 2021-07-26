using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using ITVitaeSVS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Students.Pages.Curricula
{
    [Authorize(Policy = Permissions.ManageStudents)]
    public class EditModel : PageModel
    {
        private readonly IStudentService students;
        private readonly ITopicService topics;
        public IEnumerable<Topic> Topics;
        public Student Student { get; set; }

        public EditModel(IStudentService students,
            ITopicService topics) {
            this.students = students;
            this.topics = topics;
        }
        public void OnGet(int id)
        {
            Student = students.GetById(id);
            Topics = topics.GetAll();

        }

        public IActionResult OnPost(int id, IEnumerable<int> topicIds) {
            students.SetTopics(id, topicIds);

            return RedirectToPage("/Details", new { id });
        }
    }
}
