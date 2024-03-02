using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension
    {

        //extention methods servers as a new method for a class that is closed and we don't want to modiy it 
        // the link between the new class with the new method in our case PassengerExtension the link is 
        // this. Passenger passenger
        public static void UpperFullName(this Passenger passenger)
        {
            if (passenger != null)
            {
                // Create a TextInfo object for the French culture (fr-FR)
                TextInfo textInfo = new CultureInfo("fr-FR", false).TextInfo;

                if (!string.IsNullOrEmpty(passenger.FullName.FirstName))
                {
                    passenger.FullName.FirstName = textInfo.ToTitleCase(passenger.FullName.FirstName); 
                }

                if (!string.IsNullOrEmpty(passenger.FullName.LastName))
                {

                    passenger.FullName.LastName = textInfo.ToTitleCase(passenger.FullName.LastName);
                }
            }
        }
    }
}
 