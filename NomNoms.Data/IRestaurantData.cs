using NomNoms.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NomNoms.Data
{
     public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            { 
                new Restaurant { Id = 1, Name = "Bunni's nommy noms", Location = "Clubhouse", Cuisine = CuisineType.Mexican}
                new Restaurant { Id = 2, Name = "Poni's nomlicious oms", Location = "Cloudy loudy", Cuisine = CuisineType.None}
                new Restaurant { Id = 3, Name = "Bun's buns", Location = "Secret bush", Cuisine = CuisineType.Chinese}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
