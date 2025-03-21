using System;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using Core;

namespace ServerAPI.Repositories
{
    public class BikeRepositorySQLite : IBikeRepository
    {
        private const string connectionString = @"Data Source=//Users/oleeriksen/Data/bikes.db";

        public BikeRepositorySQLite()
        {
        }

        public BEBike[] GetAll() {
            var result = new List<BEBike>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Bike";
             
                using (var reader = command.ExecuteReader())
                {      
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var brand = reader.GetString(1);
                        var model = reader.GetString(2);
                        var desc = reader.GetString(3);
                        var price = reader.GetInt32(4);
                        var imgUrl = reader.GetString(5);

                        BEBike b = new BEBike { Id = id, Brand = brand, Model = model, Description = desc, Price = price, ImageUrl = imgUrl };
                        result.Add(b);
                    }
                }
            }
            return result.ToArray();
        }

        public void Add(BEBike bike) {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();  
                var command = connection.CreateCommand();

                command.CommandText = @"INSERT INTO Bike (Brand, Model, Description, Price, ImageUrl) VALUES ($brand, $model, $desc, $price, $imgurl)";
                command.Parameters.AddWithValue("$brand", bike.Brand);
                command.Parameters.AddWithValue("$model", bike.Model);
                command.Parameters.AddWithValue("$desc", bike.Description);
                command.Parameters.AddWithValue("$price", bike.Price);
                command.Parameters.AddWithValue("$imgurl", bike.ImageUrl);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();  
                var command = connection.CreateCommand();

                command.CommandText = $"delete from Bike where Id = {id}";
                command.ExecuteNonQuery();
            }
            
        }
    }
}

