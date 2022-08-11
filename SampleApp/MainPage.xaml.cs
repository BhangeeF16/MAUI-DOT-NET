using Microsoft.Maui.Platform;

namespace SampleApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
           
	}

    private void OnCounterClicked(object sender, EventArgs e)
	{
        ////count++;

        ////if (count == 1)
        ////    CounterBtn.Text = $"Clicked {count} time";
        ////else
        ////    CounterBtn.Text = $"Clicked {count} times";

        ////SemanticScreenReader.Announce(CounterBtn.Text);
        //App.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to close the application.", "Yes", "No");

    }
}

