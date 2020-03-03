using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeyWay.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IGenericRepository<Dish> _dishRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DishController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dishRepository = unitOfWork.GetRepository<Dish>();
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _dishRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} can't be 0");
            }

            try
            {
                var dish = await _dishRepository.Get(x => x.Id == id);
                return Ok(dish);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Dish dish)
        {
            if (dish == null)
            {
                throw new ArgumentException($"{nameof(dish)} can't be null");
            }

            try
            {
                _dishRepository.Add(dish);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dish);
            }
            catch
            {
                throw new Exception($"Error while adding dish nameof{nameof(dish)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Dish dish)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                var currentDish = await _dishRepository.Get(x => x.Id == id);

                if (currentDish == null)
                {
                    throw new NullReferenceException($"Error while updating dish. Dish with {nameof(id)}={id} not found");
                }

                currentDish.Name = dish.Name;
                currentDish.Price = dish.Price;
                currentDish.Description = dish.Description;
                currentDish.TypeId = dish.TypeId;
                currentDish.IsAvailable = dish.IsAvailable;

                _dishRepository.Update(currentDish);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentDish);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                var dish = await _dishRepository.Get(x => x.Id == id);
                _dishRepository.Remove(dish);
                await _unitOfWork.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }
    }
}
