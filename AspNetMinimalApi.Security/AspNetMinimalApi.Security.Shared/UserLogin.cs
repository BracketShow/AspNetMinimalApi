namespace AspNetMinimalApi.Security.Shared;

public record UserLogin
{
    public string Username { get; set; } = string.Empty;
}
