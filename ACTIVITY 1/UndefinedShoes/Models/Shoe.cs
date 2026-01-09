using System.ComponentModel.DataAnnotations;


namespace UndefinedShoes.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Style { get; set; }
        public string? Color { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
    }
}
