using Dapper;
using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystemBackend.Infrastructure.Repositories
{
    public class GenereRepository : IGenereRepository
    {
        private readonly IConfiguration _configuration;

        public GenereRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Add(GenereModel entity)
        {
            var sql = "INSERT INTO [dbo].[Genere] ([GenereName]) VALUES (@GenereName)";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }

        }

        public async Task<IEnumerable<GenereModel>> GetAll()
        {
            var sql = "SELECT * FROM Genere";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<GenereModel>(sql);
                return result.ToList();
            }
        }

        public async Task<GenereModel?> GetById(int id)
        {
            var sql = "SELECT * FROM Genere WHERE GenereId = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<GenereModel>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM Genere WHERE GenereId =  @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, new { Id = id });
                return true;
            }
        }

        public async Task<bool> Update(GenereModel entity)
        {
            var sql = "UPDATE [dbo].[Genere] SET GenereName = @GenereName WHERE GenereID = @GenereID";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }

        public async Task<int?> GetGenereIdByName(string genereName)
        {
            var sql = "SELECT GenereID FROM [dbo].[Genere] WHERE GenereName = @GenereName";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var genereId = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { GenereName = genereName });
                return genereId;
            }
        }
    }
}
