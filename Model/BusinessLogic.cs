using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lab6_Solution.Model;
using Lab6_Starter;

namespace Lab6_Starter.Model;


public class BusinessLogic : IBusinessLogic
{
    const int BRONZE_LEVEL = 42;
    const int SILVER_LEVEL = 84;
    const int GOLD_LEVEL = 128;


    IDatabase db;
    private readonly int MAX_RATING = 5;

    public ObservableCollection<Airport> Airports
    {
        get { return GetAllAirports(); }

    }
    public BusinessLogic(IDatabase? db)
    {
        this.db = db;
    }


    public Airport FindAirport(String id)
    {
        return db.SelectAirport(id);
    }

    private AirportAdditionError CheckAirportFields(String id, String city, DateTime dateVisited, int rating)
    {
        if (id.Length < 3 || id.Length > 4)
        {
            return AirportAdditionError.InvalidIdLength;
        }
        if (city.Length < 3)
        {
            return AirportAdditionError.InvalidCityLength;
        }
        if (rating < 1 || rating > MAX_RATING)
        {
            return AirportAdditionError.InvalidRating;
        }

        return AirportAdditionError.NoError;
    }


    public AirportAdditionError AddAirport(String id, String city, DateTime dateVisited, int rating)
    {

        var result = CheckAirportFields(id, city, dateVisited, rating);
        if (result != AirportAdditionError.NoError)
        {
            return result;
        }

        if (db.SelectAirport(id) != null)
        {
            return AirportAdditionError.DuplicateAirportId;
        }
        Airport airport = new Airport(id, city, dateVisited, rating);
        db.InsertAirport(airport);

        return AirportAdditionError.NoError;
    }

    public AirportDeletionError DeleteAirport(String id)
    {

        var entry = db.SelectAirport(id);

        if (entry != null)
        {
            AirportDeletionError success = db.DeleteAirport(entry);
            if (success == AirportDeletionError.NoError)
            {
                return AirportDeletionError.NoError;

            }
            else
            {
                return AirportDeletionError.DBDeletionError;
            }
        }
        else
        {
            return AirportDeletionError.AirportNotFound;
        }
    }


    public AirportEditError EditAirport(String id, String city, DateTime dateVisited, int rating)
    {

        var fieldCheck = CheckAirportFields(id, city, dateVisited, rating);
        if (fieldCheck != AirportAdditionError.NoError)
        {
            return AirportEditError.InvalidFieldError;
        }

        var airport = db.SelectAirport(id);
        airport.Id = id;
        airport.City = city;
        airport.DateVisited = dateVisited;
        airport.Rating = rating;

        AirportEditError success = db.UpdateAirport(airport);
        if (success != AirportEditError.NoError)
        {
            return AirportEditError.DBEditError;
        }

        return AirportEditError.NoError;
    }


    public String CalculateStatistics()
    {
        FlyWisconsinLevel nextLevel;
        int numAirportsUntilNextLevel;

        int numAirportsVisited = db.SelectAllAirports().Count;
        if(numAirportsVisited < BRONZE_LEVEL)
        {
            nextLevel = FlyWisconsinLevel.Bronze;
            numAirportsUntilNextLevel = BRONZE_LEVEL - numAirportsVisited;
        } else if(numAirportsVisited < SILVER_LEVEL)
        {
            nextLevel = FlyWisconsinLevel.Silver;
            numAirportsUntilNextLevel = SILVER_LEVEL - numAirportsVisited;
        } else if(numAirportsVisited < GOLD_LEVEL)
        {
            nextLevel = FlyWisconsinLevel.Gold;
            numAirportsUntilNextLevel = GOLD_LEVEL - numAirportsVisited;
        } else
        {
            nextLevel = FlyWisconsinLevel.None;
            numAirportsUntilNextLevel = 0;
        }

        return String.Format("{0} airport{1} visited; {2} airports remaining until achieving {3}",
              numAirportsVisited, numAirportsVisited != 1 ? "s" : "", numAirportsUntilNextLevel, nextLevel);
    }

    public ObservableCollection<AirportPin> AirportPins { get; set; }

    /// <summary>
    /// Gets Observable Collection of all visited Airports
    /// </summary>
    /// <returns></returns>
    public void CreateAirportPins()
    {
        //ObservableCollection<Airport> visited = GetVisitedAirports();
        //ObservableCollection<AirportPin> allWisconsinAirports = GetWisconsinAirports();

        // ToDo: Save data needed for AirportPin class
        ObservableCollection<AirportPin> mergedPins = new();

        // ToDo: Loop through visited airports
        // ToDo: For each airport in VISITED, copy matching airport from WisconsinAirports to ParsedAirportPins with VISITED being TRUE

        // Assign merged data to AirportPins
        this.AirportPins = mergedPins;

    }

    /// <summary>
    /// Gets Observable Collection of all Wisconsin Airports
    /// </summary>
    /// <returns>ToDo</returns>
    public ObservableCollection<Airport> GetAllAirports()
    {
        return db.SelectAllAirports();
    }

    /// <summary>
    /// Gets Observable Collection of all unvisited Airports
    /// </summary>
    /// <returns></returns>
    public ObservableCollection<Airport> GetWisconsinAirports()
    {
        // ToDo: Gets all wisconsin airports from Wisconsin-Airports.xlms
        // ToDo: Collects only relevant data (SEE BELOW)
        // ------ * AirportName = "LOC_ID"
        // ------ * AirportLocation = Location("LAT", "LONG_")
        // ------ * Facility Name = "FAC_NM"
        // ------ * Visited = false // until merged with Visited Airports!

        // ToDo: Returns collection of wisconsin airports as pins
        return new();

    }
}

