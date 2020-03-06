using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeyWay.Controllers
{
    [Route("api/userRoles")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenericRepository<UserRole> _userRoleRepository;

        private readonly IValidator<UserRole> _validator;

        public UserRoleController(IUnitOfWork unitOfWork, IValidator<UserRole> validator)
        {
            _unitOfWork = unitOfWork;
            _userRoleRepository = unitOfWork.GetRepository<UserRole>();
            _validator = validator;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _userRoleRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} can`t be 0");
            }

            try
            {
                var dishtype = await _userRoleRepository.Get(e => e.Id == id);
                return Ok(dishtype);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]UserRole userRole)
        {
            var validationResult = _validator.Validate(userRole);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"{nameof(userRole)} is not valid");
            }

            try
            {
                _userRoleRepository.Add(userRole);
                await _unitOfWork.SaveChangesAsync();
                return Ok(userRole);
            }
            catch (Exception ex)
            {
                ex.Data["userRole"] = userRole;
                throw;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]UserRole userRole)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} can`t be 0");
            }

            var validationResult = _validator.Validate(userRole);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"{nameof(userRole)} is not valid");
            }

            try
            {
                var currentUserRole = await _userRoleRepository.Get(e => e.Id == id);

                if (currentUserRole == null)
                {
                    throw new NullReferenceException($"Error while updating userRole. UserRole with {nameof(id)}={id} not found");
                }

                currentUserRole.Name = userRole.Name;
                _userRoleRepository.Update(currentUserRole);
                await _unitOfWork.SaveChangesAsync();
                return Ok(currentUserRole);
            }
            catch (Exception ex)
            {
                ex.Data["userRole"] = userRole;
                throw;
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} can`t be 0");
            }

            try
            {
                UserRole userRole = await _userRoleRepository.Get(e => e.Id == id);
                _userRoleRepository.Remove(userRole);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }
    }
}