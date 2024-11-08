using Microsoft.Maui.Controls;
using BookLibraryMobileApp.Models;
using BookLibraryMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryMobileApp
{
    public partial class LibraryPage : ContentPage
    {
        private readonly BookService _bookService;
        private List<Book> _allBooks;

        public LibraryPage()
        {
            InitializeComponent();
            _bookService = new BookService();
            LoadBooks();
        }

        private async void LoadBooks()
        {
            try
            {
                _allBooks = await _bookService.GetBooksAsync();
                if (_allBooks != null && _allBooks.Count > 0)
                {
                    BooksCollectionView.ItemsSource = _allBooks;
                    UpdatePercentageLabel(_allBooks.Count, _allBooks.Count);
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

        private void OnShowAllBooksClicked(object sender, EventArgs e)
        {
            if (_allBooks != null && _allBooks.Count > 0)
            {
                BooksCollectionView.ItemsSource = _allBooks;
                UpdatePercentageLabel(_allBooks.Count, _allBooks.Count);
            }
        }

        private void OnShowOlderBooksClicked(object sender, EventArgs e)
        {
            if (_allBooks != null && _allBooks.Count > 0)
            {
                var olderBooks = _allBooks.Where(b => DateTime.Now.Year - b.YearOfPublication > 10).ToList();
                BooksCollectionView.ItemsSource = olderBooks;
                UpdatePercentageLabel(olderBooks.Count, _allBooks.Count);
            }
        }

        private void UpdatePercentageLabel(int filteredCount, int totalCount)
        {
            if (totalCount > 0)
            {
                double percentage = ((double)filteredCount / totalCount) * 100;
                PercentageLabel.Text = $"Selected books: {percentage:F2}%";
            }
            else
            {
                PercentageLabel.Text = "Selected books: 0%";
            }
        }

        private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
            {
                // Скидання вибору
                BooksCollectionView.SelectedItem = null;
                // Навігація до сторінки детальної інформації про книгу
                await Shell.Current.GoToAsync($"BookPage?bookId={selectedBook.Id}");
            }
        }
    }
}
