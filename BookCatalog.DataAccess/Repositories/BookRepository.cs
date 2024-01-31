using BookCatalog.DataAccess.Attributes;
using BookCatalog.Entities.Data;
using BookCatalog.Entities.DTOs;
using BookCatalog.Entities.Models;
using BookCatalog.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookCatalog.DataAccess.Repositories
{
    [Repository]
    public class BookRepository : IBookRepository
    {
        private readonly BookCatalogDbContext dbContext;
        private readonly ILogger<BookRepository> logger;

        public BookRepository(BookCatalogDbContext dbContext, ILogger<BookRepository> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<List<Book>> GetAll(PaginationDTO request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Filter))
                {
                    var result = await dbContext.Books.OrderBy(book => book.Id)
                        .Skip((request.PageIndex - 1) * request.PageSize)
                        .Take(request.PageSize).ToListAsync();

                    return result;
                }
                else
                {
                    var result = await dbContext.Books
                        .Where(book => book.Title.Contains(request.Filter) || book.Description.Contains(request.Filter))
                        .OrderBy(book => book.Id)
                        .Skip((request.PageIndex - 1) * request.PageSize)
                        .Take(request.PageSize).ToListAsync();

                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Fetching Books!");
                throw;
            }
        }
        public async Task<Book> GetOne(long Id)
        {
            try
            {
                var existingBook = await dbContext.Books.FindAsync(Id);

                if (existingBook == null)
                {
                    logger.LogWarning($"Book with ID {Id} not found for update.");
                    return null;
                }

                return existingBook;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Fetching book with ID: {Id}");
                throw;
            }
        }
        public async Task<Book> Add(Book book)
        {
            try
            {
                var result = await dbContext.Books.AddAsync(book);
                await dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Adding Book!");
                throw;
            }
        }

        public async Task<Book> Update(Book book)
        {
            try
            {
                var existingBook = await dbContext.Books.FindAsync(book.Id);

                if (existingBook == null)
                {
                    logger.LogWarning($"Book with ID {book.Id} not found for update.");
                    return null;
                }

                dbContext.Entry(existingBook).CurrentValues.SetValues(book);

                await dbContext.SaveChangesAsync();

                return existingBook;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error updating book with ID: {book.Id}");
                throw;
            }
        }

        public async Task<bool> Delete(long Id)
        {
            try
            {
                var existingBook = await dbContext.Books.FindAsync(Id);

                if (existingBook == null)
                {
                    logger.LogWarning($"Book with ID {Id} not found for update.");
                    return false;
                }

                dbContext.Books.Remove(existingBook);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Deleting book with ID: {Id}");
                throw;
            }
        }
    }
}
