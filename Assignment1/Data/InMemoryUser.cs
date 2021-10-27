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
        private List<User> users;
        private string uri="https://localhost:5003";
        private readonly HttpClient client;

        public InMemoryUser()

        {
            client = new HttpClient();
            users = new[]
            {
                new User()
                {
                    UserName = "dorin", Password = "1234",Level="user"
                },
                new User()
                {
                    UserName = "admin", Password = "admin",Level = "admin"
                }
            }.ToList();
        }

        public async Task<User> ValidateUser(string userName, string Password)
        {
            HttpResponseMessage responseMessage=await client.GetAsync(uri+$"/User?userName={userName}&password={Password}");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("auuu");
            }
            
            string message = await responseMessage.Content.ReadAsStringAsync();
            User temp = JsonSerializer.Deserialize<User>(message);
                Console.WriteLine(temp.UserName+"bebebbee");
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