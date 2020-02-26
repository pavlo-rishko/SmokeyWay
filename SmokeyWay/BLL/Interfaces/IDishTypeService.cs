using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDishTypeService
    {
        Task Add(string name);

        Task RemoveById(int id);

        Task UpdateById(int id);

        IQueryable<DishType> GetAll();

        DishType GetById(int id);
    }
}
