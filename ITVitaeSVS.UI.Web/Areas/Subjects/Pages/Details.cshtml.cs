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

namespace ITVitaeSVS.UI.Web.Areas.Subjects.Pages
{
    [Authorize(Policy = Permissions.ManageContent)]
    public class DetailsModel : PageModel
    {
        private readonly ISubjectService subjects;
        [BindProperty]
        public Subject Subject { get; set; }

        public DetailsModel(ISubjectService subjects)
        {
            this.subjects = subjects;
        }
        public void OnGet(int id)
        {
            Subject = subjects.GetById(id);
        }
    }
}
