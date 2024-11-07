using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BookLibraryMobileApp.Models;

namespace BookLibraryMobileApp.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var books = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Books", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            Author = reader.GetString(1),
                            Title = reader.GetString(2),
                            YearOfPublication = reader.GetInt32(3),
                            PublisherAddress = reader.GetString(4),
                            NumberOfPages = reader.GetInt32(5)
                        });
                    }
                }
            }
            return books;
        }
    }
}
