using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Students.Pages
{
    public class CreateEditModel : PageModel
    {
        private readonly IStudentService students;

        [BindProperty]
        public Student Student { get; set; }
        public CreateEditModel(IStudentService students) {
            this.students = students;
        }
        public void OnGet(int? id) {
            if(id != null) {
                Student = students.GetById(id.Value);
            }
        }

        public void OnPost(int? id) {
            if(id != null) {
                students.Update(Student);
            } else {
                students.Add(Student);
            }
        }
    }
}
