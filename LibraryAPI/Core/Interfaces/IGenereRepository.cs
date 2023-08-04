using LibraryManagementSystemBackend.Core.Entities;

namespace LibraryManagementSystemBackend.Core.Interfaces
{
    public interface IGenereRepository : IGenericRepository<GenereModel>
    {
        Task<int?> GetGenereIdByName(string genereName);
    }
}

