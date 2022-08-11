using SampleApp.Services;

namespace SampleApp;

public partial class App : Application
{
	public static IServiceProvider Services;
    public static IAlertService AlertService;

    public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
	    

		Services = serviceProvider;
		AlertService=Services.GetService<IAlertService>();
        MainPage = new AppShell();

    }

}
