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
        AlertService = Services.GetService<IAlertService>();
        MainPage = new MainPage();
    }
    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);
        window.Page = MainPage;
        window.Destroying += Window_Destroying;
        return window;
    }
    
    private void Window_Destroying(object sender, EventArgs e)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine("Destroying");
           App.Current.Dispatcher.Dispatch(async()=>
           await App.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to close the application.", "Yes", "No"));
            
        }
        catch (Exception)
        {
        }
    }

}
