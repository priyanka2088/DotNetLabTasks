using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DatabaseManagement
{
    internal class Program
    {
        private const string ConnectionString = "Server=WIPDNFSD;Database=SampleDB;User Id=DotNetServer;Password=UstDB@123;";

        public static void CreateUsersTable()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(
                    "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users') " +
                    "CREATE TABLE Users (Id INT PRIMARY KEY, Name NVARCHAR(100), Email NVARCHAR(100))",
                    connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table 'Users' is ready.");
            }
        }

        public static void GetData(SqlConnection con)
        {
            List<User> users = new List<User>();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    users.Add(new User
                    {
                        Id = rdr.GetInt32(0),
                        Name = rdr.GetString(1),
                        Email = rdr.GetString(2)
                    });
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while retrieving data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
            }
        }

        public static void InsertData(int id, string name, string email, SqlConnection con)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Users (Id, Name, Email) VALUES ({id}, '{name}', '{email}')", con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("User added successfully!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while adding user: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void UpdateData(int id, string name, string email, SqlConnection con)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE Users SET Name = '{name}', Email = '{email}' WHERE Id = {id}", con);
                int rowsAffected = cmd.ExecuteNonQuery(); // Get the number of affected rows

                if (rowsAffected > 0)
                {
                    Console.WriteLine("User updated successfully!");
                }
                else
                {
                    Console.WriteLine("No user found with the specified ID.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while updating user: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void DeleteData(int id, SqlConnection con)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM Users WHERE Id = {id}", con);
                int rowsAffected = cmd.ExecuteNonQuery(); // Get the number of affected rows

                if (rowsAffected > 0)
                {
                    Console.WriteLine("User deleted successfully!");
                }
                else
                {
                    Console.WriteLine("No user found with the specified ID.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while deleting user: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        static void Main(string[] args)
        {
            CreateUsersTable();

            SqlConnection conn = new SqlConnection(ConnectionString);
            bool isLoopRunning = true;

            while (isLoopRunning)
            {
                Console.WriteLine("Please enter a choice:");
                Console.WriteLine("1. List Users");
                Console.WriteLine("2. Insert User");
                Console.WriteLine("3. Update User");
                Console.WriteLine("4. Delete User");
                Console.WriteLine("5. Exit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            GetData(conn);
                            break;
                        case 2:
                            Console.WriteLine("Please enter user ID:");
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.WriteLine("Please enter user Name:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Please enter user Email:");
                                string email = Console.ReadLine();
                                InsertData(id, name, email, conn);
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID. Please enter a number.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Please enter user ID to update:");
                            if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                            {
                                Console.WriteLine("Please enter new user Name:");
                                string newName = Console.ReadLine();
                                Console.WriteLine("Please enter new user Email:");
                                string newEmail = Console.ReadLine();
                                UpdateData(idToUpdate, newName, newEmail, conn);
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID. Please enter a number.");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Please enter user ID to delete:");
                            if (int.TryParse(Console.ReadLine(), out int idToDelete))
                            {
                                DeleteData(idToDelete, conn);
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID. Please enter a number.");
                            }
                            break;
                        case 5:
                            isLoopRunning = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a correct choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}