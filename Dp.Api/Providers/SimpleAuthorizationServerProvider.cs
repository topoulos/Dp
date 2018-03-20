using System.Security.Claims;
using System.Threading.Tasks;
using Dp.Models.Security;
using Microsoft.Owin.Security.OAuth;

namespace Dp.Api.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add(key: "Access-Control-Allow-Origin", value: new[] {"*"});

            using (var _repo = new AuthRepository())
            {
                var user = await _repo.FindUser(userName: context.UserName, password: context.Password);

                if (user == null)
                {
                    context.SetError(error: "invalid_grant", errorDescription: "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(authenticationType: context.Options.AuthenticationType);
            identity.AddClaim(claim: new Claim(type: "sub", value: context.UserName));
            identity.AddClaim(claim: new Claim(type: "role", value: "user"));

            context.Validated(identity: identity);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(action: () => { context.Validated(); });
        }
    }
}