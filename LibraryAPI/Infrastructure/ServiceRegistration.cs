using LibraryManagementSystemBackend.Core.Interfaces;
using LibraryManagementSystemBackend.Infrastructure.Repositories;

namespace LibraryManagementSystemBackend.Infrastructure
{

    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IGenereRepository, GenereRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<ILibrarianRepository, LibrarianRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
