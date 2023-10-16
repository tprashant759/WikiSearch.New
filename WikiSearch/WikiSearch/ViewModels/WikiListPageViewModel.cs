using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using WikiSearch.API;
using WikiSearch.Models;
using WikiSearch.Services;
using Xamarin.Forms;

namespace WikiSearch.ViewModels
{
    public class WikiListPageViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Search text which should go to service to fetch list of matching result
        /// </summary>
        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                RefreshSearchEntries();
            }
        }

        /// <summary>
        /// List of wikipedia entries
        /// </summary>
        private ObservableCollection<Search> _wikiEntries;

        public ObservableCollection<Search> WikiEntries
        {
            get { return _wikiEntries; }
            set { _wikiEntries = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Reference to WikiService
        /// </summary>
        public IWikiService WikiService { get; set; }
        #endregion

        #region Commands

        /// <summary>
        /// Command to be fired when an item is tapped , in order to open details page
        /// </summary>
        public ICommand WikiItemPressedCommand { get; set; }

        #endregion

        #region Constructors

        public WikiListPageViewModel(IWikiService wikiService , INavigationService navigationService) : base(navigationService)
        {
            WikiService = wikiService;
            _wikiEntries = new ObservableCollection<Search>();
            WikiItemPressedCommand = new Command(ItemPressedAction);
        }

        #endregion

        #region Methods

        public void ItemPressedAction(object obj)
        {
            NavigationService.PushAsync<WikiDetailsPageViewModel>((obj as Search).pageid);
        }

        /// <summary>
        /// Refresh wikipedia entries based on change of search text
        /// </summary>
        /// <returns></returns>
        private async Task RefreshSearchEntries()
        {
            var result = await WikiService.GetWikiEntriesList(_searchText);
            if (result != null)
            {
                var entryList = new ObservableCollection<WikiEntries>(result);
                WikiEntries = new ObservableCollection<Search>(entryList.FirstOrDefault().query.search);

                foreach(var item in WikiEntries)
                {
                    item.snippet = StripHTML(item.snippet);
                }
            }
        }

        /// <summary>
        /// Strip HTML tags from given string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        #endregion
    }
}
