using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
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

        public GameController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _gameRepository = unitOfWork.GetRepository<Game>();
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
                throw new ArgumentException($"{nameof(id)} can't be 0");
            }

            try
            {
                var game = await _gameRepository.Get(x => x.Id == id);
                return Ok(game);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Game game)
        {
            if (game == null)
            {
                throw new ArgumentException($"{nameof(game)} can't be null");
            }

            try
            {
                _gameRepository.Add(game);
                await _unitOfWork.SaveChangesAsync();
                return Ok(game);
            }
            catch
            {
                throw new Exception($"Error while adding game nameof{nameof(game)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Game game)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                Game currentGame = await _gameRepository.Get(x => x.Id == id);

                if (currentGame == null)
                {
                    throw new NullReferenceException($"Error while updating game. Game with {nameof(id)}={id} not found");
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
                var game = await _gameRepository.Get(x => x.Id == id);
                _gameRepository.Remove(game);
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
