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
    [Route("api/tables")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IGenericRepository<Table> _tableRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<Table> _validator;

        private readonly ILogger _logger;

        public TableController(IUnitOfWork unitOfWork, IValidator<Table> validator, ILogger<TableController> logger)
        {
            _unitOfWork = unitOfWork;
            _tableRepository = unitOfWork.GetRepository<Table>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _tableRepository.GetAll();
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
                var table = await _tableRepository.Get(x => x.Id == id);
                return Ok(table);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Table table)
        {
            if (table == null)
            {
                var ex = new ArgumentException($"{nameof(table)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            var validationResult = _validator.Validate(table);
            if (!validationResult.IsValid)
            {
                var ex = new ArgumentException($"{nameof(table)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _tableRepository.Add(table);
                await _unitOfWork.SaveChangesAsync();
                return Ok(table);
            }
            catch
            {
                var ex = new Exception($"Error while adding table nameof{nameof(table)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Table table)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            var validationResult = _validator.Validate(table);
            if (!validationResult.IsValid)
            {
                var ex = new ArgumentException($"{nameof(table)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentTable = await _tableRepository.Get(x => x.Id == id);

                if (currentTable == null)
                {
                    var ex = new NullReferenceException($"Error while updating table. Table with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentTable.Identifier = table.Identifier;
                currentTable.DepartamentId = table.DepartamentId;
                currentTable.SeatingCapacity = table.SeatingCapacity;
                currentTable.GameConsoleId = table.GameConsoleId;

                _tableRepository.Update(currentTable);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentTable);
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
                var table = await _tableRepository.Get(x => x.Id == id);
                _tableRepository.Remove(table);
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
