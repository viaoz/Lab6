using System.Collections.ObjectModel;
using Lab6_Solution.Model;
using Lab6_Starter.Model;

namespace Lab6_Starter;

public partial class Map : ContentPage
{
    // Make sure that AirportPins is a public property
    public ObservableCollection<AirportPin> AirportPins { get; private set; }

    public Map()
    {
        InitializeComponent();
        AirportPins = MauiProgram.BusinessLogic.AirportPins;
        BindingContext = this; // Now binding to this Map instance itself which holds the public property
    }
}