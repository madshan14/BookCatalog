using BookCatalog.Entities.DTOs;
using BookCatalog.Entities.Models;

namespace BookCatalog.Interfaces.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> Add(Book book);
        Task<bool> Delete(long Id);
        Task<List<Book>> GetAll(PaginationDTO request);
        Task<Book> GetOne(long Id);
        Task<Book> Update(Book book);
    }
}