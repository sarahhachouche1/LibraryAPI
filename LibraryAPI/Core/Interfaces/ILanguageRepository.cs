using LibraryManagementSystemBackend.Core.Entities;
namespace LibraryManagementSystemBackend.Core.Interfaces
{
    public interface ILanguageRepository : IGenericRepository<LanguageModel>
    {
        Task<int?> GetLanguageIdByName(string languageName);
    }
}
