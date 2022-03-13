namespace toomanycookbooks.Services
{
    public class Recipe
    {
        public Recipe() { }

        public Recipe(string name, string book, string author, string ingredients)
        {
            Name = name;
            Book = book;
            Author = author;
            Ingredients = ingredients;
        }

        public string? Name { get; set; }
        public string? Book { get; set; }
        public string? Author { get; set; }

        public string? Ingredients { get; set; }
    }

    public class DataService
    {
        private List<Recipe> _recipes = new List<Recipe>
            {
                new Recipe("Recipe1", "Book1", "Author1", "Ingredient1,Ingredient2"),
                new Recipe("Recipe2", "Book2", "Author2", "Ingredient2,Ingredient3"),
                new Recipe("Recipe3", "Book1", "Author1", "Ingredient3,Ingredient4"),
                new Recipe("Recipe4", "Book3", "Author3", "Ingredient4,Ingredient1")
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
