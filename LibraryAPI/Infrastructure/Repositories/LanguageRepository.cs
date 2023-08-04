using Dapper;
using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystemBackend.Infrastructure.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly IConfiguration _configuration;

        public LanguageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Add(LanguageModel entity)
        {
            var sql = "INSERT INTO [dbo].[Language] ([LanguageName]) VALUES (@LanguageName)";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }

        }

        public async Task<IEnumerable<LanguageModel>> GetAll()
        {
            var sql = "SELECT * FROM Language";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<LanguageModel>(sql);
                return result.ToList();
            }
        }

        public async Task<LanguageModel?> GetById(int id)
        {
            var sql = "SELECT * FROM Language WHERE LanguageID= @LanguageID";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<LanguageModel>(sql, new {  LanguageID = id });
                return result;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM Language WHERE LanguageID =  @LanguageID";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { LanguageID = id });
                return true;
            }
        }

        public async Task<bool> Update(LanguageModel entity)
        {
            var sql = "UPDATE [dbo].[Language] SET LanguageName = @LanguageName WHERE LanguageID = @LanguageID";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }

        public async Task<int?> GetLanguageIdByName(string languageName)
        {
            var sql = "SELECT LanguageID FROM [dbo].[Language] WHERE LanguageName = @LanguageName";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var languageId = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { LanguageName = languageName });
                return languageId;
            }
        }
    }
}
