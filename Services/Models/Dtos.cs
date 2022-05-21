namespace toomanycookbooks.Services.Dtos
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Book { get; set; }
        public string? Author { get; set; }

        public IEnumerable<string> Ingredients { get; set; } = Enumerable.Empty<string>();
    }
}