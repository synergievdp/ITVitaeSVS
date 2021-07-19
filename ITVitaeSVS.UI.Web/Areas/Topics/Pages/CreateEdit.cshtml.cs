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
    public class CreateEditModel : PageModel
    {
        private readonly ITopicService topics;
        [BindProperty]
        public Topic Topic { get; set; }
        public CreateEditModel(ITopicService topics) {
            this.topics = topics;
        }
        public void OnGet(int? id) {
            if (id != null) {
                Topic = topics.GetById(id.Value);
            }
        }

        public void OnPost(int? id) {
            if (id != null) {
                topics.Update(Topic);
            } else {
                topics.Add(Topic);
            }
        }
    }
}
