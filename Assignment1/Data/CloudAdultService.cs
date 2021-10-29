using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public class CloudAdultService : IAdult
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudAdultService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/Adults");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Huston Problem");
            }

            string message = await response.Content.ReadAsStringAsync();
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);

            return result;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/Adults", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Huston Problem lalalala");
            }
        }

        public async Task<int> getLastAdultId()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/Adults");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Huston Problem");
            }

            string message = await response.Content.ReadAsStringAsync();
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);

            return result.Count;
        }
    }
}