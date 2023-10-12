using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lab2_Solution.Model;

namespace Lab2_Solution
{
    public class UserInterface
    {
        IBusinessLogic bl;

        public UserInterface(IBusinessLogic bl)
        {
            this.bl = bl;
        }


        public void PrintMenu()
        {
            Boolean done = false;
            while (!done)
            {
                Console.WriteLine("\nMenu\n====");
                Console.WriteLine("1. List Airports ");
                Console.WriteLine("2. Add Airport");
                Console.WriteLine("3. Delete Airport");
                Console.WriteLine("4. Edit Airport");
                Console.WriteLine("5. Print Statistics");
                Console.WriteLine("6. Quit");
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: ListAirports(); break;
                    case 2: AddAirport(); break;
                    case 3: DeleteAirport(); break;
                    case 4: EditAirport(); break;
                    case 5: PrintStatistics(); break;
                    case 6: done = true; break;
                }
            }

            Console.WriteLine("Goodbye");
            System.Environment.Exit(0);
        }

        private void ListAirports()
        {
            Console.WriteLine("\nAirports\n=======");

            ObservableCollection<Airport> Airports = bl.GetAirports();
            foreach (Airport Airport in Airports)
            {
                Console.WriteLine("{0} - {1}, {2:dd/MM/yy}, {3}", Airport.Id, Airport.City, Airport.DateVisited, Airport.Rating);
            };

        }

        private void AddAirport()
        {
            String id;
            String city;
            DateTime dateVisited;
            int rating;

            Console.WriteLine("\nAdding Airport\n==============");

            Console.Write("Id: ");
            id = Console.ReadLine();

            Console.Write("City: ");
            city = Console.ReadLine();

            Console.Write("Date Visited(mm/dd/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out dateVisited))
            {
                Console.WriteLine("Illegal date, abandoning addition");
                return;
            }

            Console.Write("Rating: ");
            if (!int.TryParse(Console.ReadLine(), out rating))
            {
                Console.WriteLine("Illegal rating, abandoning addition");
                return;
            }


            AirportAdditionError result = bl.AddAirport(id, city, dateVisited, rating);
            if (result != AirportAdditionError.NoError)
            {
                Console.WriteLine("Error while adding Airport: {0}", result.ToString());
            }

        }


        private void DeleteAirport()
        {
            String id;

            Console.Write("Id: ");
            id = Console.ReadLine();

            AirportDeletionError result = bl.DeleteAirport(id);
            if (result != AirportDeletionError.NoError)
            {
                Console.WriteLine("Error while deleting Airport: {0}", result.ToString());
            }
        }

        private void EditAirport()
        {
            String id = "";
            String city = "";
            DateTime dateVisited;
            int rating;

            Console.Write("Id: ");
            id = Console.ReadLine();

            Airport AirportToEdit = bl.FindAirport(id);
            while (AirportToEdit == null)
            {
                Console.Write("Airport with Id {0} not found. Try again.\nId: ", id);
                id = Console.ReadLine();
                AirportToEdit = bl.FindAirport(id);
            }

            Console.WriteLine("\nEditing Airport\n==============");

            Console.Write("City: ");
            city = Console.ReadLine();

            Console.Write("Date Visited (mm/dd/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out dateVisited))
            {
                Console.WriteLine("Illegal date, abandoning editing");
                return;
            }

            Console.Write("Rating: ");
            if (!int.TryParse(Console.ReadLine(), out rating))
            {
                Console.WriteLine("Illegal rating, abandoning editing");
                return;
            }

            AirportEditError result = bl.EditAirport(id, city, dateVisited, rating);
            if (result != AirportEditError.NoError)
            {
                Console.WriteLine("Error while editing Airport: {0}");
            }

        }

        private void PrintStatistics()
        {
            Console.WriteLine(bl.CalculateStatistics());
        }


    }
}
