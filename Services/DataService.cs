namespace toomanycookbooks.Services
{
    public class Recipe
    {
        public Recipe() { }

        public Recipe(string name, string book, string author, string[] ingredients)
        {
            Name = name;
            Book = book;
            Author = author;
            Ingredients.AddRange(ingredients.Select(i => new Ingredient{ Name = i }));
        }

        public string? Name { get; set; }
        public string? Book { get; set; }
        public string? Author { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new();
    }

    public class Ingredient 
    {
        public string Name { get; set; } = "";
    }

    public class DataService
    {
        private List<Recipe> _recipes = new List<Recipe>
            {
                new Recipe("Recipe1", "Book1", "Author1", new[] { "Ingredient1,Ingredient2" }),
                new Recipe("Recipe2", "Book2", "Author2", new[] { "Ingredient2,Ingredient3" }),
                new Recipe("Recipe3", "Book1", "Author1", new[] { "Ingredient3,Ingredient4" }),
                new Recipe("Recipe4", "Book3", "Author3", new[] { "Ingredient4,Ingredient1" })
            };

        public IEnumerable<Recipe> GetRecipes()
        {
            return _recipes;
        }

        public bool Save(Recipe recipe)
        {
            _recipes.Add(recipe);

            return true;
        }
    }
}
