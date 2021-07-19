using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITVitaeSVS.UI.Web.Areas.Topics.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITopicService topics;

        public IEnumerable<Topic> Topics { get; set; }
        public IndexModel(ITopicService topics) {
            this.topics = topics;
        }
        public void OnGet()
        {
            Topics = topics.GetAll();
        }
    }
}
