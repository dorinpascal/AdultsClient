using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public class InMemoryUser : IUser
    {
        private string uri="https://localhost:5003";
        private readonly HttpClient client;

        public InMemoryUser()

        {
            client = new HttpClient();
        }

        public async Task<User> ValidateUser(string userName, string Password)
        {
            HttpResponseMessage responseMessage=await client.GetAsync(uri+$"/User?userName={userName}&password={Password}");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Exception response");
            }
            
            string message = await responseMessage.Content.ReadAsStringAsync();
            User temp = JsonSerializer.Deserialize<User>(message);
            
            if (temp == null)
            {
                throw new Exception("User not found");
            }

            if (!temp.Password.Equals(Password))
            {
                throw new Exception("Incorrect password");
            }

            return temp;
        }
    }
}