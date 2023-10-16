using System;
using Autofac;
using WikiSearch.API;
using WikiSearch.Core.Services;
using WikiSearch.ViewModels;

namespace WikiSearch.Services
{
    /// <summary>
    /// IOC container builder which register dependencies
    /// </summary>
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // View Models
            builder.RegisterType<WikiListPageViewModel>().AsSelf();
            builder.RegisterType<WikiDetailsPageViewModel>().AsSelf();

            // Services
            builder.RegisterType<WikiService>().As<IWikiService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<TypeMapperService>().As<ITypeMapperService>().SingleInstance();
        }
    }
}
