using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServicePassenger : Service<Passenger>, IServicePassenger
    {

        IUnitOfWork UnitOfWork { get; set; }

        public ServicePassenger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.UnitOfWork=unitOfWork;
        }

        public IEnumerable<Passenger> GetPassengerByDate(DateTime date , Plane plane)
        {
            //Retourner la liste des voyageurs qui ont voyagé dans un avion donné à une date
            // donnée.
            return this.UnitOfWork.Repository<Flight>().
                GetMany(f=>f.FlightDate==date&&f.PlaneId==plane.PlaneId)
                .SelectMany(f=>f.TicketList).Select(t=>t.MyPassenger).OfType<Traveller>();


        }


    }
}
