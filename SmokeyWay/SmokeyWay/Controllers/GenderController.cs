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
    [Route("api/genders")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenericRepository<Gender> _genderRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator _validator;

        public GenderController(IUnitOfWork unitOfWork, IValidator validator)
        {
            _unitOfWork = unitOfWork;
            _genderRepository = unitOfWork.GetRepository<Gender>();
            _validator = validator;
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
                throw new ArgumentException($"{nameof(id)} can't be 0");
            }

            try
            {
                var gender = await _genderRepository.Get(x => x.Id == id);
                return Ok(gender);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Gender gender)
        {
            if (gender == null)
            {
                throw new ArgumentException($"{nameof(gender)} can't be null");
            }

            var validationResult = _validator.Validate(gender);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"{nameof(gender)} is not valid");
            }

            try
            {
                _genderRepository.Add(gender);
                await _unitOfWork.SaveChangesAsync();
                return Ok(gender);
            }
            catch
            {
                throw new Exception($"Error while adding gender nameof{nameof(gender)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Gender gender)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                var currentGender = await _genderRepository.Get(x => x.Id == id);

                if (currentGender == null)
                {
                    throw new NullReferenceException($"Error while updating gender. Gender with {nameof(id)}={id} not found");
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
                var gender = await _genderRepository.Get(x => x.Id == id);
                _genderRepository.Remove(gender);
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
