using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiSearch.API;
using WikiSearch.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WikiListPage : ContentPage
    {
        public WikiListPage()
        {
            InitializeComponent();
        }
    }
}