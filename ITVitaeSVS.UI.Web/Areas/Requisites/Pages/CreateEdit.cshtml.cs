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

namespace ITVitaeSVS.UI.Web.Areas.Requisites.Pages
{
    [Authorize(Policy = Permissions.ManageContent)]
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
            if (id == null)
                Requisite = new();
            else {
                Requisite = requisites.GetById(id.Value);
            }
        }
        public IActionResult OnPost(int? id) {
            if (id == null) {
                requisites.Add(Requisite);
            } else {
                requisites.Update(Requisite);
            }

            return RedirectToPage("Index");
        }
    }
}
