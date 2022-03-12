namespace toomanycookbooks.Services
{
    public record Recipe(string Name, string Book, string Author, string Ingredients);

    public class DataService
    {
        public IEnumerable<Recipe> GetRecipes()
        {
            return new List<Recipe>
            {
                new Recipe("Recipe1", "Book1", "Author1", "Ingredient1,Ingredient2"),
                new Recipe("Recipe2", "Book2", "Author2", "Ingredient2,Ingredient3"),
                new Recipe("Recipe3", "Book1", "Author1", "Ingredient3,Ingredient4"),
                new Recipe("Recipe4", "Book3", "Author3", "Ingredient4,Ingredient1")
            };
        }
    }
}
