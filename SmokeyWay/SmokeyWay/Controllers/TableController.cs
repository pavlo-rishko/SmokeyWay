using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeyWay.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IRepositoryBase<Table> _tableRepository;

        private readonly IUnitOfWork _unitOfWork;

        public TableController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tableRepository = unitOfWork.GetRepository<Table>();
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
                throw new ArgumentException($"{nameof(id)} can't be 0");
            }

            try
            {
                var table = await _tableRepository.Get(x => x.Id == id);
                return Ok(table);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Table table)
        {
            if (table == null)
            {
                throw new ArgumentException($"{nameof(table)} can't be null");
            }

            try
            {
                _tableRepository.Add(table);
                await _unitOfWork.SaveChangesAsync();
                return Ok(table);
            }
            catch
            {
                throw new Exception($"Error while adding table nameof{nameof(table)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Table table)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                Table currentTable = await _tableRepository.Get(x => x.Id == id);

                if (currentTable == null)
                {
                    throw new NullReferenceException($"Error while updating table. Table with {nameof(id)}={id} not found");
                }

                currentTable.Identifier = table.Identifier;
                currentTable.DepartmentId = table.DepartmentId;
                currentTable.SeatingCapacity = table.SeatingCapacity;
                currentTable.GameConsoleId = table.GameConsoleId;

                _tableRepository.Update(currentTable);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentTable);
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
                var table = await _tableRepository.Get(x => x.Id == id);
                _tableRepository.Remove(table);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }
    }
}
