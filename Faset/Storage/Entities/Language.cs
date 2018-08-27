using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Entities
{
    public class Language 
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
