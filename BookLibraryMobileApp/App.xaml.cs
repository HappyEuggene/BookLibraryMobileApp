using Microsoft.Maui.Controls;

namespace BookLibraryMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
