namespace Lab6_Starter;

public partial class PlanningTools : ContentPage
{
	public PlanningTools()
	{
		InitializeComponent();
	}

    private async void NearByAirports_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NearByAirports());
    }
}