using Serilog;

namespace SerilogWithMaui;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    //If you want to dispose that log for memory management
    //protected override void OnDisappearing()
    //{
    //    base.OnDisappearing();
    //    Log.CloseAndFlush();
    //}

    void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        var nums = $"Current count: {count}";
        CounterLabel.Text = nums;
        Log.Debug($"***** Current count: {nums}");
        Log.Error("show error: btn not working");
        SemanticScreenReader.Announce(CounterLabel.Text);
    }
 
}

