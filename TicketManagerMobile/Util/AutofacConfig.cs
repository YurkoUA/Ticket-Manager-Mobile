using Windows.Security.Credentials;
using Autofac;
using TicketApi.Interfaces;
using TicketApi.Services;

namespace TicketManagerMobile.Util
{
    public static class AutofacConfig
    {
        private static IContainer container;

        static AutofacConfig()
        {
            var builder = new ContainerBuilder();
            builder.RegisterHttpService();
            builder.RegisterDependencies();

            container = builder.Build();
        }

        private static void RegisterHttpService(this ContainerBuilder builder)
        {
#if DEBUG
            var baseUrl = "http://tms-test2.somee.com/";
#else
            var baseUrl = "http://ticket-ms.somee.com/";
#endif

            builder.RegisterType<HttpService>().As<IHttpService>()
                .WithParameter("baseAddress", baseUrl)
                .WithParameter("userAgent", "TicketManagerMobile (UWP)")
                .SingleInstance();
        }

        private static void RegisterDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<CredentialService>()
                .As<ICredentialService>()
                .WithParameter("vault", new PasswordVault())
                .WithParameter("resourceName", "TicketManagerMobile")
                .SingleInstance();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .SingleInstance();

            builder.RegisterType<AuthenticationService>()
                .As<IAuthenticationService>()
                .SingleInstance();

            builder.RegisterType<NavigationService>()
                .As<INavigationService>()
                .SingleInstance();

            builder.RegisterType<ColorService>()
                .As<IColorService>()
                .SingleInstance();

            builder.RegisterType<SerialService>()
                .As<ISerialService>()
                .SingleInstance();
        }

        public static T Resolve<T>()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                return scope.Resolve<T>();
            }
        }
    }
}
