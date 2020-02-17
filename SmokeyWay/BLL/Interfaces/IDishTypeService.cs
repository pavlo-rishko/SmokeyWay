using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDishTypeService
    {
        Task Add(DishType dish);

        Task Remove(int id);

        Task Update(DishType dish, int dishId);

        IEnumerable<DishType> Get();

        DishType Get(int id);
    }
}
