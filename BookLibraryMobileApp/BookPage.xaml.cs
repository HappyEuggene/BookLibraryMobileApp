using Microsoft.Maui.Controls;
using BookLibraryMobileApp.Models;
using BookLibraryMobileApp.Services;
using System;

namespace BookLibraryMobileApp
{
    [QueryProperty(nameof(BookId), "bookId")]
    public partial class BookPage : ContentPage
    {
        private int BookId
        {
            set
            {
                LoadBook(value);
            }
        }

        private readonly BookService _bookService;

        public BookPage()
        {
            InitializeComponent();
            _bookService = new BookService();
        }

        private async void LoadBook(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book != null)
                {
                    TitleLabel.Text = book.Title;
                    AuthorLabel.Text = $"Author: {book.Author}";
                    YearLabel.Text = $"Year of Publication: {book.YearOfPublication}";
                    PublisherLabel.Text = $"Publisher: {book.PublisherAddress}";
                    PagesLabel.Text = $"Pages: {book.NumberOfPages}";
                }
                else
                {
                    await DisplayAlert("Error", "Book not found.", "OK");
                    await Shell.Current.GoToAsync(".."); // Повернення назад
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
