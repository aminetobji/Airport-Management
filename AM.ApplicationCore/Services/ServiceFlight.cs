using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight:Service<Flight>,IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //- Retourner la liste des staffs d’un vol dont son identifiant est passé en paramètre.
        public IEnumerable<Staff> GetStaff(int idFlight)
        {
            return GetById(idFlight).TicketList.Select(t => t.MyPassenger).OfType<Staff>();
        }
        //Retourner le nombre de vols par date 
        public int GetNbTraveller(DateTime startDateTime, DateTime enDateTime)
        {
            return GetMany(f=>f.FlightDate>=enDateTime && f.FlightDate<=enDateTime)
                .SelectMany(f=>f.TicketList).Select(t=>t.MyPassenger).Count();
        }

        public void GetGroupTraveller(DateTime startDateTime, DateTime enDateTime)
        {
           var Query =  GetMany(f => f.FlightDate >= enDateTime && f.FlightDate <= enDateTime)
                .SelectMany(f => f.TicketList).GroupBy(t=>t.MyFlight.FlightDate)
                .Select(t=> new {group = t.Key, nbr= t.Count() });

            foreach (var e in Query)
            {
                Console.WriteLine(" Date de vol est "+e.group+"le nombre de vol est "+e.nbr);
            }
        }
    }
}
