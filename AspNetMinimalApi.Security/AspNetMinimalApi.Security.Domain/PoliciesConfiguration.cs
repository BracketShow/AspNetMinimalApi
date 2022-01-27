using Microsoft.AspNetCore.Authorization;

namespace AspNetMinimalApi.Security.Domain;

public static class PoliciesConfiguration
{
    public static void ConfigurePolicies(AuthorizationOptions options) => options.AddPolicy(CanDeletePersonPolicy.Name, CanDeletePersonPolicy.BuildPolicy());
}
