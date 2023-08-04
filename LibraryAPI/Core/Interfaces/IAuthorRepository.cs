using LibraryManagementSystemBackend.Core.Entities;

namespace LibraryManagementSystemBackend.Core.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<AuthorModel>
    {
        Task<int?> GetAuthorIdByName(string authorName);
    }
}
