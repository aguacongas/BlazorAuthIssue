using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;
using System.Text.Json;

public class ClaimsPrincipalFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    private readonly ILogger<ClaimsPrincipalFactory> _logger;

    public ClaimsPrincipalFactory(IAccessTokenProviderAccessor accessor, ILogger<ClaimsPrincipalFactory> logger) : base(accessor)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
    {
        var user = await base.CreateUserAsync(account, options);
        if (user.Identity is ClaimsIdentity identity)
        {
            _logger.LogInformation("User connected {IdentityName}", identity.Name);
            foreach (var claim in user.Claims.ToArray())
            {
                var value = claim.Value;
                if (value.StartsWith("["))
                {
                    var values = JsonSerializer.Deserialize<IEnumerable<string>>(value);
                    if (values is null)
                    {
                        throw new InvalidOperationException($"Cannot deserialize claim {claim.Type}, value: {claim.Value}");
                    }

                    var type = claim.Type;
                    foreach (var item in values)
                    {
                        _logger.LogInformation("Add {Type} claim {Item}", type, item);
                        identity.AddClaim(new Claim(type, item));
                    }
                    identity.RemoveClaim(claim);
                }
            }
        }

        return user;
    }
}