using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        [Key]
        [MaxLength(7)]
        public string PassportNumber { get; set; }
        [StringLength(25, MinimumLength = (3), ErrorMessage = "The first name needs to be a minmum 3 or at max 25.")]
        public FullName FullName { get; set; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Le numéro de téléphone doit contenir 8 chiffres.")]
        private String numTel { get; set; }

        //prop de navigation
        //public virtual List<Flight> Flights { get; set; }
        public virtual List<Ticket> TicketList { get; set; }

        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            return "FirstName: " + FullName.FirstName + " LastName: " + FullName.LastName + " date of Birth: " + BirthDate;
        }

        //TP1-Q10: Créer les trois méthodes bool CheckProfile(...)
        //public bool CheckProfile(string firstName, string lastName)
        //{
        //    return FirstName == firstName && LastName == lastName;
        //}

        //public bool CheckProfile(string firstName, string lastName, string email)
        //{
        //    return FirstName == firstName && LastName == lastName && EmailAddress == email;
        //}

        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAddress == email;
            else
                return FullName.FirstName == firstName && FullName.LastName == lastName;
        }

        //TP1-Q11.a: Implémenter la méthode PassengerType()
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }

    }
}
