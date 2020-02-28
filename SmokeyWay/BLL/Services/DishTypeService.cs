using BLL.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DishTypeService : IDishTypeService
    {
        private readonly IUnitOfWork _uow;

        public DishTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public async Task Add(DishType type)
        {
            try
            {                
                _uow.GetRepository<DishType>().Add(new DishType {Name = type.Name});
                await _uow.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                ex.Data["dishType"] = type;
                throw;
            }
        }

        public IQueryable<DishType> GetAll()
        {
            return _uow.GetRepository<DishType>().GetAll();
        }

        public Task<DishType>  GetById(int id)
        {
            try
            {
                return _uow.GetRepository<DishType>().Get(e => e.Id == id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error when getting dishtype by {nameof(id)} = {id} ", ex);
            }
        }

        public async Task RemoveById(int id)
        {
            try
            {
                var dish = _uow.GetRepository<DishType>().GetAll().SingleOrDefault(e => e.Id == id);

                if (dish == null)
                {
                    throw new NullReferenceException($"Error while deleting dishtype. DishType with {nameof(id)}={id} not found");
                }

                _uow.GetRepository<DishType>().Remove(dish);
                await _uow.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        public async Task UpdateById(int id, DishType dishType)
        {
            try
            {
                DishType currentDishType = await _uow.GetRepository<DishType>().Get(x => x.Id == id);

                if (currentDishType == null)
                {
                    throw new NullReferenceException($"Error while updating dishtype. DishType with {nameof(id)}={id} not found");
                }

                currentDishType.Name = dishType.Name;
                _uow.GetRepository<DishType>().Update(currentDishType);
                await _uow.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }
    }
}
