using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCert.Admin.Models
{
    public class ExternalLoginsViewModel
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
    }
}
