using System;
using Xamarin.Forms;

namespace FootyApp
{
    public partial class NewStadiumToBase : ContentPage
    {
        public NewStadiumToBase()
        {
            Title = "BaseTest";
            Button backButton = new Button
            {
                Text = "Back",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            backButton.Clicked += BackNewStadiumButton_Click;
            Content = backButton;       
            InitializeComponent();
        }

    

        async void AddStadium_OnClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LocationEntry.Text) && !string.IsNullOrWhiteSpace(SizeEntry.Text) && !string.IsNullOrWhiteSpace(DescriptionEntry.Text) && !string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                if (Int64.TryParse(SizeEntry.Text, out long number))
                {                   
                    if (FieldTypePicker.SelectedIndex > 0)
                    {
                        SizeEntry.PlaceholderColor = Color.Black;                        
                        SizeEntry.Placeholder = "Enter Size(Number of maximum players)";
                        await App.BaseStadium.SaveStadiumAsync(new Stadium
                        {
                            Name = NameEntry.Text,
                            Location = LocationEntry.Text,
                            Size = int.Parse(SizeEntry.Text),
                            Description = DescriptionEntry.Text,
                            Type = FieldTypePicker.Items[FieldTypePicker.SelectedIndex]
                        });
                        NameEntry.Text = SizeEntry.Text = LocationEntry.Text = DescriptionEntry.Text = string.Empty;
                        Button button = (Button)sender;
                        button.Text = "Done!";
                        button.BackgroundColor = Color.LightGreen;

                        
                    }
                    else
                    {
                        FieldTypePicker.TitleColor = Color.FromRgb(225, 0, 0);
                    }
                }
                else
                {
                    SizeEntry.PlaceholderColor  = Color.FromRgb(225, 0, 0);
                    SizeEntry.Text  = "";
                    SizeEntry.Placeholder = "Size must be integer";


                }
            }
        }
        
        private async void BackNewStadiumButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        void FieldTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}


