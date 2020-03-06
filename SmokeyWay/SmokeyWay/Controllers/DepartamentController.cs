using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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

        public DepartamentController(IUnitOfWork unitOfWork, IValidator validator)
        {
            _unitOfWork = unitOfWork;
            _departamentRepository = unitOfWork.GetRepository<Departament>();
            _validator = validator;
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
                throw new ArgumentException($"{nameof(id)} can't be 0");
            }

            try
            {
                var departament = await _departamentRepository.Get(x => x.Id == id);
                return Ok(departament);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Departament departament)
        {
            if (departament == null)
            {
                throw new ArgumentException($"{nameof(departament)} can't be null");
            }

            var validationResult = _validator.Validate(departament);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"{nameof(departament)} is not valid");
            }

            try
            {
                _departamentRepository.Add(departament);
                await _unitOfWork.SaveChangesAsync();
                return Ok(departament);
            }
            catch
            {
                throw new Exception($"Error while adding departament nameof{nameof(departament)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Departament departament)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            var validationResult = _validator.Validate(departament);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"{nameof(departament)} is not valid");
            }

            try
            {
                var currentDepartament = await _departamentRepository.Get(x => x.Id == id);

                if (currentDepartament == null)
                {
                    throw new NullReferenceException($"Error while updating departament. Departament with {nameof(id)}={id} not found");
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
                var departament = await _departamentRepository.Get(x => x.Id == id);
                _departamentRepository.Remove(departament);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }

            return Ok();
        }
    }
}
