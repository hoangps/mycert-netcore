using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCert.Data.Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public Guid? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
