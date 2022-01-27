namespace AspNetMinimalApi.Security.Domain.Abstractions;

public interface IJwtTokenGenerator
{
    string GenerateTokenAsync(string username);
}
