using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Storage.Entities
{
    public class Sales_note
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
