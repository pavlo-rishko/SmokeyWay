﻿using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
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

        public OfflineTableReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _offlineTableReservationRepository = unitOfWork.GetRepository<OfflineTableReservation>();
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
                throw new ArgumentException($"{nameof(id)} can't be 0");
            }

            try
            {
                var offlineTableReservation = await _offlineTableReservationRepository.Get(x => x.Id == id);
                return Ok(offlineTableReservation);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]OfflineTableReservation offlineTableReservation)
        {
            if (offlineTableReservation == null)
            {
                throw new ArgumentException($"{nameof(offlineTableReservation)} can't be null");
            }

            try
            {
                _offlineTableReservationRepository.Add(offlineTableReservation);
                await _unitOfWork.SaveChangesAsync();
                return Ok(offlineTableReservation);
            }
            catch
            {
                throw new Exception($"Error while adding offline table reservation nameof{nameof(offlineTableReservation)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]OfflineTableReservation offlineTableReservation)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                var currentOfflineTableReservation = await _offlineTableReservationRepository.Get(x => x.Id == id);

                if (currentOfflineTableReservation == null)
                {
                    throw new NullReferenceException($"Error while updating offline table rReservation. Offline table reservation with {nameof(id)}={id} not found");
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
                var offlineTableReservation = await _offlineTableReservationRepository.Get(x => x.Id == id);
                _offlineTableReservationRepository.Remove(offlineTableReservation);
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
