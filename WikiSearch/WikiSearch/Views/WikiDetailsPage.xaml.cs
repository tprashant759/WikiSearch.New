using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiSearch.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WikiDetailsPage : ContentPage
    {
        public WikiDetailsPage()
        {
            InitializeComponent();
            this.BindingContext = new WikiDetailsViewModel(string.Empty);
        }
    }
}