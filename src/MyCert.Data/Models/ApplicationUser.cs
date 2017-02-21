using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyCert.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        // Profile
        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public string SocialIdentificationNumber { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }


        // Relationships
        public List<UserTest> TestsTaken { get; set; }

        public List<UserCertificate> UserCertificates { get; set; }

        public List<UserSkill> UserSkills { get; set; }

        // Education, Certifications, Working History
        public List<UserPartitionInfo> UserInformation { get; set; }

        public List<UserReference> References { get; set; }
    }
}