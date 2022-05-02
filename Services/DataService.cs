using System.ComponentModel.DataAnnotations;
using System.Text.Json;

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
            Ingredients.AddRange(ingredients.Select(i => new Ingredient { Name = i }));
        }

        public Guid Id { get; set; }

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

    public class DataService
    {
        private readonly Uri _api;
        private readonly IHttpClientFactory _factory;

        private static JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public DataService(IConfiguration config, IHttpClientFactory factory)
        {
            _api = new Uri(config["Api"]);
            _factory = factory;
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            var url = new Uri(_api, "recipes");
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            if (response != null && response.IsSuccessStatusCode)
            {
                var data = await JsonSerializer.DeserializeAsync<IEnumerable<Recipe>>(response.Content.ReadAsStream(), _options);

                return data ?? Enumerable.Empty<Recipe>();
            }

            return Enumerable.Empty<Recipe>(); ;
        }

        public bool Save(Recipe recipe)
        {
            return true;
        }
    }
}
