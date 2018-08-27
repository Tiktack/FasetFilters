using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Entities
{
    public class Series
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string name { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
