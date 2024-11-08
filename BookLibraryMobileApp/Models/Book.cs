using System;

namespace BookLibraryMobileApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty; // Ініціалізація порожнім рядком
        public string Title { get; set; } = string.Empty; // Ініціалізація порожнім рядком
        public int YearOfPublication { get; set; }
        public string PublisherAddress { get; set; } = string.Empty; // Ініціалізація порожнім рядком
        public int NumberOfPages { get; set; }
    }
}
