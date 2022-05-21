using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor.DataAccess
{
    public class CloudDataService : IDataService
    {
        private string uri = "https://localhost:44371";
        private readonly HttpClient client;

        public CloudDataService()
        {
            client = new HttpClient();
        }

        public async Task CreateChildAsync(Child c)
        {
            string childAsJson = JsonSerializer.Serialize(c);
            HttpContent content = new StringContent(childAsJson, Encoding.UTF8,
                                                 "application/json");
            await client.PostAsync(uri + "/api/children", content);
        }

        public async Task<IList<Child>> GetChildrenAsync()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            Task<string> stringAsync = client.GetStringAsync(uri + "/api/children");
            string message = await stringAsync;
            List<Child> result = JsonSerializer.Deserialize<List<Child>>(message, options);
            return result;
        }

        public async Task CreateToyAsync (Toy t)
        {
            string childAsJson = JsonSerializer.Serialize(t);
            HttpContent content = new StringContent(childAsJson, Encoding.UTF8,
                                                 "application/json");
            await client.PostAsync(uri + "/api/toys", content);
        }

        public async Task<IList<Toy>> GetToysAsync()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            Task<string> stringAsync = client.GetStringAsync(uri + "/api/toys");
            string message = await stringAsync;
            List<Toy> result = JsonSerializer.Deserialize<List<Toy>>(message, options);
            return result;
        }

        public async Task RemoveToyAsync(string name)
        {
            await client.DeleteAsync($"{uri}/api/toys/{name}");
        }

    }
}
