using Microsoft.Extensions.Logging;
using GameBuddi.Views;
using GameBuddi.Viewmodels;

namespace GameBuddi;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<HomeViewModel>();

        builder.Services.AddSingleton<GamesPage>();
        builder.Services.AddSingleton<GamesViewModel>();

        builder.Services.AddSingleton<HomePage>();

        builder.Services.AddTransient<GamesDetailViewModel>();
        builder.Services.AddTransient<GamesDetailPage>();


        return builder.Build();
	}
}
