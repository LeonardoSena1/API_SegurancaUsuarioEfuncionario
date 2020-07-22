using API_Seguranca.Context;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(API_Seguranca.Startup))]

namespace API_Seguranca
{
    public class Startup
    {
        private void AtivarGeracaoTokenAcesso(IAppBuilder app)
        {
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                //gual a true, permitindo assim o acesso ao endereço que gera o token de acesso sem a necessidade de usar HTTPS;
                AllowInsecureHttp = true,
                //Define o endereço que fornece o token de acesso. Deve iniciar com uma barra /token;
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new ProviderDeTokensDeAcesso()
            };
            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public void Configuration(IAppBuilder app)
        {
            // configuracao WebApi
            var config = new HttpConfiguration();
            // configurando rotas
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional }
             );
            // ativando cors
            app.UseCors(CorsOptions.AllowAll);

            // ativando a geração do token
            AtivarGeracaoTokenAcesso(app);

            // ativando configuração WebApi
            app.UseWebApi(config);
        }
    }
}
