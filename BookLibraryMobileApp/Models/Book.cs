namespace BookLibraryMobileApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Author { get; set; } = string.Empty; // Поле не може бути null
        public required string Title { get; set; } = string.Empty;  // Поле не може бути null
        public int YearOfPublication { get; set; }
        public required string PublisherAddress { get; set; } = string.Empty; // Поле не може бути null
        public int NumberOfPages { get; set; }
    }
}
