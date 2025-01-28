using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday_Project.Data.Models
{
    public class Reservation
    {
        public Reservation()
        {

        }
        public Reservation(string touristFName, string touristLName, string hotelName)
        {
            this.TouristFirstName = touristFName;
            this.TouristLastName = touristLName;
            this.HotelName = hotelName;
        }
        public int Id { get; set; }
        public string TouristFirstName { get; set; }
        public string TouristLastName { get; set; }

        public string HotelName { get; set; }
    }
}
