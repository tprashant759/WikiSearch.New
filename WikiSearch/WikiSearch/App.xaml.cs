using System;
using System.Threading.Tasks;
using Autofac;
using WikiSearch.API;
using WikiSearch.Services;
using WikiSearch.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace WikiSearch
{
    public partial class App : Application
    {
        public DependencyResolver DependencyResolver { get; }

        public App(Module platformIocModule)
        {
            InitializeComponent();
            DependencyResolver = new DependencyResolver(platformIocModule, new IocModule());
            MainPage = new NavigationPage(new WikiListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}