using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyCert.Data.Models;

namespace MyCert.Data
{
    public class DatabaseInitializer
    {
        private static readonly string[] Roles = { "SysAdmin", "Administrator", "ContentEditor", "User" };

        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;

            await SeedRoles();
            await SeedUsers();
        }


        private async Task SeedRoles()
        {
            foreach (var roleName in Roles)
            {
                if (!_context.Roles.Any(r => r.Name == roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private async Task SeedUsers()
        {
            // Assume all required roles were created before running this seed
            if (!_context.Users.Any(u => u.UserName == "dajkavn@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "dajkavn@gmail.com",
                    UserName = "dajkavn@gmail.com",
                    FirstName = "Homer",
                    LastName = "Phan",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                await _userManager.CreateAsync(user, "123qwe!@#QWE");
                await _userManager.AddToRoleAsync(user, "SysAdmin");
            }

            if (!_context.Users.Any(u => u.UserName == "hoangps18689@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "hoangps18689@gmail.com",
                    UserName = "hoangps18689@gmail.com",
                    FirstName = "Hoang",
                    LastName = "Phan",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                await _userManager.CreateAsync(user, "123qwe!@#QWE");
                await _userManager.AddToRoleAsync(user, "Administrator");
            }

            if (!_context.Users.Any(u => u.UserName == "phanasaoz@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "phanasaoz@gmail.com",
                    UserName = "phanasaoz@gmail.com",
                    FirstName = "Phanasao",
                    LastName = "Phan",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                await _userManager.CreateAsync(user, "123qwe!@#QWE");
                await _userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
