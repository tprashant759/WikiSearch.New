using System;
using Autofac;
using WikiSearch.API;

namespace WikiSearch
{
    public class AppContainer
    {
        private static IContainer container;

        public AppContainer()
        {
            // services
            var builder = new ContainerBuilder();
            builder.RegisterType<WikiService>().As<IWikiService>().SingleInstance();
            // builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            // builder.RegisterType<RepositoryService>().As<IRepositoryService>().SingleInstance();
            // builder.RegisterType<PreferenceService>().As<IPreferenceService>().SingleInstance();
            //
            // // view models
            // builder.RegisterType<MainViewModel>().SingleInstance();
            // builder.RegisterType<ActivitiesViewModel>().SingleInstance();
            // builder.RegisterType<ActivityRecordViewModel>().SingleInstance();
            // builder.RegisterType<HistoryViewModel>().SingleInstance();

            container = builder.Build();
        }

        public T Resolve<T>() => container.Resolve<T>();

        public object Resolve(Type type) => container.Resolve(type);
    }
}