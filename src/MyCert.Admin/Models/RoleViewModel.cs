using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyCert.Admin.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int NumberOfMembers { get; set; }

        public static RoleViewModel ToViewModel(IdentityUserRole<string> role)
        {
            if (role == null) return new RoleViewModel();

            return new RoleViewModel
            {
                Id = role.RoleId
            };
        }
    }
}
