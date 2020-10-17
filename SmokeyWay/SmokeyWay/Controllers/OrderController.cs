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
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IGenericRepository<Order> _orderRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<Order> _validator;

        private readonly ILogger _logger;

        public OrderController(IUnitOfWork unitOfWork, IValidator<Order> validator, ILogger<OrderController> logger)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = unitOfWork.GetRepository<Order>();
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public IQueryable GetAll()
        {
            return _orderRepository.GetAll();
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
                var order = await _orderRepository.Get(x => x.Id == id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Order order)
        {
            if (order == null)
            {
                var ex = new ArgumentException($"{nameof(order)} can't be null");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(order).IsValid)
            {
                var ex = new ArgumentException($"{nameof(order)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                _orderRepository.Add(order);
                await _unitOfWork.SaveChangesAsync();
                return Ok(order);
            }
            catch
            {
                var ex = new Exception($"Error while adding order nameof{nameof(order)}");
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Order order)
        {
            if (id == default)
            {
                var ex = new ArgumentException($"{nameof(id)} cannot be 0");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            if (!_validator.Validate(order).IsValid)
            {
                var ex = new ArgumentException($"{nameof(order)} is not valid");
                _logger.LogError(ex.ToString());
                throw ex;
            }

            try
            {
                var currentOrder = await _orderRepository.Get(x => x.Id == id);

                if (currentOrder == null)
                {
                    var ex = new NullReferenceException($"Error while updating order. Order with {nameof(id)}={id} not found");
                    _logger.LogError(ex.ToString());
                    throw ex;
                }

                currentOrder.TableId = order.TableId;
                currentOrder.EmployeeId = order.EmployeeId;

                _orderRepository.Update(currentOrder);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentOrder);
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
                var order = await _orderRepository.Get(x => x.Id == id);
                _orderRepository.Remove(order);
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
