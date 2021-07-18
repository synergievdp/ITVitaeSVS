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
    public class IndexModel : PageModel
    {
        private readonly ICertificateService certificates;

        public IEnumerable<Certificate> Certificates { get; set; }
        public IndexModel(ICertificateService certificates) {
            this.certificates = certificates;
        }
        public void OnGet()
        {
            Certificates = certificates.GetAll();
        }
    }
}
