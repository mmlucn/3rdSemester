﻿using Dapper;
using Microsoft.Data.SqlClient;
using ModelsDap.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.DB
{
    public class DbConnection
    {
        private string conString;

        public DbConnection()
        {
            //conString = ConfigurationManager.ConnectionStrings["Hildur"].ConnectionString;
            conString = @"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False";
        }

        public DbConnection(string connectionString)
        {
            conString = connectionString;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            List<Car> cars = new List<Car>();
            using (var con = new SqlConnection(conString))
            {
                string queryCars = "select * from Cars INNER JOIN AspNetUsers ON Cars.ownerId = AspNetUsers.Id";
                var resCars = await con.QueryAsync<Car, Customer, Car>(queryCars, (car, customer) =>
                {
                    car.Owner = customer;
                    return car;
                });

                string queryImg = "select * from CarImages";
                var resImg = await con.QueryAsync<CarImages>(queryImg);
                foreach (var car in resCars)
                {
                    car.Pictures = resImg.Where(img => img.CarId == car.Id).ToList();
                }


                return resCars.ToList();
            }
            return null;
        }
    }
}
