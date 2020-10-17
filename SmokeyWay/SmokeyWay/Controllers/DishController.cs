using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        private readonly IValidator<Dish> _validator;

        private readonly ILogger _logger;

        public DishController(IUnitOfWork unitOfWork, IValidator<Dish> validator, ILogger<DishController> logger)
        {
            _unitOfWork = unitOfWork;
            _dishRepository = unitOfWork.GetRepository<Dish>();
            _validator = validator;
            _logger = logger;
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
                var ex = new ArgumentException($"{nameof(id)} can't be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var dish = await _dishRepository.Get(x => x.Id == id);
                return Ok(dish);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Dish dish)
        {
            if (dish == null)
            {
                var ex = new ArgumentException($"{nameof(dish)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(dish).IsValid)
            {
                var ex = new ArgumentException($"{nameof(dish)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _dishRepository.Add(dish);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dish);
            }
            catch
            {
                var ex = new Exception($"Error while adding dish nameof{nameof(dish)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Dish dish)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(dish).IsValid)
            {
                var ex = new ArgumentException($"{nameof(dish)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentDish = await _dishRepository.Get(x => x.Id == id);

                if (currentDish == null)
                {
                    var ex = new NullReferenceException($"Error while updating dish. Dish with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
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
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
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
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
