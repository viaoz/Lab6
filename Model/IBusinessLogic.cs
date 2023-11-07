using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lab6_Solution.Model;

namespace Lab6_Starter.Model;
public interface IBusinessLogic
{
    ObservableCollection<AirportPin> AirportPins { get; set; }

    AirportAdditionError AddAirport(String id, String city, DateTime dateVisited, int rating);
    AirportDeletionError DeleteAirport(String id);
    AirportEditError EditAirport(String id, String city, DateTime dateVisited, int rating);
    Airport FindAirport(String id);
    String CalculateStatistics();
    ObservableCollection<Airport> GetAllAirports();
    ObservableCollection<Airport> GetWisconsinAirports();
}
