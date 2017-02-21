using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OpenLive.Client.Admin.Models.Shared
{
    public class CheckBoxListItem
    {
        public string Id { get; set; }
        public string Display { get; set; }
        public bool IsChecked { get; set; }
        public bool IsDisabled { get; set; }

        public static CheckBoxListItem ToCheckboxlistItem(IdentityRole role, bool isDisabled)
        {
            if (role == null) return null;

            return new CheckBoxListItem
            {
                Id = role.Id,
                Display = role.Name,
                IsChecked = false,
                IsDisabled = isDisabled
            };
        }
    }
}
