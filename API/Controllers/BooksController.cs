using API.Controllers.General;
using Core.Application.DTOs;
using Core.Application.Services.FakeAPI;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            var bookResponse = await _apiService.GetBooks();
            return StatusCode((int)bookResponse.StatusCode, bookResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var bookResponse = await _apiService.GetBookById(id);
            return StatusCode((int)bookResponse.StatusCode, bookResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookResponse = await _apiService.AddBook(request);
            return StatusCode((int)bookResponse.StatusCode, bookResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookResponse = await _apiService.UpdateBook(id, request);
            return StatusCode((int)bookResponse.StatusCode, bookResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var bookResponse = await _apiService.DeleteBook(id);
            return StatusCode((int)bookResponse.StatusCode, bookResponse);
        }
    }
}
