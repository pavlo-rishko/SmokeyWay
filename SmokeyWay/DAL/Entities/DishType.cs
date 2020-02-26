using System.Collections.Generic;

namespace DAL.Entities
{
    public class DishType : BaseEntity<int>
    {
        public string Name { get; set; }

        public IList<Dish> Dishes { get; set; }
    }
}
