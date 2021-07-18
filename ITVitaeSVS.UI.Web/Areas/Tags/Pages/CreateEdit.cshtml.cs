using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Tags.Pages
{
    public class CreateEditModel : PageModel
    {
        private readonly ITagService tags;

        [BindProperty]
        public Tag Tag { get; set; }

        public CreateEditModel(ITagService tags) {
            this.tags = tags;
        }
        public void OnGet(int? id)
        {
            if(id != null) {
                Tag = tags.GetById(id.Value);
            }
        }
        public void OnPost(int? id) {
            if(id != null) {
                tags.Update(Tag);
            } else {
                tags.Add(Tag);
            }
        }
    }
}
