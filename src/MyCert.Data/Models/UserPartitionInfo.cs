using System;
using System.ComponentModel.DataAnnotations;
using MyCert.Data.Enums;

namespace MyCert.Data.Models
{
    public class UserPartitionInfo : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        [Required]
        public UserPartitionInfoType Type { get; set; }


        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}