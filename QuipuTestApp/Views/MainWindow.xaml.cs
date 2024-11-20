using QuipuTestApp.ViewModels;
using System.Windows;

namespace QuipuTestApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
