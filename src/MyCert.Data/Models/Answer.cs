using System;
using System.ComponentModel.DataAnnotations;

namespace MyCert.Data.Models
{
    public class Answer : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public bool PreferedLast { get; set; }

        public bool IsCorrectAnswer { get; set; }


        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}