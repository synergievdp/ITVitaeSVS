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

namespace ITVitaeSVS.UI.Web.Areas.Students.Pages
{
    [Authorize(Policy = Permissions.ManageStudents)]
    public class CreateEditModel : PageModel
    {
        private readonly IStudentService students;

        [BindProperty]
        public Student Student { get; set; }
        public CreateEditModel(IStudentService students) {
            this.students = students;
        }
        public void OnGet(int? id) {
            if (id == null)
                Student = new();
            else {
                Student = students.GetById(id.Value);
            }
        }

        public IActionResult OnPost(int? id) {
            if (id == null) {
                students.Add(Student);
            } else {
                students.Update(Student);
            }

            return RedirectToPage("Details", new { Student.Id });
        }
    }
}
