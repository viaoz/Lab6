
namespace Lab6_Starter; 
public partial class Map : ContentPage
{
	public Map()
	{
		InitializeComponent();
	}


    /// <summary>
    /// Calls DisplayAllAirports to display a pin for every airport when map is established
    /// </summary>
    protected override void OnAppearing()
    {
        DisplayAllAirports();
    }
    /// <summary>
    /// Calls BusinessLogic to get all airports and displays every airport as a pin on map
    /// </summary>
    private void DisplayAllAirports()
	{
		//Might Call Details Popup on Click of Pin
	}

    /// <summary>
    /// Calls BusinessLogic to get airports that are not visited and displays the airports as a pin on map
    /// </summary>
    private void DisplayUnvisitedAirports()
	{

	}

    /// <summary>
    /// Calls BusinessLogic to get airports that are visited and displays the airports as a pin on map
    /// </summary>
    private void DisplayVisitedAirports()
	{

	}

}