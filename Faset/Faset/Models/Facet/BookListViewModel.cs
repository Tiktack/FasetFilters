using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faset.Models.Facet
{
    public class BookListViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
