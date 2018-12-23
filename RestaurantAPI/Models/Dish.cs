using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class Dish
    {
        public String Name { get; set; }
        public string TimeOfDay { get; set; }
        public DishType Type { get; set; }
    }
}
