using BookCatalog.BusinessRules.Repositories;
using BookCatalog.DataAccess.Interfaces;
using BookCatalog.Entities.Attributes;
using BookCatalog.Entities.DTOs;
using BookCatalog.Entities.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.BusinessRules.Services
{
    [ServiceDependency]
    public class BookService : IBookService
    {
        private readonly IBookRepository repository;
        private readonly ILogger<BookService> logger;

        public BookService(IBookRepository repository, ILogger<BookService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<List<BookDTO>> GetAll(string filter)
        {
            try
            {
                List<BookDTO> result = new List<BookDTO>();
                if (string.IsNullOrEmpty(filter))
                {
                    var books = await repository.GetAll();
                    foreach (var book in books)
                    {
                        var convertedBook = MapToBookDTO(book);
                        result.Add(convertedBook);
                    }
                }
                else
                {
                    var books = await repository.GetWithFilter(filter);
                    foreach (var book in books)
                    {
                        var convertedBook = MapToBookDTO(book);
                        result.Add(convertedBook);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Fetching Data");
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
    }
}
