using System;
using System.Threading.Tasks;
using WikiSearch.Core.Services;
using WikiSearch.Services;

namespace WikiSearch.ViewModels
{
    /// <summary>
    /// Base of all viewmodels
    /// </summary>
    public class BaseViewModel : Observable
    {
        public INavigationService NavigationService { get; }

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);

    }
}
