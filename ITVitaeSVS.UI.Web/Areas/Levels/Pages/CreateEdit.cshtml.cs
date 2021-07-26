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

namespace ITVitaeSVS.UI.Web.Areas.Levels.Pages
{
    [Authorize(Policy = Permissions.ManageContent)]
    public class CreateEditModel : PageModel
    {
        private readonly ILevelService levels;
        [BindProperty]
        public Level Level { get; set; }

        public CreateEditModel(ILevelService levels) {
            this.levels = levels;
        }
        public void OnGet(int? id)
        {
            if (id == null)
                Level = new();
            else {
                Level = levels.GetById(id.Value);
            }
        }

        public IActionResult OnPost(int? id) {
            if (id == null) {
                levels.Add(Level);
            } else {
                levels.Update(Level);
            }

            return RedirectToPage("Index");
        }
    }
}
