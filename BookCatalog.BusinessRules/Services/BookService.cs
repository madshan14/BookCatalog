using BookCatalog.BusinessRules.Attributes;
using BookCatalog.Entities.DTOs;
using BookCatalog.Entities.Models;
using BookCatalog.Interfaces.Interfaces;
using BookCatalog.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace BookCatalog.BusinessRules.Services
{
    [Service]
    public class BookService : IBookService
    {
        private readonly IBookRepository repository;
        private readonly ILogger<BookService> logger;

        public BookService(IBookRepository repository, ILogger<BookService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<PaginationDTO<List<BookDTO>>> GetAll(PaginationDTO request)
        {
            try
            {
                PaginationDTO<List<BookDTO>> result = new PaginationDTO<List<BookDTO>>
                {
                    Result = new List<BookDTO>()
                };

                var books = await repository.GetAll(request);
                foreach (var book in books)
                {
                    var convertedBook = MapToBookDTO(book);
                    result.Result.Add(convertedBook);
                }

                result.PageCount = result.Result.Count();
                result.PageIndex = request.PageIndex;
                result.PageSize = request.PageSize;

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Fetching Data");
                throw;
            }
        }
        public async Task<BookDTO> GetOneBook(long Id)
        {
            try
            {
                var result = await repository.GetOne(Id);
                if (result == null)
                {
                    return null;
                }
                var book = MapToBookDTO(result);
                return book;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Fetching One Data");
                throw;
            }
        }
        public async Task<BookDTO> AddBook(BookDTO book)
        {
            try
            {
                Book request = MapToBook(book);
                var result = await repository.Add(request);
                var addedBook = MapToBookDTO(result);
                return addedBook;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Adding Data");
                throw;
            }
        }
        public async Task<BookDTO> UpdateBook(BookDTO book)
        {
            try
            {
                Book request = MapToBook(book);

                var result = await repository.Update(request);
                if(result == null)
                {
                    return null;
                }

                var updatedBook = MapToBookDTO(result);
                return updatedBook;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Updating Data");
                throw;
            }
        }
        public async Task<bool> DeleteBook(long Id)
        {
            try
            {
                var result = await repository.Delete(Id);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Updating Data");
                throw;
            }
        }

        private BookDTO MapToBookDTO(Book book)
        {
            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                PublishDateUtc = book.PublishDateUtc,
            };
        }
        private Book MapToBook(BookDTO book)
        {
            return new Book
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                PublishDateUtc = book.PublishDateUtc,
            };
        }
    }
}
