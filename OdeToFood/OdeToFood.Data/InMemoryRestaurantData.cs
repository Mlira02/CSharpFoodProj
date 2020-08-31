using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = Restaurant.CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Tacos Yum!", Location = "Illinois", Cuisine = Restaurant.CuisineType.Mexican},
                new Restaurant {Id = 3, Name = "Something Indian", Location = "Georgia", Cuisine = Restaurant.CuisineType.Indian},
                new Restaurant {Id = 4, Name = "Mexican Joint", Location = "Maryland", Cuisine = Restaurant.CuisineType.Mexican},
                new Restaurant {Id = 5, Name = "Pizza Thyme", Location = "Pittsburgh", Cuisine = Restaurant.CuisineType.Italian},
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants
                .OrderBy(r => r.Name)
                .Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name));
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }
    }
}