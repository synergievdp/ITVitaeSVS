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
    public class IndexModel : PageModel
    {
        private readonly IStudentService students;

        public IEnumerable<Student> Students { get; set; }
        public IndexModel(IStudentService students) {
            this.students = students;
        }
        public void OnGet()
        {
            Students = students.GetAll();
        }
    }
}
