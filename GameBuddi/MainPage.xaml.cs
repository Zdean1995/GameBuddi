using GameBuddi.Pages;

namespace GameBuddi;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void SignInButton_Clicked(object sender, System.EventArgs e)
    {
        // Handle sign-in logic here
        // Example: Check username and password, authenticate user

        // For demonstration purposes, we'll simply navigate to another page
        Console.WriteLine("Sign in button clicked");

        await Navigation.PushModalAsync(new GamesPage());
    }
}

