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
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IGenericRepository<Department> _departmentRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator _validator;

        public DepartmentController(IUnitOfWork unitOfWork, IValidator validator)
        {
            _unitOfWork = unitOfWork;
            _departmentRepository = unitOfWork.GetRepository<Department>();
            _validator = validator;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _departmentRepository.GetAll();
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
                var department = await _departmentRepository.Get(x => x.Id == id);
                return Ok(department);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Department department)
        {
            if (department == null)
            {
                throw new ArgumentException($"{nameof(department)} can't be null");
            }

            var validationResult = _validator.Validate(department);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"{nameof(department)} is not valid");
            }

            try
            {
                _departmentRepository.Add(department);
                await _unitOfWork.SaveChangesAsync();
                return Ok(department);
            }
            catch
            {
                throw new Exception($"Error while adding department nameof{nameof(department)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Department department)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                var currentDepartment = await _departmentRepository.Get(x => x.Id == id);

                if (currentDepartment == null)
                {
                    throw new NullReferenceException($"Error while updating department. Department with {nameof(id)}={id} not found");
                }

                currentDepartment.Name = department.Name;
                currentDepartment.Country = department.Country;
                currentDepartment.City = department.City;
                currentDepartment.Street = department.Street;
                currentDepartment.HouseNumber = department.HouseNumber;

                _departmentRepository.Update(currentDepartment);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentDepartment);
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
                var department = await _departmentRepository.Get(x => x.Id == id);
                _departmentRepository.Remove(department);
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
