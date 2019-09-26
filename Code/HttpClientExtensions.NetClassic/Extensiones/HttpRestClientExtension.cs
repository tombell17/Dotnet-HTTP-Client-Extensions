using Framework.ClienteHttp.Abstractions;
using Framework.ClienteHttp.NetClassic.Factory;
using Ninject.Modules;
using System;
using System.Net.Http;

namespace Framework.ClienteHttp.NetClassic.Extensiones
{
    public static class HttpRestClientExtension
    {
        public static void AddHttpRestClient<TService, TImplementation>(this NinjectModule module, string httpClientName, Action<HttpClient> configureHttpClient)
            where TService : class
            where TImplementation : class, TService
        {
            module.Bind<TService>()
                  .To<TImplementation>();

            module.Bind<IHttpRestClient>()
                  .To<HttpRestClient>()
                  .WhenInjectedInto(typeof(TImplementation))
                  .WithConstructorArgument("name", httpClientName)
                  .WithConstructorArgument("configureHttpClient", configureHttpClient);
        }

        public static void AddHttpRestClientFactory(this NinjectModule module)
        {
            module.Bind<IHttpRestClientFactory>()
                  .To<HttpRestClientFactory>()
                  .InSingletonScope();
        }
    }
   
}
