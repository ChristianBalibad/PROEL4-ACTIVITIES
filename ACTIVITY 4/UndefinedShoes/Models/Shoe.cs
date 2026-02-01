using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UndefinedShoes.Models
{
    public class Shoe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Brand { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string Model { get; set; } = string.Empty;

        [StringLength(60)]
        public string? Style { get; set; }

        [StringLength(40)]
        public string? Color { get; set; }

        [Range(1, 30)]
        public int Size { get; set; }

        [Range(0, 9999)]
        public int Stock { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0.01", "999999.99")]
        public decimal Price { get; set; }
    }
}
