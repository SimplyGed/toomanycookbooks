using System.Text.Json;
using toomanycookbooks.Services.Models;

namespace toomanycookbooks.Services
{
    public class BookService : DataService
    {
        public BookService(IConfiguration config, IHttpClientFactory factory) : base(config, factory)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var url = new Uri(API, "books");
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            if (response != null && response.IsSuccessStatusCode)
            {
                var data = await JsonSerializer.DeserializeAsync<IEnumerable<Book>>(response.Content.ReadAsStream(), _options);

                return data ?? Enumerable.Empty<Book>();
            }

            return Enumerable.Empty<Book>();
        }
    }
}