using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using Core;

namespace WebApp2.Service.Login;

public class LoginServiceClientSide : ILoginService  {
    
    private ILocalStorageService localStorage { get; set; }
    
    public LoginServiceClientSide(ILocalStorageService ls) {
        localStorage = ls;
    }
    public async Task<User?> GetUserLoggedIn() {
            var res = await localStorage.GetItemAsync<User>("user");
            return res;
    }
    public async Task<bool> Login(string username, string password) {
        if (await Validate(username, password))
        {
            User user = new User { UserName = username, Password = "Validated"};
            
            await localStorage.SetItemAsync("user", user);
            return true;
        }
        return false;
    }

    protected virtual async Task<bool> Validate(string username, string password)
    {
        return username.Equals("peter") && password.Equals("1234");
    }
}



