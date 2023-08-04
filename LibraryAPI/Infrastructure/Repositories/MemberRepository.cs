using Dapper;
using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystemBackend.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IConfiguration _configuration;

        public MemberRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<bool> Add(MemberModel entity)
        {
            var sql = "INSERT INTO [dbo].[Member] ([MemberName]) VALUES (@MemberName)";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }

        }

        public async Task<IEnumerable<MemberModel>> GetAll()
        {
            var sql = "SELECT * FROM Member";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<MemberModel>(sql);
                return result.ToList();
            }
        }

        public async Task<MemberModel?> GetById(int id)
        {
            var sql = "SELECT * FROM Member WHERE MemberId = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<MemberModel>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM Member WHERE MemberId =  @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return true;
            }
        }

        public async Task<bool> Update(MemberModel entity)
        {
            var sql = "UPDATE [dbo].[Member] SET MemberName = @MemberName WHERE MemberID = @MemberID";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }
    }
}

