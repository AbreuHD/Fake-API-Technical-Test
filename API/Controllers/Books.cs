using API.Controllers.General;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class Books : GeneralApiControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById()
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBook()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook()
        {
            return Ok();
        }

    }
}
