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
    [Route("api/dishTypes")]
    [ApiController]
    public class DishTypeController : ControllerBase
    {  
        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenericRepository<DishType> _dishTypeRepository;

        private readonly IValidator<DishType> _validator;

        private readonly ILogger _logger;

        public DishTypeController(IUnitOfWork unitOfWork, IValidator<DishType> validator, ILogger<DishTypeController> logger)
        {
            _unitOfWork = unitOfWork;
            _dishTypeRepository = unitOfWork.GetRepository<DishType>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _dishTypeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} can`t be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var dishtype = await _dishTypeRepository.Get(e => e.Id == id);
                return Ok(dishtype);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }           
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]DishType dish)
        {
            if (dish.Name == null)
            {
                var ex = new ArgumentException($"{nameof(dish)} can`t be null");
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
                _dishTypeRepository.Add(dish);
                await _unitOfWork.SaveChangesAsync();
                return Ok(dish);
            }
            catch (Exception ex)
            {
                ex.Data["dish"] = dish;
                _logger.LogError(ex.ToString());
                throw ex;
            }          
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]DishType dishType)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} can`t be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(dishType).IsValid)
            {
                var ex = new ArgumentException($"{nameof(dishType)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentDishType = await _dishTypeRepository.Get(e => e.Id == id);

                if (currentDishType == null)
                {
                    var ex = new NullReferenceException($"Error while updating dishtype. DishType with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentDishType.Name = dishType.Name;
                _dishTypeRepository.Update(currentDishType);
                await _unitOfWork.SaveChangesAsync();
                return Ok(currentDishType);
            }
            catch (Exception ex)
            {
                ex.Data["dishType"] = dishType;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} can`t be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                DishType dishType = await _dishTypeRepository.Get(e => e.Id == id);
                _dishTypeRepository.Remove(dishType);
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