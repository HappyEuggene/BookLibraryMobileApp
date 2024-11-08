using Microsoft.Maui.Controls;

namespace BookLibraryMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnViewLibraryClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("LibraryPage");
        }

        private async void OnAuthorDetailsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AuthorDetailsPage");
        }
    }
}
