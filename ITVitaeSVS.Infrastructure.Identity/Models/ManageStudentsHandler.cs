using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Identity.Models
{
    public class ManageStudentsHandler : AuthorizationHandler<ChangeProgressRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ChangeProgressRequirement requirement)
        {
            if(context.User.HasClaim(Permissions.ClaimType, Permissions.ManageStudents))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
