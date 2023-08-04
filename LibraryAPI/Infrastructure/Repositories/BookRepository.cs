
namespace LibraryManagementSystemBackend.Infrastructure.Repositories
{ 
    using LibraryManagementSystemBackend.Core.Entities;
    using System.Threading.Tasks;
    using Dapper;
    using LibraryManagementSystemBackend.Core.Interfaces;
    using LibraryManagementSystemBackend.Observer;
    using Microsoft.Data.SqlClient;
        public class BookRepository : IBookRepository
        {
            private readonly IConfiguration _configuration;
            private readonly IAuthorRepository _authorRepository;
            private readonly ILanguageRepository _languageRepository;
            private readonly IGenereRepository _genereRepository;

        public BookRepository(IConfiguration configuration, IAuthorRepository authorRepository, ILanguageRepository languageRepository, IGenereRepository genereRepository)
        {
            _configuration = configuration;
            _authorRepository = authorRepository;
            _languageRepository = languageRepository;
            _genereRepository = genereRepository;
        }
        private readonly List<IObserver> observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
        public async Task<BookModel?> GetById(int id)
            {
                var sql = "SELECT * FROM Book WHERE BookId = @BookId";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<BookModel>(sql, new { BookId = id });
                    return result;
                }
            }

            public async Task<IEnumerable<BookModel>> GetAll()
            {
                var sql = "SELECT * FROM Book";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<BookModel>(sql);
                    return result.ToList();
                }
            }
        
            public async Task<bool> Add(BookModel entity)
            {
            var sql = @"INSERT INTO [dbo].[Book] (Title, Description, BookImage, TotalCopies, AvailableCopies, LibrarianID, AuthorID, LanguageID, GenereID)
                        VALUES (@Title, @Description, @BookImage, @TotalCopies, @AvailableCopies, @LibrarianID, @AuthorID, @LanguageID, @GenereID)";

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    await connection.ExecuteAsync(sql, entity);
                    NotifyObservers($"Book '{entity.Title}' was added.");
                    return true;
                }
            }

            public async Task<bool> Update(BookModel entity)
            {
           
             var sql = "UPDATE Book SET Title = @Title, Description = @Description, BookImage = @BookImage, TotalCopies = @TotalCopies,AvailableCopies = @AvailableCopies,LibrarianID = @LibrarianID, LanguageID = @LanguageID, GenereID = @GenereID  WHERE BookId = @BookId";

             using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    await connection.ExecuteAsync(sql, entity);
                    return true;
                }
            }

        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM Book WHERE BookId = @BookId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { BookId = id });
                return true;
            }
        }

        public async Task<IEnumerable<BookModel>> GetBooksByAuthorName(string authorName)
        {
            var sql = @"SELECT b.* 
                        FROM Book b
                        INNER JOIN Author a ON b.AuthorID = a.AuthorID
                        WHERE a.AuthorName = @AuthorName";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<BookModel>(sql, new { AuthorName = authorName });
                return result;
            }
        }

        public async Task<IEnumerable<BookModel>> GetBooksByLanguage(string language)
            {
                var sql = @"SELECT b.* 
                        FROM Book b
                        INNER JOIN Language l ON b.LanguageID = l.LanguageID
                        WHERE l.LanguageName = @LanguageName";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<BookModel>(sql, new { LanguageName = language });
                    return result.ToList();
                }
            }

            public async Task<IEnumerable<BookModel>> GetBooksByGenere(string genere)
            {
                var sql = @"SELECT b.* 
                        FROM Book b
                        INNER JOIN Author a ON b.GenereID = a.GenereID
                        WHERE a.GenereName = @GenereName";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<BookModel>(sql, new { GenereName = genere });
                    return result.ToList();
                }
            }
        }
    }
