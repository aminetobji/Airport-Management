using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        //Question 3 Tp5
        public  virtual double prix { get; set; }
        public virtual int Siege { get; set; }
        public virtual Boolean Vip { get; set; }

        public virtual Flight MyFlight { get; set; }

        public virtual Passenger MyPassenger { get; set; }

        [ForeignKey("MyPassenger")]
        public string PassengerFk { get; set; }
        [ForeignKey("MyFlight")]

        public int FlightFK { get; set; }

    }
}
