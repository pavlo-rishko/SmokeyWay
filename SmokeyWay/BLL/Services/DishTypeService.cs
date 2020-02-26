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
        
        public async Task Add(string name)
        {
            try
            {                
                _uow.GetRepository<DishType>().Add(new DishType {Name = name});
                await _uow.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                ex.Data["dishType"] = name;
                throw;
            }
        }

        public IQueryable<DishType> GetAll()
        {
            return _uow.GetRepository<DishType>().GetAll();
        }

        public DishType GetById(int id)
        {
            try
            {
                var project = _uow.GetRepository<DishType>().GetAll().SingleOrDefault(e => e.Id == id);
                return project;
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

        public async Task UpdateById(int id)
        {
            try
            {
                var type = _uow.GetRepository<DishType>().GetAll().SingleOrDefault(e => e.Id == id);
                if (type == null)
                {
                    throw new NullReferenceException($"Error while updating dishtype. DishType with {nameof(id)}={id} not found");
                }
                _uow.GetRepository<DishType>().Update(type);
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
