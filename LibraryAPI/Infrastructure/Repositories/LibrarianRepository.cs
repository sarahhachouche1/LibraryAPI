using Dapper;
using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystemBackend.Infrastructure.Repositories
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly IConfiguration _configuration;

        public LibrarianRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
      
        
        public async Task<bool> Add(LibrarianModel entity)
        {
            var sql = "INSERT INTO [dbo].[Librarian] ([LibrarianName]) VALUES (@LibrarianName)";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }

        }

        public async Task<IEnumerable<LibrarianModel>> GetAll()
        {
            var sql = "SELECT * FROM Librarian";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<LibrarianModel>(sql);
                return result.ToList();
            }
        }

        public async Task<LibrarianModel?> GetById(int id)
        {
            var sql = "SELECT * FROM Librarian WHERE LibrarianId = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<LibrarianModel>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM Librarian WHERE LibrarianId =  @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return true;
            }
        }

        public async Task<bool> Update(LibrarianModel entity)
        {
            var sql = "UPDATE [dbo].[Librarian] SET LibrarianName = @LibrarianName WHERE LibrarianID = @LibrarianID";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }
    }
}
