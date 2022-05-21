using System.ComponentModel.DataAnnotations;

namespace toomanycookbooks.Services.Models
{
    public class Recipe
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Book { get; set; }
        [Required]
        public string? Author { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new();
    }

    public class Ingredient
    {
        public string Name { get; set; } = "";
    }

    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}
