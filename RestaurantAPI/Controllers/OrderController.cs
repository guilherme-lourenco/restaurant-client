using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        [HttpGet]
        [Route("GetOrder/{input?}")]
        public string GetOrder(string input)
        {
            string TimeOfDay;
        
            if (!string.IsNullOrEmpty(input))
            {
                List<string> entries = SplitInput(input, out TimeOfDay);

                Order objOrder = ProcessOrder(entries, TimeOfDay);

                //Eu queria retornar um Json mas ia aumentar muito a complexidade do teste unitário
                //return Json(objOrder);
                return string.Join(",", objOrder.Dishes.Select(i => i.Name));
            }
            else
            {
                return "Please inform a valid input.";
            }

        }

        private List<string> SplitInput(string input, out string TimeOfDay)
        {
            List<string> entries = input.Split(',').ToList<string>();
            TimeOfDay = entries[0];
            entries.RemoveAt(0);
            entries.Sort();

            return entries;
        }

        private Order ProcessOrder(List<String> entries, string TimeOfDay)
        {
            Order objOrder = new Order();
            List<Dish> mealList = GetDishesFromTimeOfDay(TimeOfDay);
            Dish item;

            foreach (string entry in entries)
            {
                item = mealList.Find(x => x.Type.ID.ToString().Contains(entry));
                if (item != null)
                {
                    if (!objOrder.Dishes.Contains(item))
                    {
                        objOrder.Dishes.Add(item);
                    }
                    else
                    {
                        if (item.Name.ToUpper() == "COFFEE" || item.Name.ToUpper() == "POTATO")
                            objOrder.Dishes.Add(item);
                    }

                }
                else
                {
                    objOrder.Dishes.Add(new Dish { Name = "error" });
                    return objOrder;
                }
            }
            return objOrder;
        }

        private List<Dish> GetDishesFromTimeOfDay(string TimeOfDay)
        {
            List<Dish> mealList = new List<Dish>();

            if (TimeOfDay.ToUpper() == "MORNING")
            {
                mealList.Add(new Dish { Name = "eggs", TimeOfDay = TimeOfDay, Type = new DishType(1, "entrée") });
                mealList.Add(new Dish { Name = "toast", TimeOfDay = TimeOfDay, Type = new DishType(2, "side") });
                mealList.Add(new Dish { Name = "coffee", TimeOfDay = TimeOfDay, Type = new DishType(3, "drink") });
            }
            else if (TimeOfDay.ToUpper() == "NIGHT")
            {
                mealList.Add(new Dish { Name = "steak", TimeOfDay = TimeOfDay, Type = new DishType(1, "entrée") });
                mealList.Add(new Dish { Name = "potato", TimeOfDay = TimeOfDay, Type = new DishType(2, "side") });
                mealList.Add(new Dish { Name = "wine", TimeOfDay = TimeOfDay, Type = new DishType(3, "drink") });
                mealList.Add(new Dish { Name = "cake", TimeOfDay = TimeOfDay, Type = new DishType(4, "dessert") });
            }

            return mealList;
        }
    }
}