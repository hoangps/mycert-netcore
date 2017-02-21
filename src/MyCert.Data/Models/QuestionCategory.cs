using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCert.Data.Models
{
    public class QuestionCategory : BaseEntity
    {
        public string Name { get; set; }


        public List<Question> Questions { get; set; } 
    }
}
