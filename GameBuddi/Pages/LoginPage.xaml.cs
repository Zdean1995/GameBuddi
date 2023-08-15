using Microsoft.Maui.Controls;

namespace GameBuddi
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void SignInButton_Clicked(object sender, System.EventArgs e)
        {
            // Handle sign-in logic here
            // Example: Check username and password, authenticate user

            // For demonstration purposes, we'll simply navigate to another page
            await Navigation.PushAsync(new MainPage());
        }
    }
}
