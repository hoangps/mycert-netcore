using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCert.Data.Enums;

namespace MyCert.Data.Models
{
    public class Question : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public string SubText { get; set; }
        
        [Required]
        public QuestionType QuestionType { get; set; }

        [Required]
        public double Score { get; set; }


        public Guid? QuestionCategoryId { get; set; }
        public QuestionCategory QuestionCategory { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public List<Answer> Answers { get; set; } 
    }
}
