using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class Order
    {
        public List<Dish> Dishes { get; set; }

        public Order()
        {
            Dishes = new List<Dish>();
        }
    }
}
