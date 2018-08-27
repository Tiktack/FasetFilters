using System.Collections.Generic;

namespace Storage.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
