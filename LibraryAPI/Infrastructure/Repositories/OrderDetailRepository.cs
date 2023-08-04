
using Dapper;
using LibraryManagementSystemBackend.Core.Entities;
using LibraryManagementSystemBackend.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystemBackend.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IConfiguration _configuration;

        public OrderDetailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Add(OrderDetailModel entity)
        {
            var sql = "INSERT INTO [dbo].[OrderDetail] ([Quantity], [Price], [BookID], [OrderID]) VALUES (@Quantity, @Price, @BookID, @OrderID)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.QuerySingleOrDefaultAsync<int>(sql, entity);
                return true;
            }
        }

        public async Task<bool> Update(OrderDetailModel entity)
        {
            var sql = "UPDATE [dbo].[OrderDetail] SET [Quantity] = @Quantity,[Price] = @Price,[BookID] = @BookID,[OrderID] = @OrderID WHERE [OrderDetailID] = @OrderDetailID";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM [dbo].[OrderDetail] WHERE [OrderDetailID] = @OrderDetailId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, new { OrderDetailId = id });
                return true;
            }
        }

        public async Task<OrderDetailModel?> GetById(int id)
        {
            var sql = "SELECT * FROM [dbo].[OrderDetail] WHERE [OrderDetailID] = @OrderDetailId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<OrderDetailModel>(sql, new { OrderDetailId = id });
                return result;
            }
        }

        public async Task<IEnumerable<OrderDetailModel>> GetAll()
        {
            var sql = "SELECT * FROM [dbo].[OrderDetail]";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<OrderDetailModel>(sql);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<OrderDetailModel>> GetOrderDetailsByOrderId(int orderId)
        {
            var sql = "SELECT * FROM [dbo].[OrderDetail] WHERE [OrderID] = @OrderId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<OrderDetailModel>(sql, new { OrderId = orderId });
                return result.ToList();
            }
        }
    }
}

