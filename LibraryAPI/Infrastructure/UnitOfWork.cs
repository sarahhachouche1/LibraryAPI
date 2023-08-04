using LibraryManagementSystemBackend.Core.Interfaces;
using LibraryManagementSystemBackend.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace LibraryManagementSystemBackend.Infrastructure
{
        public class UnitOfWork : IUnitOfWork
        {
            public UnitOfWork(IAuthorRepository authorRepository, IBookRepository bookRepository, IGenereRepository genereRepository, ILanguageRepository languageRepository,
               ILibrarianRepository librarianRepository, IMemberRepository memberRepository, IOrderDetailRepository orderDetailRepository,
               IRoleRepository roleRepository, IOrderRepository orderRepository)
            {
                Authors = authorRepository;
                Books = bookRepository;
                Generes = genereRepository;
                Librarians = librarianRepository;
                Members  = memberRepository;
                OrderDetails = orderDetailRepository;
                Languages = languageRepository; 
                Roles = roleRepository;
                Orders = orderRepository;

            }

        public IAuthorRepository Authors { get; }
        public IBookRepository Books { get; }
        public IGenereRepository Generes { get; }
        public ILibrarianRepository Librarians { get; }
        public IMemberRepository Members { get; }
        public IOrderDetailRepository OrderDetails { get; }
        public ILanguageRepository Languages { get; }
        public IRoleRepository Roles { get; }
        public IOrderRepository Orders { get; }
    }
}
