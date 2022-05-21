using System.Text.Json;

namespace toomanycookbooks.Services
{
    public abstract class DataService
    {
        protected Uri API { get; init; }
        protected readonly IHttpClientFactory _factory;

        protected static JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        protected DataService(IConfiguration config, IHttpClientFactory factory)
        {
            API = new Uri(config["Api"]);
            _factory = factory;
        }
    }
}
