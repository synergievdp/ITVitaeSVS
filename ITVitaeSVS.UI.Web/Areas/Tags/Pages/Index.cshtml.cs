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
    public class IndexModel : PageModel
    {
        private readonly ITagService tags;

        public IEnumerable<Tag> Tags { get; set; }
        public IndexModel(ITagService tags) {
            this.tags = tags;
        }
        public void OnGet()
        {
            Tags = tags.GetAll();
        }
    }
}
