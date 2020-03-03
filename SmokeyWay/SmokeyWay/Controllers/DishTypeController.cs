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
        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenericRepository<DishType> _dishTypeRepository;

        public DishTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dishTypeRepository = unitOfWork.GetRepository<DishType>();
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
                throw new ArgumentException($"{nameof(id)} can`t be 0");
            }

            try
            {
                var dishtype = await _dishTypeRepository.Get(e => e.Id == id);
                return Ok(dishtype);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }           
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]DishType dish)
        {
            if (dish.Name == null)
            {
                throw new ArgumentException($"{nameof(dish)} can`t be null");
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
                throw;
            }          
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]DishType dishType)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} can`t be 0");
            }

            try
            {
                var currentDishType = await _dishTypeRepository.Get(e => e.Id == id);

                if (currentDishType == null)
                {
                    throw new NullReferenceException($"Error while updating dishtype. DishType with {nameof(id)}={id} not found");
                }

                currentDishType.Name = dishType.Name;
                _dishTypeRepository.Update(currentDishType);
                await _unitOfWork.SaveChangesAsync();
                return Ok(currentDishType);
            }
            catch (Exception ex)
            {
                ex.Data["dishType"] = dishType;
                throw;
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} can`t be 0");
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
                throw;
            }
        }
    }
}
