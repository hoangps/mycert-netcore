using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCert.Data.Models
{
    public class BasePageEntity : BaseEntity
    {
        [Required]
        public string Slug { get; set; }
    }
}
