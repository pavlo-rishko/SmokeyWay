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
    [Route("api/gameConsoleTypes")]
    [ApiController]
    public class GameConsoleTypeController : ControllerBase
    {
        private readonly IGenericRepository<GameConsoleType> _gameConsoleTypeRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<GameConsoleType> _validator;

        private readonly ILogger _logger;

        public GameConsoleTypeController(IUnitOfWork unitOfWork, IValidator<GameConsoleType> validator, ILogger<GameConsoleTypeController> logger)
        {
            _unitOfWork = unitOfWork;
            _gameConsoleTypeRepository = unitOfWork.GetRepository<GameConsoleType>();
            _validator = validator;
            _logger = logger;
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
                var ex = new ArgumentException($"{nameof(id)} can't be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var gameConsoleType = await _gameConsoleTypeRepository.Get(x => x.Id == id);
                return Ok(gameConsoleType);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]GameConsoleType gameConsoleType)
        {
            if (gameConsoleType == null)
            {
                var ex = new ArgumentException($"{nameof(gameConsoleType)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(gameConsoleType).IsValid)
            {
                var ex = new ArgumentException($"{nameof(gameConsoleType)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _gameConsoleTypeRepository.Add(gameConsoleType);
                await _unitOfWork.SaveChangesAsync();
                return Ok(gameConsoleType);
            }
            catch
            {
                var ex = new Exception($"Error while adding game console type nameof{nameof(gameConsoleType)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]GameConsoleType gameConsoleType)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(gameConsoleType).IsValid)
            {
                var ex = new ArgumentException($"{nameof(gameConsoleType)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentGameConsoleType = await _gameConsoleTypeRepository.Get(x => x.Id == id);

                if (currentGameConsoleType == null)
                {
                    var ex = new NullReferenceException($"Error while updating game console type. Game console type with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentGameConsoleType.Name = gameConsoleType.Name;

                _gameConsoleTypeRepository.Update(currentGameConsoleType);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentGameConsoleType);
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
                var gameConsoleType = await _gameConsoleTypeRepository.Get(x => x.Id == id);
                _gameConsoleTypeRepository.Remove(gameConsoleType);
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
