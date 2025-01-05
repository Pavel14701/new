using Autofac;
using System;
using System.Threading.Tasks;

namespace SalesApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Создание контейнера Autofac
            var builder = new ContainerBuilder();

            // Регистрация зависимостей
            builder.RegisterType<Service>().As<IService>().SingleInstance();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<Notifier>().As<INotifier>().SingleInstance();
            builder.RegisterType<SalesDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseService>().As<IDatabaseService>().InstancePerLifetimeScope();
            builder.RegisterType<EmailService>().As<IEmailService>().SingleInstance();
            builder.RegisterType<ExternalService>().As<IExternalService>().SingleInstance();
            builder.RegisterType<Client>().InstancePerDependency();

            // Создание Autofac контейнера
            var container = builder.Build();

            // Разрешение зависимости и использование клиента
            using (var scope = container.BeginLifetimeScope())
            {
                var client = scope.Resolve<Client>();
                await client.PerformActionAsync();
            }
        }
    }
}
