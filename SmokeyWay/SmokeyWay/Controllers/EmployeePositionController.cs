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
    [Route("api/employeePositions")]
    [ApiController]
    public class EmployeePositionController : ControllerBase
    {
        private readonly IGenericRepository<EmployeePosition> _employeePositionRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<EmployeePosition> _validator;

        private readonly ILogger _logger;

        public EmployeePositionController(IUnitOfWork unitOfWork, IValidator<EmployeePosition> validator, ILogger<EmployeePositionController> logger)
        {
            _unitOfWork = unitOfWork;
            _employeePositionRepository = unitOfWork.GetRepository<EmployeePosition>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _employeePositionRepository.GetAll();
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
                var employeePosition = await _employeePositionRepository.Get(x => x.Id == id);
                return Ok(employeePosition);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]EmployeePosition employeePosition)
        {
            if (employeePosition == null)
            {
                var ex = new ArgumentException($"{nameof(employeePosition)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(employeePosition).IsValid)
            {
                var ex = new ArgumentException($"{nameof(employeePosition)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _employeePositionRepository.Add(employeePosition);
                await _unitOfWork.SaveChangesAsync();
                return Ok(employeePosition);
            }
            catch
            {
                var ex = new Exception($"Error while adding employee nameof{nameof(employeePosition)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]EmployeePosition employeePosition)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(employeePosition).IsValid)
            {
                var ex = new ArgumentException($"{nameof(employeePosition)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentEmployeePosition = await _employeePositionRepository.Get(x => x.Id == id);

                if (currentEmployeePosition == null)
                {
                    var ex = new NullReferenceException($"Error while updating employee. Employee with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentEmployeePosition.Name = employeePosition.Name;
                currentEmployeePosition.Description = employeePosition.Description;

                _employeePositionRepository.Update(currentEmployeePosition);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentEmployeePosition);
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
                var employee = await _employeePositionRepository.Get(x => x.Id == id);
                _employeePositionRepository.Remove(employee);
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
