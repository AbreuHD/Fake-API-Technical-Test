using API.Controllers.General;
using Core.Application.DTOs;
using Core.Application.Services.FakeAPI;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksController : GeneralApiControllerBase
    {
        public readonly FakeAPIService _apiService;

        public BooksController(FakeAPIService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _apiService.GetBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await _apiService.GetBookById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _apiService.AddBook(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _apiService.UpdateBook(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return Ok(await _apiService.DeleteBook(id));
        }

    }
}
