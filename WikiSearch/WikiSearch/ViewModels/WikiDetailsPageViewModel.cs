using System;
using System.Threading.Tasks;
using WikiSearch.Services;

namespace WikiSearch.ViewModels
{
    public class WikiDetailsPageViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Final URL where webview should point
        /// </summary>
        private string _wikiPageURL;
        public string WikiPageURL
        {
            get { return _wikiPageURL; }
            set { _wikiPageURL = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Wikipedia url to open page through page id
        /// </summary>
        const string WikiDetailURL= "http://en.wikipedia.org/?curid={0}";

        #endregion

        #region Commands



        #endregion

        #region Constructors

        public WikiDetailsPageViewModel(INavigationService navigationService):base(navigationService)
        {
        }

        /// <summary>
        /// Getting page ID from list page
        /// </summary>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        public override Task InitializeAsync(object navigationData)
        {
            WikiPageURL = string.Format(WikiDetailURL, (int)navigationData);
            return Task.CompletedTask;
        }


        #endregion

        #region Methods



        #endregion
    }
}
