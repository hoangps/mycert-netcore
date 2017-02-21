using System.ComponentModel.DataAnnotations;

namespace MyCert.Data.Models
{
    public class UserReference : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Note { get; set; }


        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}