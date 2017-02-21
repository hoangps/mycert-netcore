using System;

namespace MyCert.Data.Models
{
    public class UserTest : BaseEntity
    {
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Questions { get; set; } // json string data, include answers in orders

        public string UserAnswers { get; set; } // json string data

        public double Score { get; set; }

        public bool IsFinished { get; set; }

        public bool IsPassed { get; set; }

        public bool IsPrivate { get; set; }


        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public Guid TestId { get; set; }

        public Test Test { get; set; }
    }
}