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
    [Route("api/departaments")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IGenericRepository<Departament> _departamentRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator _validator;

        private readonly ILogger _logger;

        public DepartamentController(IUnitOfWork unitOfWork, IValidator<Departament> validator, ILogger<DepartamentController> logger)
        {
            _unitOfWork = unitOfWork;
            _departamentRepository = unitOfWork.GetRepository<Departament>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _departamentRepository.GetAll();
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
                var departament = await _departamentRepository.Get(x => x.Id == id);
                return Ok(departament);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Departament departament)
        {
            if (departament == null)
            {
                var ex = new ArgumentException($"{nameof(departament)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(departament).IsValid)
            {
                var ex = new ArgumentException($"{nameof(departament)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _departamentRepository.Add(departament);
                await _unitOfWork.SaveChangesAsync();
                return Ok(departament);
            }
            catch
            {
                var ex = new Exception($"Error while adding departament nameof{nameof(departament)}");
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Departament departament)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(departament).IsValid)
            {
                var ex = new ArgumentException($"{nameof(departament)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentDepartament = await _departamentRepository.Get(x => x.Id == id);

                if (currentDepartament == null)
                {
                    var ex = new NullReferenceException($"Error while updating departament. Departament with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentDepartament.Name = departament.Name;
                currentDepartament.Country = departament.Country;
                currentDepartament.City = departament.City;
                currentDepartament.Street = departament.Street;
                currentDepartament.HouseNumber = departament.HouseNumber;

                _departamentRepository.Update(currentDepartament);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentDepartament);
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
            }

            try
            {
                var departament = await _departamentRepository.Get(x => x.Id == id);
                _departamentRepository.Remove(departament);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }

            return Ok();
        }
    }
}
