using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using Coolyeah_App.Models;

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
        public void CreateTable()
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
    }
}
