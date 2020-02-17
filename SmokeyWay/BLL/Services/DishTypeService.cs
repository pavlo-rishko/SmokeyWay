using BLL.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    class DishTypeService : IDishTypeService
    {
        private readonly IUnitOfWork _uow;
        public Task Add(DishType dish)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DishType> Get()
        {
            return _uow.Repository<DishType>().GetAll();
        }

        public DishType Get(int id)
        {
            return _uow.Repository<DishType>().GetAll().SingleOrDefault(e => e.Id == id);
        }

        public async Task Remove(int id)
        {
           var dish = _uow.Repository<DishType>().GetAll().SingleOrDefault(e => e.Id == id);
            if (dish == null)
            {
                throw new NullReferenceException($"Error while deleting dishtype. DishType with id {nameof(id)}={id} not found");
            }
            _uow.Repository<DishType>().Remove(dish);
            await _uow.SaveChangesAsync();
        }

        public async Task Update( int id)
        {
            var dish = _uow.Repository<DishType>().GetAll().SingleOrDefault(e => e.Id == id);
            if (dish == null)
            {
                throw new NullReferenceException($"Error while updating dishtype. DishType with id {nameof(id)}={id} not found");
            }
            _uow.Repository<DishType>().Update(dish);
            await _uow.SaveChangesAsync();
        }
    }
}
