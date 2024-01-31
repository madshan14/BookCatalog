using BookCatalog.Entities.DTOs;

namespace BookCatalog.Interfaces.Services
{
    public interface IBookService
    {
        Task<BookDTO> AddBook(BookDTO book);
        Task<bool> DeleteBook(long Id);
        Task<PaginationDTO<List<BookDTO>>> GetAll(PaginationDTO request);
        Task<BookDTO> GetOneBook(long Id);
        Task<BookDTO> UpdateBook(BookDTO book);
    }
}