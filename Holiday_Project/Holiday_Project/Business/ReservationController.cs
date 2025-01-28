using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday_Project.Business
{
    public class ReservationController
    {
        private SqlConnection connection;

        public ReservationController(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void CreateReservation()
        {
            Console.Write("Enter tourist's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter tourist's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter hotel's name: ");
            string hName = Console.ReadLine();

            string insertReservationSql = "INSERT INTO reservations (tourist_first_name, tourist_last_name,hotel_name) VALUES (@tourist_first_name, @tourist_last_name, @hotel_name);";
            using (SqlCommand command = new SqlCommand(insertReservationSql, connection))
            {
                command.Parameters.AddWithValue("@tourist_first_name", firstName);
                command.Parameters.AddWithValue("@tourist_last_name", lastName);
                command.Parameters.AddWithValue("@hotel_name", hName);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    Console.WriteLine("Reservation is made successfully.");
                }
                else
                {
                    Console.WriteLine("Error making reservation.");
                }
            }
        }

        public void ListReservations()
        {
            string selectReservationSql = "SELECT tourist_first_name, tourist_last_name, hotel_name  FROM reservations;";
            using (SqlCommand command = new SqlCommand(selectReservationSql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string touristFirstName = reader.GetString(0);
                        string touristLastName = reader.GetString(1);
                        string hotelName = reader.GetString(2);
                        Console.WriteLine($" Name - {touristFirstName}, Last name - {touristLastName}, Hotel name - {hotelName}");
                    }
                }
            }
        }

        public void RemoveReservation()
        {
            Console.Write("Enter tourist's first name: ");
            string firstName = Console.ReadLine();
            string removeReservationSql = "DELETE FROM reservations WHERE tourist_first_name = @tourist_first_name;";
            using (SqlCommand command = new SqlCommand(removeReservationSql, connection))
            {
                command.Parameters.AddWithValue("@tourist_first_name", firstName);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} rows deleted.");
            }
        }
    }
}
