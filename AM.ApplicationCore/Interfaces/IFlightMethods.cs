using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        public void GetFlightDates(string dest);
        public void GetFlights(string filterType, string filterValue);
        public void DestinationGroupedFlights();
        public void OrderedDurationFlights();
        public double DurationAverage(string destination);
        public void ShowFlightDetails(Plane plane);

        public int ProgrammedFlightNumber(DateTime startDate);





    }
}
