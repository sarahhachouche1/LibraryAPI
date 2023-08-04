using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Orders.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Orders.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderModel order)
        {
            var data = await unitOfWork.Orders.Add(order);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Orders.Remove(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(OrderModel order)
        {
            var data = await unitOfWork.Orders.Update(order);
            return Ok(data);
        }
        [HttpGet("Member/{memberID}")]
        public async Task<IActionResult> GetOrdersByMemberId(int memberid)
        {
            var data = await unitOfWork.Orders.GetOrdersByMemberId(memberid);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpGet("Status/{statusID}")]
        public async Task<IActionResult> GetOrdersByStatus(string status)
        {
            var data = await unitOfWork.Orders.GetOrdersByStatus(status);
            if (data == null) return Ok();
            return Ok(data);
        }

    }
}

