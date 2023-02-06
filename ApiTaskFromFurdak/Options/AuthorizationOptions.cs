namespace ApiTaskFromFurdak.Options;

public sealed class AuthorizationOptions
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string SecretForKey { get; set; } = string.Empty;
}
