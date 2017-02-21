using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCert.Data.Models
{
    public class Test : BasePageEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Introduction { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public double PassScore { get; set; }

        public bool IsPrivate { get; set; }

        public bool IsEnabled { get; set; }

        public double Price { get; set; }

        public Guid? CertificateId { get; set; }
        public Certificate Certificate { get; set; }

        public List<TestSubject> TestSubjects { get; set; }
    }
}