using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GenereController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public GenereController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Generes.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Generes.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(GenereModel genere)
        {
            var data = await unitOfWork.Generes.Add(genere);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Generes.Remove(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(GenereModel genere)
        {
            var data = await unitOfWork.Generes.Update(genere);
            return Ok(data);
        }
        [HttpGet("Name/{genereName}")]
        public async Task<IActionResult> GetGenereIdByName(string genereName)
        {
            var data = await unitOfWork.Generes.GetGenereIdByName(genereName);
            if (data == null) return Ok();
            return Ok(data);
        }
    }
}

