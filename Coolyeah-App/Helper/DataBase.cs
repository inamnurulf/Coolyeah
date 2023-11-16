using Coolyeah_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Coolyeah_App.Helper
{
    class DataBase
    {
        private SQLiteConnection _connection;

        public DataBase(string databasePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string dbPath = "C:\\Users\\HP\\source\\repos\\Coolyeah2\\Coolyeah-App" + databasePath;
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
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Drink (Notes, Value) VALUES (@Notes, @Value)";
                command.Parameters.AddWithValue("@Notes", drink.Notes);
                command.Parameters.AddWithValue("@Value", drink.Value);
                command.ExecuteNonQuery();
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
        public void CreateTableSleep()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Sleep (id INTEGER PRIMARY KEY, TimeStart TEXT, TimeEnd TEXT)";
                command.ExecuteNonQuery();
            }
        }

        public void InsertSleep(Sleep sleep)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Sleep (TimeStart, TimeEnd) VALUES (@TimeStart, @TimeEnd)";
                command.Parameters.AddWithValue("@TimeStart", sleep.TimeStart.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@TimeEnd", sleep.TimeEnd.ToString("yyyy-MM-dd HH:mm:ss"));
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
                            TimeStart = Convert.ToDateTime(reader["TimeStart"]),
                            TimeEnd = Convert.ToDateTime(reader["TimeEnd"])
                        };
                        sleeps.Add(sleep);
                    }
                }
            }
            return sleeps;
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

        public void CreateTableUser()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS User (Name TEXT, Sex TEXT, Age INTEGER, Weight REAL, Height REAL)";
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

        public User GetUser()
        {
            User user = null;

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM User LIMIT 1"; // Assuming you want to get the first user (if any)

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
    }
}
