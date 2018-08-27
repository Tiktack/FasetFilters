using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Entities
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string url { get; set; }

        public double price { get; set; }

        public double oldprice { get; set; }
        [MaxLength(10)]
        public string currencyId { get; set; }

        public int categoryId { get; set; }

        public bool store { get; set; }

        public bool pickup { get; set; }

        public bool delivery { get; set; }

        public uint local_delivery_cost { get; set; }

        public string name { get; set; }

        public Publisher publisher { get; set; }

        public Series series { get; set; }

        [MaxLength(20)]
        public string year { get; set; }
        [MaxLength(300)]
        public string iSBN { get; set; }

        public Language language { get; set; }

        [MaxLength(20)]
        public string binding { get; set; }
        [MaxLength(100)]
        public string page_extent { get; set; }

        public string description { get; set; }

        public Sales_note sales_notes { get; set; }

        public bool manufacturer_warranty { get; set; }

        public ulong barcode { get; set; }

        public decimal weight { get; set; }
        [MaxLength(40)]
        public string dimensions { get; set; }

        public bool available { get; set; }
        [MaxLength(20)]
        public string type { get; set; }

        public int group_id { get; set; }

        public ICollection<Picture> picture { get; set; } = new List<Picture>();
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<Param> _params { get; set; }
    }
}
