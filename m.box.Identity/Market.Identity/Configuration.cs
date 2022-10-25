using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4;

namespace Market.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("MarketWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("MarketWebAPI", "Web API", new []
                    {JwtClaimTypes.Name})
                {
                    Scopes = {"MarketWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "market-web-api",
                    ClientName = "Market Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://.../signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "https:/.../signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile, 
                        "MarketWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
