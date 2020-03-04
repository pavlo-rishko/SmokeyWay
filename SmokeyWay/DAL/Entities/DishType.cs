using System.Collections.Generic;

namespace DAL.Entities
{
    public class DishType : BaseEntity
    {
        public string Name { get; set; }

        public IList<Dish> Dishes { get; set; }
    }
}