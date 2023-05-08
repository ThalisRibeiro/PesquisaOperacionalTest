using POTesteMAUI.Services;
using System;

namespace POTesteMAUI;

public partial class App : Application
{
	//public static IServiceProvider service;
	//public static IMessage AlertSvc;
	public App(IServiceProvider provider)
	{
		InitializeComponent();
		//service = provider;
		//AlertSvc = service.GetService<IMessage>();

		MainPage = new AppShell();
	}
}
