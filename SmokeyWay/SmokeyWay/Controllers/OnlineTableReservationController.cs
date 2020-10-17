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
    [Route("api/onlineTableReservations")]
    [ApiController]
    public class OnlineTableReservationController : ControllerBase
    {
        private readonly IGenericRepository<OnlineTableReservation> _onlineTableReservationRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<OnlineTableReservation> _validator;

        private readonly ILogger _logger;

        public OnlineTableReservationController(
            IUnitOfWork unitOfWork,
            IValidator<OnlineTableReservation> validator,
            ILogger<OnlineTableReservationController> logger)
        {
            _unitOfWork = unitOfWork;
            _onlineTableReservationRepository = unitOfWork.GetRepository<OnlineTableReservation>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _onlineTableReservationRepository.GetAll();
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
                var onlineTableReservation = await _onlineTableReservationRepository.Get(x => x.Id == id);
                return Ok(onlineTableReservation);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]OnlineTableReservation onlineTableReservation)
        {
            if (onlineTableReservation == null)
            {
                var ex = new ArgumentException($"{nameof(onlineTableReservation)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }
            
            if (!_validator.Validate(onlineTableReservation).IsValid)
            {
                var ex = new ArgumentException($"{nameof(onlineTableReservation)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _onlineTableReservationRepository.Add(onlineTableReservation);
                await _unitOfWork.SaveChangesAsync();
                return Ok(onlineTableReservation);
            }
            catch
            {
                var ex = new Exception($"Error while adding onlineTableReservation nameof{nameof(onlineTableReservation)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]OnlineTableReservation onlineTableReservation)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(onlineTableReservation).IsValid)
            {
                var ex = new ArgumentException($"{nameof(onlineTableReservation)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentOnlineTableReservation = await _onlineTableReservationRepository.Get(x => x.Id == id);

                if (currentOnlineTableReservation == null)
                {
                    var ex = new NullReferenceException($"Error while updating online table reservation. Online table reservation with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentOnlineTableReservation.TableId = onlineTableReservation.TableId;
                currentOnlineTableReservation.UserId = onlineTableReservation.UserId;

                _onlineTableReservationRepository.Update(currentOnlineTableReservation);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentOnlineTableReservation);
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
                var onlineTableReservation = await _onlineTableReservationRepository.Get(x => x.Id == id);
                _onlineTableReservationRepository.Remove(onlineTableReservation);
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
