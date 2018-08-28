using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faset.Models.Facet
{
    public class PageViewModel
    {
        public IEnumerable<string> Languages { get; set; }
        public IEnumerable<string> Sales_notes { get; set; }
        //public IEnumerable<string> Publishers { get; set; }
        //public IEnumerable<string> Authors { get; set; }
    }
}
