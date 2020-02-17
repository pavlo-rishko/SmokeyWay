using BLL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
           
        }

        public DishType Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(DishType dish, int dishId)
        {
            throw new NotImplementedException();
        }
    }
}
