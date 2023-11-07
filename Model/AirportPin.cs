using System;
using System.ComponentModel;
using Lab6_Starter.Model;
using static Java.Util.Jar.Attributes;

namespace Lab6_Solution.Model
{
	public class AirportPin : INotifyPropertyChanged
	{
        public string AirportName { get; set; }
        public Location AirportLocation { get; set; }
        public string FacilityName { get; set; }
        public bool Visited { get; set; }


        public AirportPin()
		{
            AirportName = "";
            AirportLocation = new Location();
            FacilityName = "";
            Visited = false;
        }

		public AirportPin(string name, Location location, string facility, bool visitedStatus)
		{
            AirportName = name; // In Wisconsin-Airports.xlsx: LOC_ID
            AirportLocation = location; // In Wisconsin-Airports.xlsx: LAT, LONG_
            FacilityName = facility; // In Wisconsin-Airports.xlsx: FAC_NM
            Visited = visitedStatus; // True if airportName is in the visitedAirports collection
		}

        // ToDo
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

