using NomNoms.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NomNoms.Data
{
     public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            { 
                new Restaurant { Id = 1, Name = "Bunni's nommy noms", Location = "Clubhouse", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 2, Name = "Poni's nomlicious oms", Location = "Cloudy loudy", Cuisine = CuisineType.None},
                new Restaurant { Id = 3, Name = "Bun's buns", Location = "Secret bush", Cuisine = CuisineType.Chinese}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
