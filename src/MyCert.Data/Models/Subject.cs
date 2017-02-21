using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCert.Data.Models
{
    public class Subject : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Introduction { get; set; }


        public Guid? SubjectCategoryId { get; set; }
        public SubjectCategory SubjectCategory { get; set; }
        
        public List<Question> Questions { get; set; } 
        public List<Certificate> Certificates { get; set; } 
    }
}
