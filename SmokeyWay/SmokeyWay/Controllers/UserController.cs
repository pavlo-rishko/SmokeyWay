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
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<User> _validator;

        private readonly ILogger _logger;

        public UserController(IUnitOfWork unitOfWork, IValidator<User> validator, ILogger<UserController> logger)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.GetRepository<User>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _userRepository.GetAll();
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
                var user = await _userRepository.Get(x => x.Id == id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]User user)
        {
            if (user == null)
            {
                var ex = new ArgumentException($"{nameof(user)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            var validationResult = _validator.Validate(user);
            if (!validationResult.IsValid)
            {
                var ex = new ArgumentException($"{nameof(user)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _userRepository.Add(user);
                await _unitOfWork.SaveChangesAsync();
                return Ok(user);
            }
            catch
            {
                var ex = new Exception($"Error while adding user nameof{nameof(user)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]User user)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            var validationResult = _validator.Validate(user);
            if (!validationResult.IsValid)
            {
                var ex = new ArgumentException($"{nameof(user)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentUser = await _userRepository.Get(x => x.Id == id);

                if (currentUser == null)
                {
                    var ex = new NullReferenceException($"Error while updating user. User with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentUser.Name = user.Name;
                currentUser.PhoneNumber = user.Name;
                currentUser.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                currentUser.Email = user.Email;
                currentUser.EmailConfirmed = user.PhoneNumberConfirmed;
                currentUser.PhoneNumber = user.PhoneNumber;
                currentUser.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                currentUser.BirthDate = user.BirthDate;
                currentUser.GenderId = user.GenderId;
                currentUser.CommunicationLanguage = user.CommunicationLanguage;
                currentUser.RoleId = user.RoleId;

                _userRepository.Update(currentUser);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentUser);
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
                var user = await _userRepository.Get(x => x.Id == id);
                _userRepository.Remove(user);
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
