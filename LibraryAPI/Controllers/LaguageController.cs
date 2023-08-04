using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public LanguageController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Languages.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Languages.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(LanguageModel language)
        {
            var data = await unitOfWork.Languages.Add(language);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Languages.Remove(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(LanguageModel language)
        {
            var data = await unitOfWork.Languages.Update(language);
            return Ok(data);
        }
        [HttpGet("Name/{languageName}")]
        public async Task<IActionResult> GetLanguageIdByName(string languageName)
        {
            var data = await unitOfWork.Languages.GetLanguageIdByName(languageName);
            if (data == null) return Ok();
            return Ok(data);
        }
    }
}
