using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Dp.Api;
using Dp.Api.IoC;
using Dp.Api.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector.Integration.WebApi;
using Swashbuckle.Application;

[assembly: OwinStartup(startupType: typeof(Startup))]

namespace Dp.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Formatters.JsonFormatter.SupportedMediaTypes
                  .Add(item: new MediaTypeHeaderValue("text/html"));

            WebApiConfig.Register(config: config);

            ConfigureIoC(config: config); // Dependency Injection

            ConfigureOAuth(app: app);
            app.UseCors(options: CorsOptions.AllowAll);
            app.UseWebApi(configuration: config);

            config
                .EnableSwagger(c =>
                               {
                                   c.SingleApiVersion("v1", "A title for your API");
                                   c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                               })
                .EnableSwaggerUi();
        }

        private void ConfigureIoC(HttpConfiguration config)
        {
            var container = DpIoCProvider.CreateRequestContainer();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container: container);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(options: OAuthServerOptions);
            app.UseOAuthBearerAuthentication(options: new OAuthBearerAuthenticationOptions());
        }
    }
}