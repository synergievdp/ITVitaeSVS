using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Identity.Models
{
    public static class Permissions
    {
        public const string ClaimType = "Permission";
        public const string ManageContent = "ManageContent";
        public const string ManageStudents = "ManageStudents";
        public const string ChangeProgress = "ChangeProgress";
        public const string ManageUsers = "ManageUsers";
        public const string ViewTopics = "ViewTopics";
    }
}
