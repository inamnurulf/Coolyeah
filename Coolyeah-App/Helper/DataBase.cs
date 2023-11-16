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

        public DataBase(string databasePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string dbPath = "D:\\kuliah\\sem 5\\coolyeah updated\\Coolyeah\\Coolyeah-App" + databasePath;
            _connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            _connection.Open();
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

        public void CreateTableSleep()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Sleep (id INTEGER PRIMARY KEY, Notes TEXT, Value INTEGER)";
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


    }
}
