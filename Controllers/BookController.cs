using Library.API.Interfaces;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }


        [HttpGet("[action]")]
        public async Task<CustomResponseModel<IEnumerable<ViewBookModel>>> GetAll() => await _service.GetAll();

        [HttpGet("[action]/{id}")]
        public async Task<CustomResponseModel<ViewBookModel>> Get(int id) => await _service.Get(id);

        [HttpPost("[action]")]
        public async Task<CustomResponseModel<ViewBookModel>> Create([FromQuery] CreateBookModel createBookModel) => await _service.Create(createBookModel);

        [HttpDelete("[action]/{id}")]
        public async Task<CustomResponseModel<ViewBookModel>> Delete(int id) => await _service.Delete(id);
    }
}
