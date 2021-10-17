using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace FootyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StadiumsDB_Page : ContentPage
    {
        //  public ObservableCollection<Stadium> StadiumCollection { get; set }
        public StadiumsDB_Page()
        {
            InitializeComponent();

            
            /* StadiumCollection = new ObservableCollection<Stadium>(App.BaseStadium.GetStadiumsAsync());*/

            // StadiumView.ItemsSource = App.BaseStadium.GetStadiumsAsync();

            // bool StadiumsDB_Page_FieldTypeFilter_Changed = false;
            // bool StadiumsDB_Page_FieldSizeFilter_Changed = false;
        }

        public static class Check_StadiumDB
        {
            public static bool TypeFieldChanged { get; set; }
            public static bool SizeFieldChanged { get; set; }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            StadiumView.ItemsSource = await App.BaseStadium.GetStadiumsAsync();
            Check_StadiumDB.TypeFieldChanged = false;
            Check_StadiumDB.SizeFieldChanged = false;
        }

        async void StadiumsDB_Page_Picker_FieldTypeFilter_Changed(object sender, EventArgs e)
        {
            Check_StadiumDB.TypeFieldChanged = true;
            if (!Check_StadiumDB.SizeFieldChanged)
            {
                StadiumView.ItemsSource = await App.BaseStadium.GetStadiumsFromTypeAsync(StadiumsDB_Page_Picker_FieldTypeFilter.Items[StadiumsDB_Page_Picker_FieldTypeFilter.SelectedIndex]);

            }   
            else
            {
                StadiumView.ItemsSource = await App.BaseStadium.GetStadiumsFromTypeAndSizeAsync(StadiumsDB_Page_Picker_FieldTypeFilter.Items[StadiumsDB_Page_Picker_FieldTypeFilter.SelectedIndex], int.Parse(StadiumsDB_Page_Picker_FieldSizeFilter.Items[StadiumsDB_Page_Picker_FieldSizeFilter.SelectedIndex]));
            }
        }
        async void StadiumsDB_Page_Picker_FieldSizeFilter_Changed(object sender, EventArgs e)
        {
            Check_StadiumDB.SizeFieldChanged = true;
            if (!Check_StadiumDB.TypeFieldChanged)
            {
                StadiumView.ItemsSource = await App.BaseStadium.GetStadiumsFromSizeAsync(int.Parse(StadiumsDB_Page_Picker_FieldSizeFilter.Items[StadiumsDB_Page_Picker_FieldSizeFilter.SelectedIndex]));

            }
            else
            {
                StadiumView.ItemsSource = await App.BaseStadium.GetStadiumsFromTypeAndSizeAsync(StadiumsDB_Page_Picker_FieldTypeFilter.Items[StadiumsDB_Page_Picker_FieldTypeFilter.SelectedIndex], int.Parse(StadiumsDB_Page_Picker_FieldSizeFilter.Items[StadiumsDB_Page_Picker_FieldSizeFilter.SelectedIndex]));
            }
        }
    }
}