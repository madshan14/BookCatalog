using BookCatalog.Entities.DTOs;
using BookCatalog.Entities.Models;
using BookCatalog.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;
        private readonly ILogger<BookController> logger;

        public BookController(IBookService service, ILogger<BookController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks([FromQuery] PaginationDTO request)
        {
            try
            {
                var result = await service.GetAll(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error GetAll");
                return BadRequest(ex);
            }
        }
        [HttpGet("Id")]
        public async Task<ActionResult> GetOneBook(long Id)
        {
            try
            {
                var result = await service.GetOneBook(Id);
                if (result == null)
                {
                    return NotFound(Id);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error GetOne");
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddBook(BookDTO book)
        {
            try
            {
                var result = await service.AddBook(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Add");
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateBook(BookDTO book)
        {
            try
            {
                var result = await service.UpdateBook(book);

                if (result == null)
                {
                    return NotFound(book);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Update");
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(long id)
        {
            try
            {
                var result = await service.DeleteBook(id);
                if (!result)
                {
                    return NotFound(id);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Delete");
                return BadRequest(ex);
            }
        }
    }
}
