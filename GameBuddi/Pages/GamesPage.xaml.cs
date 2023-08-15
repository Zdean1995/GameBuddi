using GameBuddi.ViewModels;
using Xamarin.Google.Crypto.Tink.Mac;

namespace GameBuddi.Pages;

public partial class GamesPage : ContentPage
{
	public GamesPage()
	{
		InitializeComponent();
        BindingContext = new GamesViewModel(Navigation);
    }
    private async void GoToCompanyPage(object sender, System.EventArgs e)
    {
        // Handle sign-in logic here
        // Example: Check username and password, authenticate user

        // For demonstration purposes, we'll simply navigate to another page
        Console.WriteLine("Sign in button clicked");

        await Navigation.PushModalAsync(new CompanyPage());
    }
    async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
    {
        Console.WriteLine("Sign in button clicked");
        await Navigation.PushModalAsync(new GamesDetailPage());
    }

}
