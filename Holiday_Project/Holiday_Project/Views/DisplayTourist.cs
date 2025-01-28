using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Holiday_Project.Business;

namespace Holiday_Project.Views
{
    public class DisplayTourist
    {
        private TouristController controller;
        public DisplayTourist()
        {

        }
        public DisplayTourist(TouristController controller)
        {
            this.controller = controller;
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("----- TOURIST MENU -----");
                Console.WriteLine("1. Add new tourist");
                Console.WriteLine("2. List all tourists");
                Console.WriteLine("3. Remove a tourist");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your order: ");
                string order = Console.ReadLine();

                switch (order)
                {
                    case "1":
                        controller.AddTourist();
                        break;
                    case "2":
                        controller.ListTourists();
                        break;
                    case "3":
                        controller.RemoveTourist();
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
