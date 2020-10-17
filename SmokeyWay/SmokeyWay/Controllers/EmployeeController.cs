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
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<Employee> _validator;

        private readonly ILogger _logger;

        public EmployeeController(IUnitOfWork unitOfWork, IValidator<Employee> validator, ILogger<EmployeeController> logger)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = unitOfWork.GetRepository<Employee>();
            _validator = validator;
            _logger = logger;
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
                var ex = new ArgumentException($"{nameof(id)} can't be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var employee = await _employeeRepository.Get(x => x.Id == id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Employee employee)
        {
            if (employee == null)
            {
                var ex = new ArgumentException($"{nameof(employee)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(employee).IsValid)
            {
                var ex = new ArgumentException($"{nameof(employee)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _employeeRepository.Add(employee);
                await _unitOfWork.SaveChangesAsync();
                return Ok(employee);
            }
            catch
            {
                var ex = new Exception($"Error while adding employee nameof{nameof(employee)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Employee employee)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            var validationResult = _validator.Validate(employee);
            if (!validationResult.IsValid)
            {
                var ex = new ArgumentException($"{nameof(employee)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentEmployee = await _employeeRepository.Get(x => x.Id == id);

                if (currentEmployee == null)
                {
                    var ex = new NullReferenceException($"Error while updating employee. Employee with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
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
                var employee = await _employeeRepository.Get(x => x.Id == id);
                _employeeRepository.Remove(employee);
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
