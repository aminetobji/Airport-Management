using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AM.ApplicationCore.Domain
{
    public class Traveller: Passenger
    {
        [DataType(DataType.EmailAddress)]
        [Column("Adresse Mail")]
        [MaxLength(30)]
        public string Email { get; set; }
        public string Nationality { get; set; }

        public String HealthInformation { get; set; }

        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            base.ToString();
            return "HealthInformation: " + HealthInformation + " Nationality : " + Nationality ;
        }

        //TP1-Q11.b: Réimplémenter la méthode PassengerType()
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("and I'm a traveller");
        }
    }
}
