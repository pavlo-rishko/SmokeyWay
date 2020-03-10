using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SmokeyWay.Controllers
{
    [Route("api/gameConsoles")]
    [ApiController]
    public class GameConsoleController : ControllerBase
    {
        private readonly IGenericRepository<GameConsole> _gameConsoleRepository;

        private readonly IUnitOfWork _unitOfWork;

        public GameConsoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _gameConsoleRepository = unitOfWork.GetRepository<GameConsole>();
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _gameConsoleRepository.GetAll();
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
                var gameConsole = await _gameConsoleRepository.Get(x => x.Id == id);
                return Ok(gameConsole);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]GameConsole gameConsole)
        {
            if (gameConsole == null)
            {
                throw new ArgumentException($"{nameof(gameConsole)} can't be null");
            }

            try
            {
                _gameConsoleRepository.Add(gameConsole);
                await _unitOfWork.SaveChangesAsync();
                return Ok(gameConsole);
            }
            catch
            {
                throw new Exception($"Error while adding game console nameof{nameof(gameConsole)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]GameConsole gameConsole)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                var currentGameConsole = await _gameConsoleRepository.Get(x => x.Id == id);

                if (currentGameConsole == null)
                {
                    throw new NullReferenceException($"Error while updating game gonsole. Game console with {nameof(id)}={id} not found");
                }

                currentGameConsole.GameConsoleTypeId = gameConsole.GameConsoleTypeId;

                _gameConsoleRepository.Update(currentGameConsole);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentGameConsole);
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
                var gameConsole = await _gameConsoleRepository.Get(x => x.Id == id);
                _gameConsoleRepository.Remove(gameConsole);
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
