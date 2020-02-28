using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeyWay.Controllers
{
    [Route("api/dishTypes")]
    [ApiController]
    public class DishTypeController : ControllerBase
    {
      
        private readonly IUnitOfWork _uow;

        private readonly IRepositoryBase<DishType> dishTypeRepository;

        public DishTypeController(IUnitOfWork uow)
        {
            dishTypeRepository = uow.GetRepository<DishType>();
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return dishTypeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} can not be 0");
            }

            var dishtype = await dishTypeRepository.Get(e => e.Id == id);

            return Ok(dishtype);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]DishType dish)
        {
            try
            {
                if (dish == null)
                {
                    throw new ArgumentException($"{nameof(dish)} cannot be null");
                }
                dishTypeRepository.Add(dish);
                await _uow.SaveChangesAsync();
                return Ok(dish);
            }
            catch(Exception ex)
            {
                ex.Data["dish"] = dish;
                throw;
            }          
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id,[FromBody]DishType dishType)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }
            DishType currentDishType = await dishTypeRepository.Get(e => e.Id == id);

            if (currentDishType == null)
            {
                throw new NullReferenceException($"Error while updating dishtype. DishType with {nameof(id)}={id} not found");
            }

            currentDishType.Name = dishType.Name;
            dishTypeRepository.Update(dishType);
            await _uow.SaveChangesAsync();
            return Ok(currentDishType);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }
            DishType dishType = await dishTypeRepository.Get(e => e.Id == id);
            dishTypeRepository.Remove(dishType);
            await _uow.SaveChangesAsync();
            return Ok();
        }
    }
}
