﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeTofood.Data;
using OdeTofood.Models;

namespace OdeTofood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }
        public Restaurant Add( Restaurant restaurant )
        {
            _context.Restaurants.Add( restaurant );
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get( int id )
        {
            return _context.Restaurants.FirstOrDefault( r => r.Id == id );
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy( r => r.Name );
        }
    }
}