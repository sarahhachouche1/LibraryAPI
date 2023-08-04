using Dapper;
using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystemBackend.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IConfiguration _configuration;

        public RoleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Add(RoleModel entity)
        {
            var sql = "INSERT INTO [dbo].[Role] ([RoleName]) VALUES (@RoleName)";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }

        }

        public async Task<IEnumerable<RoleModel>> GetAll()
        {
            var sql = "SELECT * FROM Role";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<RoleModel>(sql);
                return result.ToList();
            }
        }

        public async Task<RoleModel?> GetById(int id)
        {
            var sql = "SELECT * FROM Role WHERE RoleId = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<RoleModel>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM Role WHERE RoleId =  @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, new { Id = id });
                return true;
            }
        }

        public async Task<bool> Update(RoleModel entity)
        {
            var sql = "UPDATE [dbo].[Role] SET RoleName = @RoleName WHERE RoleID = @RoleID";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }
        public async Task<int?> GetRoleIdByRoleName(string roleName)
        {
            var sql = "SELECT RoleID FROM [dbo].[Role] WHERE RoleName = @RoleName";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var roleId = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { RoleName = roleName });
                return roleId;
            }
        }

    }
}

    
