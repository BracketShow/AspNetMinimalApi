using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AspNetMinimalApi.Security.Domain;

public static class CanDeletePersonPolicy
{
    public const string Name = nameof(CanDeletePersonPolicy);

    public static AuthorizationPolicy BuildPolicy() =>
        new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim(ClaimTypes.Role, "secretRole")
            .Build();
}
