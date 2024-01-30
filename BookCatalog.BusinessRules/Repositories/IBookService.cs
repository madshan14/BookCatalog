using BookCatalog.Entities.DTOs;

namespace BookCatalog.BusinessRules.Repositories
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAll(string filter);
    }
}