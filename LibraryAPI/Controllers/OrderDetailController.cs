using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderDetailController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.OrderDetails.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.OrderDetails.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(OrderDetailModel orderdetail)
        {
            var data = await unitOfWork.OrderDetails.Add(orderdetail);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.OrderDetails.Remove(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(OrderDetailModel orderdetail)
        {
            var data = await unitOfWork.OrderDetails.Update(orderdetail);
            return Ok(data);
        }
        [HttpGet("Order/{orderID}")]
        public async Task<IActionResult> GetLanguageIdByName(int orderId)
        {
            var data = await unitOfWork.OrderDetails.GetOrderDetailsByOrderId(orderId);
            if (data == null) return Ok();
            return Ok(data);
        }
    }
}
