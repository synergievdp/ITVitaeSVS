using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Certificates.Pages
{
    public class CreateEditModel : PageModel
    {
        private readonly ICertificateService certificates;
        [BindProperty]
        public Certificate Certificate { get; set; }
        public CreateEditModel(ICertificateService certificates) {
            this.certificates = certificates;
        }
        public void OnGet(int? id)
        {
            if (id == null)
                Certificate = new();
            else {
                Certificate = certificates.GetById(id.Value);
            }
        }

        public IActionResult OnPost(int? id) {
            if (id == 0) {
                certificates.Add(Certificate);
            } else {
                certificates.Update(Certificate);
            }

            return RedirectToPage("Index");
        }
    }
}
