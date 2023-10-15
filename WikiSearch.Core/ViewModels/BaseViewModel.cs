using System.Threading.Tasks;
using WikiSearch.API;
using WikiSearch.Core.Services;

namespace WikiSearch.Core.ViewModels
{
    public class BaseViewModel : Observable
    {
        protected IWikiService WikiService { get; } 

        public BaseViewModel()
        {
            WikiService = ViewModelLocator.Resolve<IWikiService>();
        }
        
        public virtual Task Initialize(object parameter) => Task.CompletedTask;
        public virtual Task Initialize() => Initialize(null);

    }
}