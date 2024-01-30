using BookCatalog.Entities.Models;

namespace BookCatalog.DataAccess.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> Add(Book book);
        Task<bool> Delete(long Id);
        Task<List<Book>> GetAll();
        Task<Book> GetOne(long Id);
        Task<List<Book>> GetWithFilter(string filter);
        Task<Book> Update(Book book);
    }
}