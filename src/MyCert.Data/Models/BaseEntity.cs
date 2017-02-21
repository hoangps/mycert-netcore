using System;
using System.ComponentModel.DataAnnotations;

namespace MyCert.Data.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [MaxLength(38)]
        public string CreatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        [MaxLength(38)]
        public string UpdatedBy { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}