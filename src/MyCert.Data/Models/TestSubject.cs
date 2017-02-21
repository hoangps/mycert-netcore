using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCert.Data.Models
{
    public class TestSubject : BaseEntity
    {
        [Required]
        public int QuestionQuota { get; set; }


        public Guid TestId { get; set; }
        public Test Test { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
