﻿using Microsoft.Extensions.Logging;

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

        builder.Services.AddSingleton<HomePage>();

        builder.Services.AddTransient<SampleDataService>();
        builder.Services.AddTransient<GamesDetailViewModel>();
        builder.Services.AddTransient<GamesDetailPage>();

        builder.Services.AddSingleton<GamesViewModel>();

        builder.Services.AddSingleton<GamesPage>();

        return builder.Build();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
