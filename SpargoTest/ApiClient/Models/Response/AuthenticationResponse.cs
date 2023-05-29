namespace SpargoTest;

public sealed class AuthenticationResponse
{
    public string Token { get; init; } = null!;
    public DateTimeOffset Expiration { get; init; }
}
