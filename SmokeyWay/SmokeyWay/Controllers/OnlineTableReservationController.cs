using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
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

        public OnlineTableReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _onlineTableReservationRepository = unitOfWork.GetRepository<OnlineTableReservation>();
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
                throw new ArgumentException($"{nameof(id)} can't be 0");
            }

            try
            {
                var onlineTableReservation = await _onlineTableReservationRepository.Get(x => x.Id == id);
                return Ok(onlineTableReservation);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]OnlineTableReservation onlineTableReservation)
        {
            if (onlineTableReservation == null)
            {
                throw new ArgumentException($"{nameof(onlineTableReservation)} can't be null");
            }

            try
            {
                _onlineTableReservationRepository.Add(onlineTableReservation);
                await _unitOfWork.SaveChangesAsync();
                return Ok(onlineTableReservation);
            }
            catch
            {
                throw new Exception($"Error while adding onlineTableReservation nameof{nameof(onlineTableReservation)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]OnlineTableReservation onlineTableReservation)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                var currentOnlineTableReservation = await _onlineTableReservationRepository.Get(x => x.Id == id);

                if (currentOnlineTableReservation == null)
                {
                    throw new NullReferenceException($"Error while updating online table reservation. Online table reservation with {nameof(id)}={id} not found");
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
                var onlineTableReservation = await _onlineTableReservationRepository.Get(x => x.Id == id);
                _onlineTableReservationRepository.Remove(onlineTableReservation);
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
