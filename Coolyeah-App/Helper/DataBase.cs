using Coolyeah_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows;

namespace Coolyeah_App.Helper
{
    class DataBase
    {
        private SQLiteConnection _connection;

        static string FilterPath(string inputPath)
        {
            // Split the path by the directory separator '\'
            string[] pathSegments = inputPath.Split('\\');

            // Find the index of "Coolyeah-App"
            int index = Array.IndexOf(pathSegments, "Coolyeah-App");

            if (index != -1)
            {
                // Join the path segments up to and including "Coolyeah-App"
                string result = string.Join("\\", pathSegments, 0, index + 1);
                return result;
            }
            else
            {
                // Handle the case where "Coolyeah-App" is not found in the path
                return "Coolyeah-App not found in the path.";
            }
        }

        public DataBase(string databasePath)
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string result = FilterPath(directoryPath);

            Console.WriteLine(result);

            string dbPath = result + databasePath;
            _connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            _connection.Open();
            this.CreateTableUser();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
        public bool TestConnection()
        {
            try
            {
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT 1";
                    command.ExecuteScalar();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void CreateTableFood()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Food (id INTEGER PRIMARY KEY, Notes TEXT, Value INTEGER)";
                command.ExecuteNonQuery();
            }
        }

        public void InsertFood(Food food)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Food (Notes, Value) VALUES (@Notes, @Value)";
                command.Parameters.AddWithValue("@Notes", food.Notes);
                command.Parameters.AddWithValue("@Value", food.Value);
                command.ExecuteNonQuery();
            }
        }

        public List<Food> ReadAllFood()
        {
            List<Food> foods = new List<Food>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Food";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Food food = new Food
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Notes = Convert.ToString(reader["Notes"]),
                            Value = Convert.ToInt32(reader["Value"])
                        };
                        foods.Add(food);
                    }
                }
            }
            return foods;
        }

        public void DeleteFood(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Food WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }


        public void CreateTableDrink()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Drink (id INTEGER PRIMARY KEY, Notes TEXT, Value INTEGER)";
                command.ExecuteNonQuery();
            }
        }

        public void InsertDrink(Drink drink)
        {
            try
            {
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Drink (Notes, Value) VALUES (@Notes, @Value)";
                    command.Parameters.AddWithValue("@Notes", drink.Notes);
                    command.Parameters.AddWithValue("@Value", drink.Value);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting drink: {ex.Message}");
            }
        }

        public List<Drink> ReadAllDrink()
        {
            List<Drink> drinks = new List<Drink>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Drink";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Drink drink = new Drink
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Notes = Convert.ToString(reader["Notes"]),
                            Value = Convert.ToInt32(reader["Value"])
                        };
                        drinks.Add(drink);
                    }
                }
            }
            return drinks;
        }

        public void DeleteDrink(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Drink WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }


        public void CreateTableActivity()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Activity (id INTEGER PRIMARY KEY, Notes TEXT, Value INTEGER)";
                command.ExecuteNonQuery();
            }
        }

        public void InsertActivity(Activity activity)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Activity (Notes, Value) VALUES (@Notes, @Value)";
                command.Parameters.AddWithValue("@Notes", activity.Notes);
                command.Parameters.AddWithValue("@Value", activity.Value);
                command.ExecuteNonQuery();
            }
        }

        public List<Activity> ReadAllActivity()
        {
            List<Activity> activities = new List<Activity>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Activity";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Activity activity = new Activity
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Notes = Convert.ToString(reader["Notes"]),
                            Value = Convert.ToInt32(reader["Value"])
                        };
                        activities.Add(activity);
                    }
                }
            }
            return activities;
        }

        public void DeleteActivity(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Activity WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public void CreateTableUser()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS User (Name TEXT, Sex TEXT, Age INTEGER, Weight REAL, Height REAL)";
                command.ExecuteNonQuery();
            }
        }


        public void CreateTableSleep()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Sleep (id INTEGER PRIMARY KEY, Notes TEXT, Value INTEGER)";
                command.ExecuteNonQuery();
            }
        }
        public void InsertUser(User user)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO User (Name, Sex, Age, Weight, Height) VALUES (@Name, @Sex, @Age, @Weight, @Height)";
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Sex", user.Sex);
                command.Parameters.AddWithValue("@Age", user.Age);
                command.Parameters.AddWithValue("@Weight", user.Weight);
                command.Parameters.AddWithValue("@Height", user.Height);
                command.ExecuteNonQuery();
            }
        }

        public void InsertSleep(Sleep sleep)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Sleep (Notes, Value) VALUES (@Notes, @Value)";
                command.Parameters.AddWithValue("@Notes", sleep.Notes);
                command.Parameters.AddWithValue("@Value", sleep.Value);
                command.ExecuteNonQuery();
            }
        }

        public List<Sleep> ReadAllSleep()
        {
            List<Sleep> sleeps = new List<Sleep>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Sleep";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Sleep sleep = new Sleep
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Notes = Convert.ToString(reader["Notes"]),
                            Value = Convert.ToInt32(reader["Value"])
                        };
                        sleeps.Add(sleep);
                    }
                }
            }
            return sleeps;
        }
        public void DeleteSleep(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Sleep WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }


        public User GetUser()
        {
            User user = null;

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM User LIMIT 1";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Name = Convert.ToString(reader["Name"]),
                            Sex = Convert.ToString(reader["Sex"]),
                            Age = Convert.ToInt32(reader["Age"]),
                            Weight = Convert.ToDouble(reader["Weight"]),
                            Height = Convert.ToDouble(reader["Height"])
                        };
                    }
                }
            }

            return user;
        }

        public bool HasUser()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM User";
                var result = (long)command.ExecuteScalar();
                return result > 0;
            }
        }

        public void DeleteAllData()
        {
            string[] tableNames = { "Food", "Drink", "Activity", "Sleep" };

            foreach (var tableName in tableNames)
            {
                DeleteAllFromTable(tableName);
            }
        }

        private void DeleteAllFromTable(string tableName)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM {tableName}";
                command.ExecuteNonQuery();
            }
        }

    }
}
