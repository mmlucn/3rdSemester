using Dapper;
using Microsoft.Data.SqlClient;
using ModelsDap.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.DB
{
    public class CarImagesDB
    {

        public async Task AddPictures(int carId, byte[] file)
        {
           

            using (var con = new SqlConnection(DbConnection.conString))
            {
                string query = "INSERT INTO CarImages(Image, CarId) VALUES (@Image, @CarId)";
                var res = con.Execute(query, new
                {
                    CarId = carId,
                    Image = file
                });

               
            }
        }
        public async Task GetPictures(int carId)
        {
            using (var con = new SqlConnection(DbConnection.conString))
            {
                string query = "select * from CarImages Where CarId = @Id";
                var res = con.Query<CarImages>(query, new { Id = carId });
                res.ToList().ForEach(image =>
                {
                    File.WriteAllBytes($"pictures/yolo{image.Image.Length}.png", image.Image);
                });
                
            }
        }
        public async Task<int> DeleteImageAsync(int id)
        {
            var sql = "DELETE FROM CarImages WHERE Id = @Id";
            using (var connection = new SqlConnection(DbConnection.conString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

    }
}
