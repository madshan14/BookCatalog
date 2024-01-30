using BookCatalog.BusinessRules.Repositories;
using BookCatalog.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;

        public BookController(IBookService service)
        {
            this.service = service;
        }

        [HttpGet("filter")]
        public async Task<ActionResult> GetAllBooks(string filter)
        {
            var result = await service.GetAll(filter);
            return Ok(result);
        }
    }
}
