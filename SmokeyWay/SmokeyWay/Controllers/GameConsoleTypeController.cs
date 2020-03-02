using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeyWay.Controllers
{
    [Route("api/gameConsoleTypes")]
    [ApiController]
    public class GameConsoleTypeController : ControllerBase
    {
        private readonly IRepositoryBase<GameConsoleType> _gameConsoleTypeRepository;

        private readonly IUnitOfWork _unitOfWork;

        public GameConsoleTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _gameConsoleTypeRepository = unitOfWork.GetRepository<GameConsoleType>();
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _gameConsoleTypeRepository.GetAll();
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
                var gameConsoleType = await _gameConsoleTypeRepository.Get(x => x.Id == id);
                return Ok(gameConsoleType);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]GameConsoleType gameConsoleType)
        {
            if (gameConsoleType == null)
            {
                throw new ArgumentException($"{nameof(gameConsoleType)} can't be null");
            }

            try
            {
                _gameConsoleTypeRepository.Add(gameConsoleType);
                await _unitOfWork.SaveChangesAsync();
                return Ok(gameConsoleType);
            }
            catch
            {
                throw new Exception($"Error while adding game console type nameof{nameof(gameConsoleType)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]GameConsoleType gameConsoleType)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                GameConsoleType currentGameConsoleType = await _gameConsoleTypeRepository.Get(x => x.Id == id);

                if (currentGameConsoleType == null)
                {
                    throw new NullReferenceException($"Error while updating game console type. Game console type with {nameof(id)}={id} not found");
                }

                currentGameConsoleType.Name = gameConsoleType.Name;

                _gameConsoleTypeRepository.Update(currentGameConsoleType);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentGameConsoleType);
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
                var gameConsoleType = await _gameConsoleTypeRepository.Get(x => x.Id == id);
                _gameConsoleTypeRepository.Remove(gameConsoleType);
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
