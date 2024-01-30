using BookCatalog.Entities.Models;

namespace BookCatalog.DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
    }
}