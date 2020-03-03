using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace SmokeyWay.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.GetRepository<User>();
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
                throw new ArgumentException($"{nameof(id)} can't be 0");
            }

            try
            {
                var user = await _userRepository.Get(x => x.Id == id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]User user)
        {
            if (user == null)
            {
                throw new ArgumentException($"{nameof(user)} can't be null");
            }

            try
            {
                _userRepository.Add(user);
                await _unitOfWork.SaveChangesAsync();
                return Ok(user);
            }
            catch
            {
                throw new Exception($"Error while adding user nameof{nameof(user)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]User user)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                var currentUser = await _userRepository.Get(x => x.Id == id);

                if (currentUser == null)
                {
                    throw new NullReferenceException($"Error while updating user. User with {nameof(id)}={id} not found");
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
                var user = await _userRepository.Get(x => x.Id == id);
                _userRepository.Remove(user);
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
