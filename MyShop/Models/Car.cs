using System.ComponentModel.DataAnnotations;

namespace MyShop.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand is Required")]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "Model is Required")]
        public string? Model { get; set; }

        [Range(2000, 2025, ErrorMessage = "Year must be between 2000 and 2025")]
        [Required(ErrorMessage = "Year is required")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string? Type { get; set; } 

        [Required(ErrorMessage = "Price is required")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Color is required")]
        public string? Color { get; set; }

        public string? ImageFileName { get; set; }

        //Slug
        public string Slug => $"{Brand}-{Model}-{Year}".ToLower().Replace(" ", "-");
    }
}
