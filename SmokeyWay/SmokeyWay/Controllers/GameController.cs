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
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGenericRepository<Game> _gameRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<Game> _validator;

        private readonly ILogger _logger;

        public GameController(IUnitOfWork unitOfWork, IValidator<Game> validator, ILogger<GameController> logger)
        {
            _unitOfWork = unitOfWork;
            _gameRepository = unitOfWork.GetRepository<Game>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _gameRepository.GetAll();
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
                var game = await _gameRepository.Get(x => x.Id == id);
                return Ok(game);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Game game)
        {
            if (game == null)
            {
                var ex = new ArgumentException($"{nameof(game)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(game).IsValid)
            {
                var ex = new ArgumentException($"{nameof(game)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _gameRepository.Add(game);
                await _unitOfWork.SaveChangesAsync();
                return Ok(game);
            }
            catch
            {
                var ex = new Exception($"Error while adding game nameof{nameof(game)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Game game)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(game).IsValid)
            {
                var ex = new ArgumentException($"{nameof(game)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentGame = await _gameRepository.Get(x => x.Id == id);

                if (currentGame == null)
                {
                    var ex = new NullReferenceException($"Error while updating game. Game with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentGame.Name = game.Name;
                currentGame.Description = game.Description;
                currentGame.LicenseBeginDate = game.LicenseBeginDate;
                currentGame.LicenseEndDate = game.LicenseEndDate;

                _gameRepository.Update(currentGame);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentGame);
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
                var game = await _gameRepository.Get(x => x.Id == id);
                _gameRepository.Remove(game);
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
