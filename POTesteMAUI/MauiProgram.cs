﻿using POTesteMAUI.Services;

namespace POTesteMAUI;

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
		DependencyService.Register<IMessage, Message>();
		//builder.Services.AddTransient<IMessage, Message>();
		return builder.Build();
	}
}
