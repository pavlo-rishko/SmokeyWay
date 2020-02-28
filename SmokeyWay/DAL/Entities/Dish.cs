using System.Collections.Generic;

namespace DAL.Entities
{
    public class Dish : BaseEntity<int>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsAvalialable { get; set; }

        public int TypeId { get; set; }

        public DishType DishType { get; set; }

        public IList<OrderDish> OrdersDishes { get; set; }
    }
}
