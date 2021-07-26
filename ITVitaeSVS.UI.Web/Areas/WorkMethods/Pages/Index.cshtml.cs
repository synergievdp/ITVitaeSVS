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

namespace ITVitaeSVS.UI.Web.Areas.WorkMethods.Pages
{
    [Authorize(Policy = Permissions.ManageContent)]
    public class IndexModel : PageModel
    {
        private readonly IWorkMethodService methods;

        public IEnumerable<WorkMethod> Methods { get; set; }
        public IndexModel(IWorkMethodService methods) {
            this.methods = methods;
        }
        public void OnGet()
        {
            Methods = methods.GetAll();
        }
    }
}
