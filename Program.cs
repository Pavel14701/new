using Autofac;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Создание контейнера Autofac
        var builder = new ContainerBuilder();

        // Регистрация зависимостей
        builder.RegisterType<Service>().As<IService>().SingleInstance();
        builder.RegisterType<Client>().InstancePerDependency();

        // Создание Autofac контейнера
        var container = builder.Build();

        // Разрешение зависимости и использование клиента
        using (var scope = container.BeginLifetimeScope())
        {
            var client = scope.Resolve<Client>();
            client.PerformAction();
        }
    }
}
