using GameBuddi.Pages;

namespace GameBuddi;

public partial class AppShell : Shell
{
	public AppShell()
	{
        InitializeComponent();

		Routing.RegisterRoute(nameof(GamesPage), typeof(GamesPage));
        Routing.RegisterRoute(nameof(GamesDetailPage), typeof(GamesDetailPage));
        Routing.RegisterRoute(nameof(CompanyPage), typeof(CompanyPage));
        Routing.RegisterRoute(nameof(CompanyDetailPage), typeof(CompanyDetailPage));
    }
}
