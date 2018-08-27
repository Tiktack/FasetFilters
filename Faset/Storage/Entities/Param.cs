using System.ComponentModel.DataAnnotations;

namespace Storage.Entities
{
    public class Param
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string paramName { get; set; }
        [MaxLength(10)]
        public string paramUnit { get; set; }
        public string paramValue { get; set; }
    }
}
