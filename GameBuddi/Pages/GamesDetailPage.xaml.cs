using GameBuddi.ViewModels;

namespace GameBuddi.Pages;

public partial class GamesDetailPage : ContentPage
{
	private GameDetailViewModel _viewModel;
	public GamesDetailPage(GameDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		_viewModel = vm;
	}
}
