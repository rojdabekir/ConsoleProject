using Holiday_Project.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday_Project.Views
{
    public class DisplayReservation
    {
        private ReservationController controller;
        public DisplayReservation()
        {

        }
        public DisplayReservation(ReservationController controller)
        {
            this.controller = controller;
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("----- RESERVATION MENU -----");
                Console.WriteLine("1. Add new reservation");
                Console.WriteLine("2. List all reservations");
                Console.WriteLine("3. Remove a reservation");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your order: ");
                string order = Console.ReadLine();

                switch (order)
                {
                    case "1":
                        controller.CreateReservation();
                        break;
                    case "2":
                        controller.ListReservations();
                        break;
                    case "3":
                        controller.RemoveReservation();
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
