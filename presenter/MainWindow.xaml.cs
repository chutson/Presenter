using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using presenter.View.UserControls;
using presenter.ViewModel;

namespace presenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel { get; }
        public MainWindow(MainWindowViewModel viewModel)
        {
            DataContext = ViewModel = viewModel;
            InitializeComponent();
        }

        
    }
}