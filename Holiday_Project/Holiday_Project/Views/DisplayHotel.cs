using Holiday_Project.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday_Project.Views
{
    public class DisplayHotel
    {
        private HotelController controller;
        public DisplayHotel()
        {

        }
        public DisplayHotel(HotelController controller)
        {
            this.controller = controller;
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("----- HOTEL MENU -----");
                Console.WriteLine("1. Add new hotel");
                Console.WriteLine("2. List all hotels");
                Console.WriteLine("3. Remove a hotel");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your order: ");
                string order = Console.ReadLine();

                switch (order)
                {
                    case "1":
                        controller.AddHotel();
                        break;
                    case "2":
                        controller.ListHotels();
                        break;
                    case "3":
                        controller.RemoveHotel();
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        return;
                    default:
                        Console.WriteLine("Invalid order!");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}

