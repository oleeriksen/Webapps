using System.Net.Http.Json;
using Blazored.LocalStorage;
using Core;

namespace WebApp2.Service.Login;

public class LoginServiceServerSide : LoginServiceClientSide
{
    private HttpClient http;

    private string serverUrl = "http://localhost:5284";
    
    public LoginServiceServerSide(ILocalStorageService ls, HttpClient http) : base(ls)
    {
        this.http = http;
        
    }

    protected override async Task<User?> Validate(string username, string password)
    {
        User? res = await http.GetFromJsonAsync<User>($"{serverUrl}/api/login/validate?username={username}&password={password}");
        return res;
    }
}