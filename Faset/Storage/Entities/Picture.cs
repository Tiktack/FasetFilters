using System.ComponentModel.DataAnnotations;

namespace Storage.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string pictureUrl { get; set; }
    }
}
