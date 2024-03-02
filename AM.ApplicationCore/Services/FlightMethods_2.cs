using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods_2
    {

        public delegate void FlightDetailsDel(Plane plane);
        public delegate double DurationAverageDel(String data);

        //-------deuxieme methode 
        //public Action <plane> FlightDetailsDelM
        //public func<String,double>DurationAverageDel;
        public Func<String, double> DurationAverage;
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public FlightMethods_2()
        {
            DurationAverage = destination =>
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
            };

        }

    }
}

