using LibraryManagementSystemBackend.Core.Entities;

namespace LibraryManagementSystemBackend.Core.Interfaces
{
    public interface IRoleRepository : IGenericRepository<RoleModel>
    {
        Task<int?> GetRoleIdByRoleName(string roleName);
    }
}
