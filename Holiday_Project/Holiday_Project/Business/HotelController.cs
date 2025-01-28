using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Holiday_Project.Business
{
    public class HotelController
    {
        private SqlConnection connection;

        public HotelController(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void ListHotels()
        {
            string selectHotelSql = "SELECT id, name FROM hotels;";
            using (SqlCommand command = new SqlCommand(selectHotelSql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int hotelId = reader.GetInt32(0);
                        string hotelName = reader.GetString(1);
                        Console.WriteLine($"{hotelId} - {hotelName}");
                    }
                }
            }
        }

        public void AddHotel()
        {
            Console.Write("Enter hotel name: ");
            string name = Console.ReadLine();
            int rows = 0;

            string insertHotelSql = "INSERT INTO hotels (name) VALUES (@name);";
            using (SqlCommand command = new SqlCommand(insertHotelSql, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                int rowsAffected = command.ExecuteNonQuery();
                rows = rowsAffected;
                
            }
            Console.WriteLine($"{rows} rows inserted.");
        }

        public void RemoveHotel()
        {
            Console.Write("Enter hotel name: ");
            string hotelNameToRemove = Console.ReadLine();

            string removeHotelSql = "DELETE FROM hotels WHERE name = @name;";
            using (SqlCommand command = new SqlCommand(removeHotelSql, connection))
            {
                command.Parameters.AddWithValue("@name", hotelNameToRemove);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} rows deleted.");
            }
        }
    }
}
