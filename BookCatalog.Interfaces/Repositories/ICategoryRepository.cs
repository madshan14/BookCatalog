using BookCatalog.Entities.Models;

namespace BookCatalog.Interfaces.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
    }
}