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
        public async Task Add(DishType dish)
        {
            try
            {
                var dishtype = new DishType
                {
                    Id = dish.Id,
                    Name = dish.Name
                };
                _uow.GetRepository<DishType>().Add(dish);
                await _uow.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                ex.Data["dishType"] = dish;
                throw;
            }
        }

        public IQueryable<DishType> Get()
        {
            return _uow.GetRepository<DishType>().GetAll();
        }

        public DishType GetById(int id)
        {
            return _uow.GetRepository<DishType>().GetAll().SingleOrDefault(e => e.Id == id);
        }

        public async Task Remove(int id)
        {
           var dish = _uow.GetRepository<DishType>().GetAll().SingleOrDefault(e => e.Id == id);
            if (dish == null)
            {
                throw new NullReferenceException($"Error while deleting dishtype. DishType with id {nameof(id)}={id} not found");
            }
            _uow.GetRepository<DishType>().Remove(dish);
            await _uow.SaveChangesAsync();
        }

        public async Task Update(DishType type, int id)
        {
           type = _uow.GetRepository<DishType>().GetAll().SingleOrDefault(e => e.Id == id);
            if (type == null)
            {
                throw new NullReferenceException($"Error while updating dishtype. DishType with id {nameof(id)}={id} not found");
            }
            _uow.GetRepository<DishType>().Update(type);
            await _uow.SaveChangesAsync();
        }
    }
}
