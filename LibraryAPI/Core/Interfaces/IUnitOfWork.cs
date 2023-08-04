namespace LibraryManagementSystemBackend.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        IGenereRepository Generes { get; }
        ILanguageRepository Languages { get; }
        ILibrarianRepository Librarians { get; }
        IMemberRepository Members { get; }
        IOrderDetailRepository OrderDetails { get; }
        IOrderRepository Orders { get; }
        IRoleRepository Roles { get; }
    }
}
