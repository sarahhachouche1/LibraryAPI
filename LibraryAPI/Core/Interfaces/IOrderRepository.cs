
using LibraryManagementSystemBackend.Core.Entities;

namespace LibraryManagementSystemBackend.Core.Interfaces
{
    public interface IOrderRepository : IGenericRepository<OrderModel>
    {
        Task<IEnumerable<OrderModel>> GetOrdersByMemberId(int memberId);
        Task<IEnumerable<OrderModel>> GetOrdersByStatus(string status);

    }
}
