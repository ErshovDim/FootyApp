using System;
using Xamarin.Forms;
using System.IO;

namespace FootyApp
{
    public partial class App : Application
    {
        static BaseStadium basestadium;

        public static BaseStadium BaseStadium
        {
            get
            {
                if (basestadium == null)
                {
                    basestadium = new BaseStadium(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Stadiums.db3"));
                }
                return basestadium;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}