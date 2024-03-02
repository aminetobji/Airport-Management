using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane: Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        //Retourner les voyageurs d’un avion passé en paramètre.
        public IList<Passenger> getPassengers(Plane plane)
        {
            
            return GetById(plane.PlaneId).Flights.SelectMany(f => f.TicketList.Select(t => t.MyPassenger)).ToList();
        }

        //Retourner les vols ordonnés par date de départ des n derniers avions.
        public IList<Flight> getFlights(int n)
        {
            return GetAll().OrderBy(p => p.PlaneId).Take(n).SelectMany(p => p.Flights).ToList();
        }

        //Retourner true si on peut réserver n places à un vol passé en paramètre.
        public bool AvailablePlane(int n, Flight flight)
        {
            var capacity = Get(p => p.Flights.Contains(flight) == true).Capacity;
            var nbrPassager = flight.TicketList.Count;
            return capacity >= nbrPassager;
        }

        //Supprimer tous les avions dont la date de fabrication a dépassé 10 ans.
        public void DeletePlane()
        {

            foreach (var plane in GetAll().Where(p => (DateTime.Now - p.ManufactureDate).TotalDays > 365 * 10).ToList())
            {
                Delete(plane);
                Commit();
            }
        }
    }

}
