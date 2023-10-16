using System;
using System.Threading.Tasks;
using WikiSearch.ViewModels;
using Xamarin.Forms;

namespace WikiSearch.Services
{
    /// <summary>
    /// Navigation service that provides push-pop navigation support
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Push a page using viewmodel
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="parameter"></param>
        /// <param name="animated"></param>
        /// <returns></returns>
        Task PushAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel;

        /// <summary>
        /// Normal push of page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="animated"></param>
        /// <returns></returns>
        Task PushAsync(Page page, bool animated = true);

        /// <summary>
        /// Pop current page
        /// </summary>
        /// <param name="animated"></param>
        /// <returns></returns>
        Task PopAsync(bool animated = true);

        /// <summary>
        /// Push a modal dialogue using viewmodel
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="parameter"></param>
        /// <param name="animated"></param>
        /// <returns></returns>
        Task PushModalAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel;

        /// <summary>
        /// Pop current modal dialogue
        /// </summary>
        /// <param name="animated"></param>
        /// <returns></returns>
        Task PopModalAsync(bool animated = true);
    }
}
