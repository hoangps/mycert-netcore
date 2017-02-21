using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MyCert.Data.Models;
using OpenLive.Client.Admin.Models.Shared;

namespace MyCert.Admin.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter a Username.")]
        [MinLength(4, ErrorMessage = "Your username must be at least 4 characters")]
        public string UserName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter an Email Address.")]
        public string Email { get; set; }

        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter a Password.")]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [Compare("Password", ErrorMessage = "Password and Password Confirmation do not match.")]
        [Required(ErrorMessage = "Please repeat your Password.")]
        public string PasswordConfirmation { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter a First Name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter a Last Name.")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Phone Number Confirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "Two Factor Enabled")]
        public bool TwoFactorEnabled { get; set; }

        public string Tenant { get; set; }

        [Display(Name = "Roles")]
        public IEnumerable<CheckBoxListItem> AvailableRoles { get; set; }
        
        public IEnumerable<RoleViewModel> Roles { get; set; }
        public IEnumerable<ExternalLoginsViewModel> ExternalLogins { get; set; }

        public static UserViewModel ToViewModel(ApplicationUser user)
        {
            if (user == null) return new UserViewModel();

            return new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                Roles = user.Roles.Select(RoleViewModel.ToViewModel)
            };
        }
    }

    public class UserListViewModel
    {
        public List<UserViewModel> Users { get; set; }

        public static UserListViewModel ToViewModel(IEnumerable<ApplicationUser> users)
        {
            if(users == null || !users.Any()) return new UserListViewModel();

            return new UserListViewModel
            {
                Users = users.Select(UserViewModel.ToViewModel).ToList()
            };
        }
    }

    public class UserUpdateViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter a Username.")]
        [MinLength(4, ErrorMessage = "Your username must be at least 4 characters")]
        public string UserName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter an Email Address.")]
        public string Email { get; set; }

        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        public string PasswordConfirmation { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter a First Name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter a Last Name.")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Phone Number Confirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "Two Factor Enabled")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "Roles")]
        public IEnumerable<CheckBoxListItem> AvailableRoles { get; set; }
        
        public IEnumerable<RoleViewModel> Roles { get; set; }
        public IEnumerable<ExternalLoginsViewModel> ExternalLogins { get; set; }

        public static UserUpdateViewModel ToViewModel(ApplicationUser user)
        {
            if (user == null) return new UserUpdateViewModel();

            return new UserUpdateViewModel
            {
                Id = user.Id,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                Roles = user.Roles.Select(RoleViewModel.ToViewModel)
            };
        }
    }
}
