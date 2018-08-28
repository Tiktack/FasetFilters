using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faset.Models.Facet
{
    public class BookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public double? Price { get; set; }
        public string Discription { get; set; }
        public string Language { get; set; }
        public string Year { get; set; }
        public string Sales_note { get; set; }
    }
}
