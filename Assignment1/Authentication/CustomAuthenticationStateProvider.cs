using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment1.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Models;

namespace Assignment1.Authentication
{
    public class CustomAuthenticationStateProvider :AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRunTime;
        private readonly IUser userService;
        private User cachedUser;
        
        public CustomAuthenticationStateProvider(IJSRuntime jsRunTime, IUser userService)
        {
            this.jsRunTime = jsRunTime;
            this.userService = userService;
        }
        
        
        
        
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                string userAsJson = await jsRunTime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    User temp = JsonSerializer.Deserialize<User>(userAsJson);
                    Console.WriteLine(temp.UserName);
                    ValidateLogin(temp.UserName, temp.Password);
                }
            }
            else
            {
                identity = SetupClaimsForUser(cachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }
        
        private ClaimsIdentity SetupClaimsForUser(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,user.UserName));
            claims.Add(new Claim("Level",user.Level.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        

        public async Task ValidateLogin(string tempUserName, string tempPassword)
        {
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(tempUserName)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(tempPassword)) throw new Exception("Enter password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try {
                Console.WriteLine(tempUserName+"lalalalallaa");
                User user = await userService.ValidateUser(tempUserName, tempPassword);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                await jsRunTime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = user;
                Console.WriteLine(user.UserName);
            } catch (Exception e) {
                throw e;
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }
        public void LogOut()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRunTime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}