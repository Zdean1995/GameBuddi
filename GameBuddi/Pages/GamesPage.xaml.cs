using GameBuddi.ViewModels;

namespace GameBuddi.Pages;

public partial class GamesPage : ContentPage
{
	public GamesPage(GamesViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}
