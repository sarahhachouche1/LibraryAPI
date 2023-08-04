using Dapper;
using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystemBackend.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;

        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Add(OrderModel entity)
        {
            var sql = "INSERT INTO [dbo].[Order] ([OrderDate], [TotalPrice], [Status], [MemberID]) VALUES (@OrderDate, @TotalPrice, @Status, @MemberID)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.QuerySingleOrDefaultAsync<int>(sql, entity);
                return true;
            }
        }

        public async Task<bool> Update(OrderModel entity)
        {
            var sql = "UPDATE [dbo].[Order] SET [OrderDate] = @OrderDate,[TotalPrice] = @TotalPrice,[Status] = @Status,[MemberID] = @MemberID WHERE [OrderID] = @OrderID";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM [dbo].[Order] WHERE [OrderID] = @OrderId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, new { OrderId = id });
                return true;
            }
        }

        public async Task<OrderModel?> GetById(int id)
        {
            var sql = "SELECT * FROM [dbo].[Order] WHERE [OrderID] = @OrderId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<OrderModel>(sql, new { OrderId = id });
                return result;
            }
        }

        public async Task<IEnumerable<OrderModel>> GetAll()
        {
            var sql = "SELECT * FROM [dbo].[Order]";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<OrderModel>(sql);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersByMemberId(int memberId)
        {
            var sql = "SELECT * FROM [dbo].[Order] WHERE [MemberID] = @MemberId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<OrderModel>(sql, new { MemberId = memberId });
                return result.ToList();
            }
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersByStatus(string status)
        {
            var sql = "SELECT * FROM [dbo].[Order] WHERE [Status] = @Status";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<OrderModel>(sql, new { Status = status });
                return result.ToList();
            }
        }
    }
}

