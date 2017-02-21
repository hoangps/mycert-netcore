using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCert.Data.Models
{
    public class Certificate : BaseEntity
    {
        public string Name { get; set; }

        public string OrganizationOfCertification { get; set; }

        public string Template { get; set; } // need to think more about this
        

        public List<Test> Tests { get; set; }
    }
}
