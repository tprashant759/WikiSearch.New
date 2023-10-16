using System;
using System.Threading.Tasks;
using WikiSearch.ViewModels;
using Xamarin.Forms;

namespace WikiSearch.Services
{
    public class NavigationService : INavigationService
    {
        ITypeMapperService mapperService { get; }

        public NavigationService(ITypeMapperService mapperService)
        {
            this.mapperService = mapperService;
        }

        /// <summary>
        /// Creates instance of page using viewmodel and mapper
        /// </summary>
        /// <param name="viewModelType"></param>
        /// <returns></returns>
        protected Page CreatePage(Type viewModelType)
        {
            Type pageType = mapperService.MapViewModelToView(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            return Activator.CreateInstance(pageType) as Page;
        }

        /// <summary>
        /// Retuens current main page
        /// </summary>
        /// <returns></returns>
        protected Page GetCurrentPage()
        {
            return Application.Current.MainPage;

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Task PushAsync(Page page, bool animated = true)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            return navigationPage.PushAsync(page, animated);

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Task PopAsync(bool animated = true)
        {
            var mainPage = Application.Current.MainPage as NavigationPage;
            return mainPage.Navigation.PopAsync(animated);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Task PushModalAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel =>
            InternalPushModalAsync(typeof(TViewModel), animated, parameter);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Task PushAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel =>
          InternalPushAsync(typeof(TViewModel), animated, parameter);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Task PopModalAsync(bool animated = true)
        {
            var mainPage = GetCurrentPage();
            if (mainPage != null)
                return mainPage.Navigation.PopModalAsync(animated);

            throw new Exception("Current page is null.");
        }

        /// <summary>
        /// Internal method to push modal from viewmodel reference
        /// </summary>
        /// <param name="viewModelType"></param>
        /// <param name="animated"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        async Task InternalPushModalAsync(Type viewModelType, bool animated, object parameter)
        {
            var page = CreatePage(viewModelType);
            var currentNavigationPage = GetCurrentPage();

            if (currentNavigationPage != null)
            {
                await currentNavigationPage.Navigation.PushModalAsync(page, animated);
            }
            else
            {
                throw new Exception("Current page is null.");
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        /// <summary>
        /// Internal method to push page using viewmodel reference
        /// </summary>
        /// <param name="viewModelType"></param>
        /// <param name="animated"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        async Task InternalPushAsync(Type viewModelType, bool animated, object parameter)
        {
            var page = CreatePage(viewModelType);
            var currentNavigationPage = GetCurrentPage();

            if (currentNavigationPage != null)
            {
                await currentNavigationPage.Navigation.PushAsync(page, animated);
            }
            else
            {
                throw new Exception("Current page is null.");
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }
    }
}
