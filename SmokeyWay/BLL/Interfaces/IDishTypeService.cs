using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDishTypeService
    {
        Task Add(DishType dish);

        Task Remove(int id);

        Task Update(DishType dish,int id);

        IQueryable<DishType> Get();

        DishType GetById(int id);
    }
}
