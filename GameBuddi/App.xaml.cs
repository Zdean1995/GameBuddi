using GameBuddi.Pages;

namespace GameBuddi;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
