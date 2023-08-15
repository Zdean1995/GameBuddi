using GameBuddi.ViewModels;

namespace GameBuddi.Pages;

public partial class CompanyPage : ContentPage
{
	public CompanyPage()
	{
		InitializeComponent();
        BindingContext = new CompaniesViewModel();
    }
    async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
    {
        Console.WriteLine("Sign in button clicked");
        await Navigation.PushModalAsync(new CompanyDetailPage());
    }
}
