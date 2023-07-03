using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Educational.Identity
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> apiScopes =>
            new List<ApiScope>
            {
                new ApiScope("EducWebAPI", "Educational API"),
                new ApiScope("EducChat", "Educational Chat")
            };

        public static IEnumerable<IdentityResource> identityResources =>
           new List<IdentityResource>
           {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
               new IdentityResource()
               {
                   Name = "CustomResource",
                   DisplayName = "user information",
                   UserClaims = new[] 
                   {
                       JwtClaimTypes.GivenName, JwtClaimTypes.Role, JwtClaimTypes.ClientId,
                       JwtClaimTypes.Email, JwtClaimTypes.BirthDate, JwtClaimTypes.FamilyName
                   }
               }
               
           };

        public static IEnumerable<ApiResource> apiResources =>
            new List<ApiResource>
            {
                new ApiResource("EducWebAPI")
                {
                    UserClaims = {JwtClaimTypes.Audience},
                    Scopes = { "EducWebAPI" }
                },
                new ApiResource("EducChat")
                {
                    UserClaims = {JwtClaimTypes.Audience},
                    Scopes = { "EducChat" }
                },
            };

        public static IEnumerable<Client> clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "educDesktopClient",
                    ClientName = "Educ Desktop",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    RequireClientSecret = true,
                    RequirePkce = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "CustomResource",
                        "EducWebAPI",
                        "EducChat"
                    },
                    ClientSecrets =
                    {
                        new Secret("secretpassword".Sha256())
                    },
                    AccessTokenLifetime = 3600 * 24 * 30,
                    AllowAccessTokensViaBrowser = true
                },
                new Client
                {
                    ClientId = "educ-web-client",
                    ClientName = "Educ Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://localhost:3000/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:3000"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:3000/signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "CustomResource",
                        "EducWebAPI",
                        "EducChat"
                    },
                    AlwaysIncludeUserClaimsInIdToken=true,
                    AlwaysSendClientClaims = true,
                    AccessTokenLifetime = 3600 * 24 * 30,
                    AllowAccessTokensViaBrowser = true,
                }
            };
    }
}
