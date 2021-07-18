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
    public class CreateEditModel : PageModel
    {
        private readonly IRequisiteService requisites;

        [BindProperty]
        public Requisite Requisite { get; set; }
        public CreateEditModel(IRequisiteService requisites) {
            this.requisites = requisites;
        }
        public void OnGet(int? id)
        {
            if (id != null)
                Requisite = requisites.GetById(id.Value);
        }
        public void OnPost(int? id) {
            if(id != null) {
                requisites.Update(Requisite);
            } else {
                requisites.Add(Requisite);
            }
        }
    }
}
