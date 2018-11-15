using OdeTofood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeTofood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> Restaurants { get; set; }

        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name="Scott's pizza place" },
                new Restaurant { Id = 2, Name="tersiguels" },
                new Restaurant { Id = 3, Name="Nikos"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return Restaurants.OrderBy( r => r.Name ).ToList();
        }

        public Restaurant Get( int id )
        {
            return Restaurants.FirstOrDefault( b => b.Id == id );
        }
    }
}
