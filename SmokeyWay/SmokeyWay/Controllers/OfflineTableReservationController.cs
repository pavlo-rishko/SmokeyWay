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
    [Route("api/offlineTableReservations")]
    [ApiController]
    public class OfflineTableReservationController : ControllerBase
    {
        private readonly IGenericRepository<OfflineTableReservation> _offlineTableReservationRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<OfflineTableReservation> _validator;

        private readonly ILogger _logger;

        public OfflineTableReservationController(
            IUnitOfWork unitOfWork, 
            IValidator<OfflineTableReservation> validator,
            ILogger<OfflineTableReservationController> logger)
        {
            _unitOfWork = unitOfWork;
            _offlineTableReservationRepository = unitOfWork.GetRepository<OfflineTableReservation>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _offlineTableReservationRepository.GetAll();
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
                var offlineTableReservation = await _offlineTableReservationRepository.Get(x => x.Id == id);
                return Ok(offlineTableReservation);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]OfflineTableReservation offlineTableReservation)
        {
            if (offlineTableReservation == null)
            {
                var ex = new ArgumentException($"{nameof(offlineTableReservation)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(offlineTableReservation).IsValid)
            {
                var ex = new ArgumentException($"{nameof(offlineTableReservation)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _offlineTableReservationRepository.Add(offlineTableReservation);
                await _unitOfWork.SaveChangesAsync();
                return Ok(offlineTableReservation);
            }
            catch
            {
                var ex = new Exception($"Error while adding offline table reservation nameof{nameof(offlineTableReservation)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]OfflineTableReservation offlineTableReservation)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(offlineTableReservation).IsValid)
            {
                var ex = new ArgumentException($"{nameof(offlineTableReservation)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentOfflineTableReservation = await _offlineTableReservationRepository.Get(x => x.Id == id);

                if (currentOfflineTableReservation == null)
                {
                    var ex = new NullReferenceException($"Error while updating offline table rReservation. Offline table reservation with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentOfflineTableReservation.TableId = offlineTableReservation.TableId;
                currentOfflineTableReservation.ClientName = offlineTableReservation.ClientName;
                currentOfflineTableReservation.ClientPhoneNumber = offlineTableReservation.ClientPhoneNumber;
                currentOfflineTableReservation.EmployeeId = offlineTableReservation.EmployeeId;

                _offlineTableReservationRepository.Update(currentOfflineTableReservation);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentOfflineTableReservation);
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
                var offlineTableReservation = await _offlineTableReservationRepository.Get(x => x.Id == id);
                _offlineTableReservationRepository.Remove(offlineTableReservation);
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
