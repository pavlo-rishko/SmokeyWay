using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeyWay.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepositoryBase<Order> _orderRepository;

        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = unitOfWork.GetRepository<Order>();
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
                throw new ArgumentException($"{nameof(id)} can't be 0");
            }

            try
            {
                var order = await _orderRepository.Get(x => x.Id == id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                ex.Data["id"] = id;
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Order order)
        {
            if (order == null)
            {
                throw new ArgumentException($"{nameof(order)} can't be null");
            }

            try
            {
                _orderRepository.Add(order);
                await _unitOfWork.SaveChangesAsync();
                return Ok(order);
            }
            catch
            {
                throw new Exception($"Error while adding order nameof{nameof(order)}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody]Order order)
        {
            if (id == default)
            {
                throw new ArgumentException($"{nameof(id)} cannot be 0");
            }

            try
            {
                Order currentOrder = await _orderRepository.Get(x => x.Id == id);

                if (currentOrder == null)
                {
                    throw new NullReferenceException($"Error while updating order. Order with {nameof(id)}={id} not found");
                }

                currentOrder.DateTime = order.DateTime;
                currentOrder.TableId = order.TableId;
                currentOrder.EmployeeId = order.EmployeeId;

                _orderRepository.Update(currentOrder);
                await _unitOfWork.SaveChangesAsync();

                return Ok(currentOrder);
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
                var order = await _orderRepository.Get(x => x.Id == id);
                _orderRepository.Remove(order);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }
    }
}
