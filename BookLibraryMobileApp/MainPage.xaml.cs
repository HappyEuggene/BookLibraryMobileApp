using BookLibraryMobileApp.Services;

namespace BookLibraryMobileApp
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService("your_connection_string_here");
            LoadBooks();
        }

        private async void LoadBooks()
        {
            try
            {
                var books = await _databaseService.GetBooksAsync();
                if (books != null && books.Count > 0)
                {
                    BooksListView.ItemsSource = books;
                }
                else
                {
                    await DisplayAlert("Information", "No books found.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
