using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
