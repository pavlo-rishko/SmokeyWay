using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeyWay.Controllers
{
    [Route("api/dishTypes")]
    [ApiController]
    public class DishTypeController : ControllerBase
    {
        private readonly IDishTypeService _service;

        public DishTypeController(IDishTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} can not be 0");
            }

            var dishtype = await _service.GetById(id);
            return Ok(dishtype);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]DishType dish)
        {
            if (dish == null)
            {
                throw new ArgumentException($"{nameof(dish)} cannot be null");
            }

            await _service.Add(dish);
            return Ok(dish);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]DishType type)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            await _service.UpdateById(id, type);
            return Ok(type);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            await _service.RemoveById(id);
            return Ok();
        }
    }
}
