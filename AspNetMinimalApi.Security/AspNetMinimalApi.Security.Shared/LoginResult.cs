namespace AspNetMinimalApi.Security.Shared;

public class LoginResult
{
    public string Token { get; set; } = string.Empty;
    public string? Error { get; set; }
    public bool IsSuccess { get; set; }

    public LoginResult()
    {
    }

    private LoginResult(string token, string? error, bool isSuccess)
    {
        Token = token;
        Error = error;
        IsSuccess = isSuccess;
    }

    public static LoginResult InvalidLogin(string error)
        => new(string.Empty, error, false);

    public static LoginResult ValidLogin(string token)
        => new(token, null, true);
}
