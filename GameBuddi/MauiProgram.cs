using GameBuddi.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<GamesViewModel>();
        builder.Services.AddSingleton<CompaniesViewModel>();

        builder.Services.AddTransient<GameDetailViewModel>();
        builder.Services.AddTransient<CompanyDetailViewModel>();

        return builder.Build();
	}
}
