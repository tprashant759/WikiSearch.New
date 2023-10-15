using System;
using Autofac;
using WikiSearch.API;
using WikiSearch.Core.ViewModels;

namespace WikiSearch.Core.Services
{
    public class AppContainer
    {
        private static IContainer container;

        public AppContainer()
        {
            // services
            var builder = new ContainerBuilder();
            builder.RegisterType<WikiService>().As<IWikiService>().SingleInstance();

            // view models
            builder.RegisterType<WikiListViewModel>().SingleInstance();
            builder.RegisterType<WikiDetailsViewModel>().SingleInstance();

            container = builder.Build();
        }

        public T Resolve<T>() => container.Resolve<T>();

        public object Resolve(Type type) => container.Resolve(type);
    }
}