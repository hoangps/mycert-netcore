using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCert.Admin.Models;
using MyCert.Data.Models;
using OpenLive.Client.Admin.Models.Shared;

namespace MyCert.Admin.Controllers
{
    public class UsersController : Controller
    {
        private const string SYSTEM_ADMIN_ROLE_NAME = "SysAdmin";
        private const string USER_ROLE_NAME = "User";

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public UsersController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<ActionResult> Index()
        {
            var users = await _userManager.Users
                .Include(u => u.Roles)
                .Take(25)
                .ToListAsync();

            var userListViewModel = new UserListViewModel { Users = new List<UserViewModel>()};

            foreach (var applicationUser in users)
            {
                var userModel = UserViewModel.ToViewModel(applicationUser);
//                foreach (var userRole in userModel.Roles)
//                {
//                    var role = await _roleManager.FindByIdAsync(userRole.Id);
//                    userRole.Name = role.Name;
//                }

                userListViewModel.Users.Add(userModel);
            }

            return View(userListViewModel);
        }

        public async Task<ActionResult> Create()
        {
            var availableRoles = await _roleManager.Roles.Where(r => r.Name != SYSTEM_ADMIN_ROLE_NAME).ToListAsync();

            if (availableRoles == null || !availableRoles.Any())
            {
                RegisterAlert("failed", "There is no available roles. Please add a role.");
                return RedirectToAction("Index");
            }

            var checkboxListItems = new List<CheckBoxListItem>();

            foreach (var role in availableRoles.ToList())
            {
                if (role.Name.Equals(SYSTEM_ADMIN_ROLE_NAME)) continue;
                var item = CheckBoxListItem.ToCheckboxlistItem(role, false);
                item.IsChecked = role.Name.Equals(USER_ROLE_NAME);
                checkboxListItems.Add(item);
            }

            return View(new UserViewModel { AvailableRoles = checkboxListItems.OrderBy(cb => cb.Display) });
        }
        
        public async Task<ActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                RegisterAlert("failed", "User not found.");
                return RedirectToAction("Index");
            }

            var availableRoles = await _roleManager.Roles.Where(r => r.Name != SYSTEM_ADMIN_ROLE_NAME).ToListAsync();

            if (availableRoles == null || !availableRoles.Any())
            {
                RegisterAlert("failed", "There is no available roles. Please add a role.");
                return RedirectToAction("Index");
            }

            var checkboxListItems = new List<CheckBoxListItem>();

            foreach (var role in availableRoles.ToList())
            {
                if (role.Name.Equals(SYSTEM_ADMIN_ROLE_NAME)) continue;
                var item = CheckBoxListItem.ToCheckboxlistItem(role, false);
                item.IsChecked = role.Name.Equals(USER_ROLE_NAME);
                checkboxListItems.Add(item);
            }

            var isUserSysAdmin = await _userManager.IsInRoleAsync(user, SYSTEM_ADMIN_ROLE_NAME);
            var isCurrentUserSysAdmin = User.IsInRole(SYSTEM_ADMIN_ROLE_NAME);

            // admin cannot remove himself && only system admin can remove other system admins
            ViewBag.HasDeleteAccess = user.Id != _userManager.GetUserId(User) && (!isUserSysAdmin || isCurrentUserSysAdmin);

            return View(UserUpdateViewModel.ToViewModel(user));
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                RegisterAlert("failed", "Form is invalid.");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                RegisterAlert("failed", result.Errors.First().Description);
                return View(model);
            }

            if (HttpContext.User.IsInRole(SYSTEM_ADMIN_ROLE_NAME))
            {
                foreach (var role in model.AvailableRoles)
                {
                    if (role.IsChecked)
                        await _userManager.AddToRoleAsync(user, role.Display);
                }
            }
            else
            {
                await _userManager.AddToRoleAsync(user, USER_ROLE_NAME);
            }

            RegisterAlert("success", $"{model.UserName} was created");
            return RedirectToAction("Update", new { id = user.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(UserUpdateViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            var isUserSysAdmin = await _userManager.IsInRoleAsync(user, SYSTEM_ADMIN_ROLE_NAME);
            var isCurrentUserSysAdmin = User.IsInRole(SYSTEM_ADMIN_ROLE_NAME);

            // admin cannot remove himself && only system admin can remove other system admins
            ViewBag.HasDeleteAccess = user.Id != _userManager.GetUserId(User) && (!isUserSysAdmin || isCurrentUserSysAdmin);

            if (!ModelState.IsValid)
            {
                RegisterAlert("failed", "Form is invalid");
                return View(model);
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.EmailConfirmed = true;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;

            var updated = await _userManager.UpdateAsync(user);

            if (!updated.Succeeded)
            {
                RegisterAlert("failed", "Failed to update user.");
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                var passwordUpdated = await _userManager.AddPasswordAsync(user, model.Password);
                if (!passwordUpdated.Succeeded)
                {
                    RegisterAlert("failed", passwordUpdated.Errors.First().Description);
                    return View(model);
                }
            }

            // update user roles ~ 
            var currentRoles = await _userManager.GetRolesAsync(user);
            var removingRoles = new List<string>();
            var addingRoles = new List<string>();
            foreach (var role in model.AvailableRoles)
            {
                if (role.IsChecked && !currentRoles.Contains(role.Display))
                    addingRoles.Add(role.Display);

                if (!role.IsChecked && currentRoles.Contains(role.Display))
                    removingRoles.Add(role.Display);
            }

            var rolesRemoved = await _userManager.RemoveFromRolesAsync(user, removingRoles);
            if (!rolesRemoved.Succeeded)
            {
                RegisterAlert("failed", rolesRemoved.Errors.First().Description);
                return View(model);
            }

            var roleAdded = await _userManager.AddToRolesAsync(user, addingRoles);
            if (!roleAdded.Succeeded)
            {
                RegisterAlert("failed", roleAdded.Errors.First().Description);
                return View(model);
            }

            RegisterAlert("success", $"User {model.UserName} was updated.");
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                RegisterAlert("failed", "User not found");
                return RedirectToAction("Index");
            }

            var isSysAdmin = await _userManager.IsInRoleAsync(user, SYSTEM_ADMIN_ROLE_NAME);

            if (user.Id != _userManager.GetUserId(User) && (!isSysAdmin || User.IsInRole(SYSTEM_ADMIN_ROLE_NAME)))
            {
                var deleted = await _userManager.DeleteAsync(user);
                if (deleted.Succeeded)
                {
                    RegisterAlert("success", $"User '{user.UserName}' was deleted.");
                    return RedirectToAction("Index");
                }

                RegisterAlert("failed", deleted.Errors.First().Description);
                return RedirectToAction("Update", new { id });
            }

            RegisterAlert("failed", "You cannot delete this user.");
            return RedirectToAction("Update", new { id });
        }

        private void RegisterAlert(string alertType, string message)
        {
            TempData["Alert"] = new Dictionary<string, string> { { alertType, message } };
        }
    }
}
