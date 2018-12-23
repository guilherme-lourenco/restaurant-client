using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Controllers;

namespace RestaurantAPI
{
    public class OrderService :IOrderService
    {
        public string GetOrder(string input)
        {
            return new OrderController().GetOrder(input);
        }
    }
}
