using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WikiSearch.API;
using WikiSearch.Models;
using Xamarin.Forms;

namespace WikiSearch.Core.ViewModels
{
    public class WikiListViewModel : BaseViewModel
    {
        #region Properties

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value;
                RefreshSearchEntries();
            }
        }

        private ObservableCollection<WikiEntries> _wikiEntries;

        public ObservableCollection<WikiEntries> WikiEntries
        {
            get { return _wikiEntries; }
            set { _wikiEntries = value; }
        }

        public IWikiService WikiService { get; set; }
        #endregion

        #region Commands

        public ICommand WikiEntryPressedCommand { get; set; }

        #endregion

        #region Constructors

        public WikiListViewModel(IWikiService wikiService)
        {
            WikiService = wikiService;
            _wikiEntries = new ObservableCollection<WikiEntries>();
            WikiEntryPressedCommand = new Command(EntryPressedAction);
        }

        #endregion

        #region Methods

        public void EntryPressedAction(object obj)
        {
            
        }


        private async Task RefreshSearchEntries()
        {
            var result = await WikiService.GetWikiEntriesList(_searchText);
            if (result != null)
            {
                _wikiEntries = new ObservableCollection<WikiEntries>(result);
            }
        }

        #endregion
    }
}