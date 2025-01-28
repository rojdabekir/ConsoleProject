using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Holiday_Project.Business;

namespace Holiday_Project.Views
{
    public class Display
    {
        private string connectionString = "Data Source= DESKTOP-LBOVVQM\\SQLEXPRESS; Initial Catalog= HolidayDB;Integrated Security=True;";
        public Display()
        {
            Input();
        }

        private void Input()
        {
            while (true)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 16) + "HOME MENU");
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("1. Tourists");
                Console.WriteLine("2. Reservations");
                Console.WriteLine("3. Hotels");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your order: ");
                string order = Console.ReadLine();

                switch (order)
                {
                    case "1":
                        Console.Clear();
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            var controller = new TouristController(connection);
                            var view = new DisplayTourist(controller);
                            view.Display();
                            connection.Close();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            var controller = new ReservationController(connection);
                            var view = new DisplayReservation(controller);
                            view.Display();
                            connection.Close();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            var controller = new HotelController(connection);
                            var view = new DisplayHotel(controller);
                            view.Display();
                            connection.Close();
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Bye!");
                        return;
                }
            }
        }
    }
}
