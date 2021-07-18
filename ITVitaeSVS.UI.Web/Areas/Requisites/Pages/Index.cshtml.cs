using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Requisites.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRequisiteService requisites;

        public IEnumerable<Requisite> Requisites { get; set; }
        public IndexModel(IRequisiteService requisites) {
            this.requisites = requisites;
        }
        public void OnGet()
        {
            Requisites = requisites.GetAll();
        }
    }
}
