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
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<Employee> _validator;

        public EmployeeController(IUnitOfWork unitOfWork, IValidator<Employee> validator)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = unitOfWork.GetRepository<Employee>();
            _validator = validator;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _employeeRepository.GetAll();
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
                var employee = await _employeeRepository.Get(x => x.Id == id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException($"{nameof(employee)} can't be null");
            }

            var validationResult = _validator.Validate(employee);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"{nameof(employee)} is not valid");
            }

            try
            {
                _employeeRepository.Add(employee);
                await _unitOfWork.SaveChangesAsync();
                return Ok(employee);
            }
            catch
            {
                throw new Exception($"Error while adding employee nameof{nameof(employee)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Employee employee)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            var validationResult = _validator.Validate(employee);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"{nameof(employee)} is not valid");
            }

            try
            {
                var currentEmployee = await _employeeRepository.Get(x => x.Id == id);

                if (currentEmployee == null)
                {
                    throw new NullReferenceException($"Error while updating employee. Employee with {nameof(id)}={id} not found");
                }

                currentEmployee.FirstName = employee.FirstName;
                currentEmployee.LastName = employee.LastName;
                currentEmployee.DepartamentId = employee.DepartamentId;
                currentEmployee.PhoneNumber = employee.PhoneNumber;
                currentEmployee.PositionId = employee.PositionId;
                currentEmployee.GenderId = employee.GenderId;
                currentEmployee.BirthDate = employee.BirthDate;

                _employeeRepository.Update(currentEmployee);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentEmployee);
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
                var employee = await _employeeRepository.Get(x => x.Id == id);
                _employeeRepository.Remove(employee);
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
