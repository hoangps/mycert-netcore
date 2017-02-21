using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCert.Data.Models
{
    public class SubjectCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }


        public List<Subject> Subjects { get; set; } 
    }
}
