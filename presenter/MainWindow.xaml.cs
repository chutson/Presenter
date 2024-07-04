using System.Windows;
using System.Windows.Input;
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
            this.KeyDown += new System.Windows.Input.KeyEventHandler(MainWindow_KeyDown);
        }

        void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.P)
            {
                //ViewModel.StartPresentation();
            }
        }
    }
}