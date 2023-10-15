namespace WikiSearch.Core.ViewModels
{
    public class WikiDetailsViewModel : BaseViewModel
    {
        #region Properties

        private string _wikiPageURL;
        public string WikiPageURL
        {
            get { return _wikiPageURL;}
            set { _wikiPageURL = value; }
        }

        #endregion

        #region Commands



        #endregion

        #region Constructors

        public WikiDetailsViewModel(string wikiPageURL)
        {
            _wikiPageURL = wikiPageURL;
        }

        #endregion

        #region Methods



        #endregion
    }
}