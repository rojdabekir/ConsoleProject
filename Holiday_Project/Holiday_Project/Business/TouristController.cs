using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Holiday_Project.Business
{
    public class TouristController
    {
        private readonly SqlConnection connection;

        public TouristController(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void AddTourist()
        {
            Console.Write("Enter tourist's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter tourist's last name: ");
            string lastName = Console.ReadLine();
            int rows = 0;

            string insertTouristSql = "INSERT INTO tourists (first_name, last_name) VALUES (@first_name, @last_name);";
            using (SqlCommand command = new SqlCommand(insertTouristSql, connection))
            {
                command.Parameters.AddWithValue("@first_name", firstName);
                command.Parameters.AddWithValue("@last_name", lastName);
                int rowsAffected = command.ExecuteNonQuery();
                rows = rowsAffected;
            }
            Console.WriteLine($"{rows} rows inserted.");
        }

        public void ListTourists()
        {
            string selectTouristSql = "SELECT id,first_name, last_name FROM tourists;";
            using (SqlCommand command = new SqlCommand(selectTouristSql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int touristId = reader.GetInt32(0);
                        string customerFirstName = reader.GetString(1);
                        string customerLastName = reader.GetString(2);
                        Console.WriteLine($"{touristId} - {customerFirstName} {customerLastName}");
                    }
                }
            }
        }

        public void RemoveTourist()
        {
            Console.Write("Enter tourist's first name: ");
            string firstNameToRemove = Console.ReadLine();
            Console.Write("Enter tourist's last name: ");
            string lastNameToRemove = Console.ReadLine();

            string removeTouristSql = "DELETE FROM tourists WHERE first_name = @first_name AND last_name = @last_name;";
            using (SqlCommand command = new SqlCommand(removeTouristSql, connection))
            {
                command.Parameters.AddWithValue("@first_name", firstNameToRemove);
                command.Parameters.AddWithValue("@last_name", lastNameToRemove);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} rows deleted.");
            }
        }
    }
}
