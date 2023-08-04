using Dapper;
using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystemBackend.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IConfiguration _configuration;

        public AuthorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int?> GetAuthorIdByName(string authorName)
        {
            var sql = "SELECT AuthorID FROM [dbo].[Author] WHERE AuthorName = @AuthorName";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var AuthorId = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { AuthorName = authorName });
                return AuthorId;
            }
        }
        public async Task<bool> Add(AuthorModel entity)
        {
            var sql = "INSERT INTO [dbo].[Author] ([AuthorName]) VALUES (@AuthorName)";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }

        }

        public async Task<IEnumerable<AuthorModel>> GetAll()
        {
            var sql = "SELECT * FROM Author";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<AuthorModel>(sql);
                return result.ToList();
            }
        }

        public async Task<AuthorModel?> GetById(int id)
        {
            var sql = "SELECT * FROM Author WHERE AuthorId = @AuthorId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<AuthorModel>(sql, new { AuthorId = id });
                return result;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM Author WHERE AuthorId =  @AuthorId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { AuthorId = id });
                return true;
            }
        }

        public async Task<bool> Update(AuthorModel entity)
        {
            var sql = "UPDATE [dbo].[Author] SET AuthorName = @AuthorName WHERE AuthorID = @AuthorID";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }
    }
}
