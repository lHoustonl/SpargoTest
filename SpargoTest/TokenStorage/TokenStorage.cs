using Refit;

namespace SpargoTest;

public class TokenStorage
{
    private AuthorizeToken authorizeToken = null!;

    public void SetToken(AuthorizeToken newToken)
    {
        authorizeToken = newToken;
    }

    public string GetToken()
    {
        if (authorizeToken is not null && authorizeToken.ExpirationDate > DateTime.Now)
            return authorizeToken.Token;

        authorizeToken = UpdateToken();
        return authorizeToken.Token;
    }

    private AuthorizeToken UpdateToken()
    {
        var apiClient = RestService.For<IApiClient>("http://f3bus.test.pharmadata.ru");

        var authenticationResponse = apiClient.AuthenticateAsync(new()
        {
            Login = "demo",
            Password = "demo",
        }, UserRoles.Agent);
        if (authenticationResponse.Result.IsSuccessStatusCode is false)
            throw new Exception("Authentication failed");

        if (authenticationResponse.Result.Content is null)
            throw new Exception("No authentication token was found for current user");

        return new AuthorizeToken
        {
            Token = $"Bearer {authenticationResponse.Result.Content.Token}",
            ExpirationDate = authenticationResponse.Result.Content.Expiration
        };
    }
}

public sealed class AuthorizeToken
{
    public string Token { get; set; } = null!;
    public DateTimeOffset ExpirationDate { get; set; }
}