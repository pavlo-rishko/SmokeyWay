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
    [Route("api/genders")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenericRepository<Gender> _genderRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<Gender> _validator;

        private readonly ILogger _logger;

        public GenderController(IUnitOfWork unitOfWork, IValidator<Gender> validator, ILogger<GenderController> logger)
        {
            _unitOfWork = unitOfWork;
            _genderRepository = unitOfWork.GetRepository<Gender>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _genderRepository.GetAll();
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
                var gender = await _genderRepository.Get(x => x.Id == id);
                return Ok(gender);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Gender gender)
        {
            if (gender == null)
            {
                var ex = new ArgumentException($"{nameof(gender)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(gender).IsValid)
            {
                var ex = new ArgumentException($"{nameof(gender)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _genderRepository.Add(gender);
                await _unitOfWork.SaveChangesAsync();
                return Ok(gender);
            }
            catch
            {
                var ex = new Exception($"Error while adding gender nameof{nameof(gender)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Gender gender)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(gender).IsValid)
            {
                var ex = new ArgumentException($"{nameof(gender)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentGender = await _genderRepository.Get(x => x.Id == id);

                if (currentGender == null)
                {
                    var ex = new NullReferenceException($"Error while updating gender. Gender with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentGender.Name = gender.Name;
                currentGender.Descriprion = gender.Descriprion;

                _genderRepository.Update(currentGender);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentGender);
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
                var gender = await _genderRepository.Get(x => x.Id == id);
                _genderRepository.Remove(gender);
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
