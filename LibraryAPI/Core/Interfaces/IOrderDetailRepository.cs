using LibraryManagementSystemBackend.Core.Entities;

namespace LibraryManagementSystemBackend.Core.Interfaces
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetailModel>
    {
        Task<IEnumerable<OrderDetailModel>> GetOrderDetailsByOrderId(int orderId);
    }
}
