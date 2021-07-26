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
    public class IndexModel : PageModel
    {
        private readonly ILevelService levels;

        public IEnumerable<Level> Levels { get; set; }
        public IndexModel(ILevelService levels) {
            this.levels = levels;
        }
        public void OnGet()
        {
            Levels = levels.GetAll();
        }
    }
}
