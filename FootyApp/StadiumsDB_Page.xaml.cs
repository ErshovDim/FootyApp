using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StadiumsDB_Page : ContentPage
    {
        public StadiumsDB_Page()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            StadiumView.ItemsSource = await App.BaseStadium.GetStadiumsAsync();
        }
    }
}