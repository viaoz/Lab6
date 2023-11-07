using System.Collections.ObjectModel;
using Lab6_Solution.Model;
using Lab6_Starter.Model;

namespace Lab6_Starter;

public partial class Map : ContentPage
{
	public Map()
	{
		InitializeComponent();
        BindingContext = MauiProgram.BusinessLogic;
    }

    private readonly ObservableCollection<AirportPin> AirportPins = MauiProgram.BusinessLogic.AirportPins;
}