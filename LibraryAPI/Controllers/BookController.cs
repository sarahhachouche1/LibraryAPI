using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Books.GetAll();
            return Ok(data);
        }
        [HttpGet("Author/{authorName}")]
        public async Task<IActionResult> GetBooksByAuthorName(string authorName)
        {
            var data = await unitOfWork.Books.GetBooksByAuthorName(authorName);
            return Ok(data);
        }
        [HttpGet("Language/{languageName}")]
        public async Task<IActionResult> GetBooksByLanguage(string languageName)
        {
            var data = await unitOfWork.Books.GetBooksByLanguage(languageName);
            return Ok(data);
        }
        [HttpGet("Genere/{GenereName}")]
        public async Task<IActionResult> GetBooksByGenere(string genereName)
        {
            var data = await unitOfWork.Books.GetBooksByGenere(genereName);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Books.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookModel book)
        {
            var data = await unitOfWork.Books.Add(book);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Books.Remove(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(BookModel book)
        {
            var data = await unitOfWork.Books.Update(book);
            return Ok(data);
        }
    }
}
