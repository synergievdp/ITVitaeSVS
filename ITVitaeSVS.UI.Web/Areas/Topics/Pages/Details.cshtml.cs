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

namespace ITVitaeSVS.UI.Web.Areas.Topics.Pages
{
    [Authorize(Policy = Permissions.ManageContent)]
    public class DetailsModel : PageModel
    {
        private readonly ITopicService topics;

        public Topic Topic { get; set; }
        public DetailsModel(ITopicService topics) {
            this.topics = topics;
        }
        public void OnGet(int id)
        {
            Topic = topics.GetById(id);
        }
    }
}
