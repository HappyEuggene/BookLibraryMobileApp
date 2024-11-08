using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookLibraryMobileApp.Models;
using System.Collections.Generic;

namespace BookLibraryMobileApp.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        public BookService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://10.0.2.2:5181") // URL вашого API для емулятора Android
            };
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var response = await _httpClient.GetStringAsync("/api/books");
            return JsonConvert.DeserializeObject<List<Book>>(response);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"/api/books/{id}");
            return JsonConvert.DeserializeObject<Book>(response);
        }

        public async Task AddBookAsync(Book book)
        {
            var json = JsonConvert.SerializeObject(book);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("/api/books", content);
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            var json = JsonConvert.SerializeObject(book);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"/api/books/{id}", content);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _httpClient.DeleteAsync($"/api/books/{id}");
        }
    }
}
