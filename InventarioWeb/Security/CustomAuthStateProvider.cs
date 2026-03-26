using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Security.Claims;

namespace InventarioWeb.Security;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationState _anonymous;

    public CustomAuthStateProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        if (string.IsNullOrEmpty(token)) return _anonymous;

        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "Usuario") }, "jwt");
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public void NotifyUserLogin(string token)
    {
        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "Usuario") }, "jwt");
        var user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void NotifyUserLogout()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(_anonymous));
    }
}