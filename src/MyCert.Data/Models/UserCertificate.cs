using System;

namespace MyCert.Data.Models
{
    public class UserCertificate : BaseEntity
    {
        public double UserScore { get; set; }

        public double MaxScore { get; set; }

        public DateTime DateOfCertification { get; set; }


        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid CertificateId { get; set; }
        public Certificate Certificate { get; set; }
    }
}