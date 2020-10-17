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
    [Route("api/gameConsoles")]
    [ApiController]
    public class GameConsoleController : ControllerBase
    {
        private readonly IGenericRepository<GameConsole> _gameConsoleRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<GameConsole> _validator;

        private readonly ILogger _logger;

        public GameConsoleController(IUnitOfWork unitOfWork, IValidator<GameConsole> validator, ILogger<GameConsoleController> logger)
        {
            _unitOfWork = unitOfWork;
            _gameConsoleRepository = unitOfWork.GetRepository<GameConsole>();
            _validator = validator;
            _logger = logger;
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
                var ex = new ArgumentException($"{nameof(id)} can't be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var gameConsole = await _gameConsoleRepository.Get(x => x.Id == id);
                return Ok(gameConsole);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]GameConsole gameConsole)
        {
            if (gameConsole == null)
            {
                var ex = new ArgumentException($"{nameof(gameConsole)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(gameConsole).IsValid)
            {
                var ex = new ArgumentException($"{nameof(gameConsole)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _gameConsoleRepository.Add(gameConsole);
                await _unitOfWork.SaveChangesAsync();
                return Ok(gameConsole);
            }
            catch
            {
                var ex = new Exception($"Error while adding game console nameof{nameof(gameConsole)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]GameConsole gameConsole)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(gameConsole).IsValid)
            {
                var ex = new ArgumentException($"{nameof(gameConsole)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentGameConsole = await _gameConsoleRepository.Get(x => x.Id == id);

                if (currentGameConsole == null)
                {
                    var ex = new NullReferenceException($"Error while updating game gonsole. Game console with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentGameConsole.GameConsoleTypeId = gameConsole.GameConsoleTypeId;

                _gameConsoleRepository.Update(currentGameConsole);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentGameConsole);
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
                var gameConsole = await _gameConsoleRepository.Get(x => x.Id == id);
                _gameConsoleRepository.Remove(gameConsole);
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
