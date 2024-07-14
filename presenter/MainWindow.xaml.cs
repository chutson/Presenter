using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using presenter.View.UserControls;
using presenter.ViewModel;

namespace presenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel { get; }
        public MainWindow(MainWindowViewModel viewModel, PlaylistView playlistView)
        {
            DataContext = _viewModel = viewModel;
            InitializeComponent();

            grdMain.Children.Add(playlistView);
            Grid.SetRow(playlistView, 1);
            Grid.SetColumn(playlistView, 1);
        }

        void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.F5:
                    _viewModel.StartPresentationCommand.Execute(this);
                    break;
                case Key.Escape:
                    _viewModel.EndCommand.Execute(this);
                    break;
            }

            this.Focus();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ExitCommand.Execute(this);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}