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
        private readonly ISubjectService subjects;
        public IEnumerable<Subject> Subjects;
        public Student Student { get; set; }

        public EditModel(IStudentService students,
            ISubjectService subjects) {
            this.students = students;
            this.subjects = subjects;
        }
        public void OnGet(int id)
        {
            Student = students.GetById(id);
            Subjects = subjects.GetAll();

        }

        public IActionResult OnPost(int id, IEnumerable<int> subjectIds) {
            students.SetSubjects(id, subjectIds);

            return RedirectToPage("/Details", new { id });
        }
    }
}
