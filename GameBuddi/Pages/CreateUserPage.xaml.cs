using GameBuddi.ViewModels;

namespace GameBuddi.Pages;

public partial class CreateUserPage : ContentPage
{
	public CreateUserPage(CreateUserViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}