#region Using

using System.ComponentModel.DataAnnotations;

#endregion

namespace MyCert.Admin.Models.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}