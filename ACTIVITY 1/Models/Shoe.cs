using System.ComponentModel.DataAnnotations;

namespace RazorPagesUndefined.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime LaunchDate { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}
