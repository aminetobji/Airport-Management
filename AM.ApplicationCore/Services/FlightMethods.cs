using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        //boucle for each 
        public void GetFlightDates(string dest)
        {
            foreach (var _flight in Flights)
            {
                if (dest == _flight.Destination)
                {
                    Console.WriteLine(_flight.FlightDate);
                    
                }
            }
        }
        //Methode en utlisant la notion linq
        public IEnumerable<DateTime> GetFlightDates_linq(string dest)
        {
            IEnumerable <DateTime> requete = from f in Flights
                                             where f.Destination==dest 
                                             select f.FlightDate;
            return requete;
        }
        
        public void GetFlights(string filterType, string filterValue)
        {
            IEnumerable<Flight> filteredFlights;

            switch (filterType.ToLower())
            {
                case "destination":
                    filteredFlights = Flights.Where(f => f.Destination.Equals(filterValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "departure":
                    filteredFlights = Flights.Where(f => f.Departure.Equals(filterValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "FlightId":
                    filteredFlights = Flights.Where(f => f.FlightId.ToString().Equals(filterValue, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    Console.WriteLine("Type de filtre non pris en charge.");
                    return;
            }

            if (filteredFlights.Any())
            {
                Console.WriteLine("Vols correspondants :");
                foreach (var flight in filteredFlights)
                {
                    Console.WriteLine(flight.ToString());
                }
            }
            else
            {
                Console.WriteLine("Aucun vol correspondant trouvé.");
            }

        }

        public void ShowFlightDetails(Plane plane)
        {
            var _filteredPlanes = Flights.Where(f => f.Plane.PlaneId == plane.PlaneId);
            Console.WriteLine("avions correspondants :");
            foreach (var flight in _filteredPlanes)
            {
                Console.WriteLine($"Numéro d'avion : {flight.Plane.PlaneId}, Destination : {flight.Destination}, Heure de départ : {flight.FlightDate}");
            }


        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //add fays ajout des jours dans le type date 
            //count pour les convertir en nombre 
            return Flights.Where(f => f.FlightDate >= startDate && f.FlightDate <= startDate.AddDays(7)).Count();
        }

        public double DurationAverage(string destination)
        {
            var destinationFlights = Flights.Where(f => f.Destination == destination);

            if (destinationFlights.Any())
            {
                return Flights.Where(f => f.Destination == destination).Average(f => f.EstimatedDuration);
            }
            else
            {
                return 0;// Aucun vol trouvé pour la destination spécifiée.
            }
        }

        public void OrderedDurationFlights()
        {
            //trier ordre decroisant 
            var filteredData = Flights.OrderByDescending(f => f.EstimatedDuration);
            foreach (var flight in filteredData)
            {
                Console.WriteLine(flight.ToString());
            }
        }

        //public  IEnumerable<Passenger> SeniorTravellers (Flight flight)
        //{
        //    //var requete = from f in flight.Passengers
        //    //              where f in Traveller 
        //    //              orderby BirthDate ascending
        //    //    select f;

        //    return  flight.Passengers
        //    .Where(passenger => passenger is Traveller)
        //    .OrderByDescending(traveller => traveller.BirthDate)
        //    .Take(3);

        //    //second method 
        //    //return flight.Passengers
        //    //.ofType<Traveller>().OrderByDesending(p=>p.birthdate).take(3);
        //}

        /// <summary>
        /// linq method using select
        /// </summary>
        
        //public IEnumerable<Passenger> Senior(Flight flight)
        //{
        //    return (from p in flight.Passengers.OfType<Traveller>() 
        //        orderby  p.BirthDate ascending
        //        select p).Take(3);
        //}

        public void DestinationGroupedFlights()
        {
            var filteredData = Flights.GroupBy(f => f.Destination);

            //parcours du group filtré 
            foreach (var group in filteredData)
            {
                Console.WriteLine("Destination " + group.Key);
                //parcours dans chaque element du group 
                foreach (var flight in group)
                {
                    Console.WriteLine("Décollage " + flight.FlightDate);
                }
            }
        }
    }
}
