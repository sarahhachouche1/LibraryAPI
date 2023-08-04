using LibraryManagementSystemBackend.Core.Entities;

namespace LibraryManagementSystemBackend.Core.Interfaces
{
    public interface IBookRepository : IGenericRepository<BookModel>
    {
        Task<IEnumerable<BookModel>> GetBooksByAuthorName(string authorName);
        Task<IEnumerable<BookModel>> GetBooksByLanguage(string language);
        Task<IEnumerable<BookModel>> GetBooksByGenere(string genre);
    }
}

