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

    private List<User> users = new List<User>()
    {
        new User { Id = 1, UserName = "rip",Password = "1234", Role = "admin"},
        new User {Id=2, UserName = "rap", Password = "4321", Role = "admin"},
        new User {Id = 3, UserName = "rup", Password = "qwerty", Role="member"}
    };
    protected virtual async Task<bool> Validate(string username, string password)
    {
        foreach (User u in users)

            if (username.Equals(u.UserName) && password.Equals(u.Password))
                return true;

        return false;
    }
}



