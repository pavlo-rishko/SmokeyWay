﻿using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeyWay.Controllers
{
    [Route("api/employeePositions")]
    [ApiController]
    public class EmployeePositionController : ControllerBase
    {
        private readonly IGenericRepository<EmployeePosition> _employeePositionRepository;

        private readonly IUnitOfWork _unitOfWork;

        public EmployeePositionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _employeePositionRepository = unitOfWork.GetRepository<EmployeePosition>();
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _employeePositionRepository.GetAll();
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
                var employeePosition = await _employeePositionRepository.Get(x => x.Id == id);
                return Ok(employeePosition);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]EmployeePosition employeePosition)
        {
            if (employeePosition == null)
            {
                throw new ArgumentException($"{nameof(employeePosition)} can't be null");
            }

            try
            {
                _employeePositionRepository.Add(employeePosition);
                await _unitOfWork.SaveChangesAsync();
                return Ok(employeePosition);
            }
            catch
            {
                throw new Exception($"Error while adding employee nameof{nameof(employeePosition)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]EmployeePosition employeePosition)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                var currentEmployeePosition = await _employeePositionRepository.Get(x => x.Id == id);

                if (currentEmployeePosition == null)
                {
                    throw new NullReferenceException($"Error while updating employee. Employee with {nameof(id)}={id} not found");
                }

                currentEmployeePosition.Name = employeePosition.Name;
                currentEmployeePosition.Description = employeePosition.Description;

                _employeePositionRepository.Update(currentEmployeePosition);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentEmployeePosition);
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
                var employee = await _employeePositionRepository.Get(x => x.Id == id);
                _employeePositionRepository.Remove(employee);
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