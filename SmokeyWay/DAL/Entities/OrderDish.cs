using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class OrderDish
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }
    }
}
