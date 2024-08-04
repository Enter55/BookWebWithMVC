using Contract.Dto.Books;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.Books;

namespace BooksWeb.Controllers.Books
{
    public class BooksController
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // api/values/GetAllBookse
        [HttpGet("GetAllBookse")]
        public async Task<IEnumerable<BooksDto>> Get()
        {
            return await _booksService.All();
        }

        // api/values/GetBookse/1
        [HttpGet("GetBookse/id")]

        public async Task<BooksDto> GetId(int id)
        {
            return await _booksService.GetId(id);
        }

        // api/values
        [HttpPost]
        public async Task<BooksDto> Post([FromBody] BooksDto books) //CreateLanguagesDto
        {
            return await _booksService.Create(books);
        }

        // api/value/1
        [HttpDelete("id")]
        public async Task Delete(int id)
        {
            await _booksService.Delete(id);
        }

        // api/values/Title/Neu
        [HttpPut("Title")]
        public async Task BooksUpdate([FromBody] BooksDto books)
        {
            await _booksService.Update(books);
        }
    }
}
