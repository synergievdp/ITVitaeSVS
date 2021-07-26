using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Identity.Models
{
    public class PageOwnerHandler : AuthorizationHandler<ChangeProgressRequirement>
    {
        private readonly IHttpContextAccessor httpContext;

        public PageOwnerHandler(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ChangeProgressRequirement requirement)
        {
            var id = context.User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);
            if (id == null)
                return Task.CompletedTask;
            if (httpContext.HttpContext.Request.RouteValues["id"].ToString() == id.Value)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
