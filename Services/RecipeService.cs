using System.Net.Mime;
using System.Text;
using System.Text.Json;
using toomanycookbooks.Services.Dtos;
using toomanycookbooks.Services.Models;

namespace toomanycookbooks.Services
{
    public class RecipeService : DataService
    {
        public RecipeService(IConfiguration config, IHttpClientFactory factory) : base(config, factory)
        {
        }

        public async Task<IEnumerable<RecipeDto>> GetRecipesAsync()
        {
            var url = new Uri(API, "recipes");
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            if (response != null && response.IsSuccessStatusCode)
            {
                var data = await JsonSerializer.DeserializeAsync<IEnumerable<RecipeDto>>(response.Content.ReadAsStream(), _options);

                return data ?? Enumerable.Empty<RecipeDto>();
            }

            return Enumerable.Empty<RecipeDto>();
        }

        public async Task<bool> SaveAsync(Recipe recipe)
        {
            var url = new Uri(API, "recipes");
            var client = _factory.CreateClient();

            var json = JsonSerializer.Serialize(recipe);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await client.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }
    }
}