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
        MainPage = new MainPage();

    }

	protected override Window CreateWindow(IActivationState activationState)
	{
		var window = base.CreateWindow(activationState);
		window.Created += Window_Created;
		window.Destroying += Window_Destroying;
		window.Stopped += Window_Stopped;
		window.Deactivated += Window_Deactivated;
		return window;
	}

	private void Window_Deactivated(object sender, EventArgs e)
	{
		System.Diagnostics.Debug.WriteLine("Deactivated");

        Application.Current.MainPage.DisplayAlert("Deactivated", "On Deactivated", "Ok");
    }

	private void Window_Stopped(object sender, EventArgs e)
	{
        System.Diagnostics.Debug.WriteLine("Stopped");

        Application.Current.MainPage.DisplayAlert("Stopped", "On Stopped", "Ok");
    }

	private void Window_Destroying(object sender, EventArgs e)
	{
        System.Diagnostics.Debug.WriteLine("Destroying");

        Application.Current.MainPage.DisplayAlert("Destroying", "On Destroying", "Ok");
    }

	private void Window_Created(object sender, EventArgs e)
	{
        System.Diagnostics.Debug.WriteLine("Created");
        //Application.Current.MainPage.DisplayAlert("Created", "On Creating", "Ok");
        //AlertService.ShowAlert("created", "On Created");       
    }
}
