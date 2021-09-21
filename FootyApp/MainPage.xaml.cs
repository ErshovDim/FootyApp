using System;
using Xamarin.Forms;

namespace FootyApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Main";
            InitializeComponent();
        }

        private async void NewStadium_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewStadiumToBase());
        }
        private async void StadiumBDPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StadiumsDB_Page());
        }
    }
}