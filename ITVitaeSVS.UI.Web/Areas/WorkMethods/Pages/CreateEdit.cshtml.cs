using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.WorkMethods.Pages
{
    public class CreateEditModel : PageModel
    {
        private readonly IWorkMethodService workMethods;

        [BindProperty]
        public WorkMethod WorkMethod { get; set; }
        public CreateEditModel(IWorkMethodService workMethods) {
            this.workMethods = workMethods;
        }
        public void OnGet(int? id)
        {
            if (id == null)
                WorkMethod = new();
            else {
                WorkMethod = workMethods.GetById(id.Value);
            }
        }

        public IActionResult OnPost(int? id) {
            if (id == null) {
                workMethods.Add(WorkMethod);
            } else {
                workMethods.Update(WorkMethod);
            }

            return RedirectToPage("Index");
        }
    }
}
