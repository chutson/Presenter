using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using presenter.ViewModel;

namespace presenter.View
{
    /// <summary>
    /// Interaction logic for MediaExplorer.xaml
    /// </summary>
    public partial class MediaExplorer : UserControl
    {
        private readonly MediaExplorerViewModel _viewModel;

        public MediaExplorer()
        {
            InitializeComponent();
        }

        public MediaExplorer(MediaExplorerViewModel viewModel)
        {
            DataContext = _viewModel = viewModel;
            InitializeComponent();
        }

        private void lvLibrary_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((MediaExplorerViewModel)DataContext).AddSelectedItemToPlaylist();
            txtSearch.Focus();
        }

        private void txtSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Down)
                return;

            MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        private void lvLibrary_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (lvLibrary.SelectedIndex == 0 && e.Key == Key.Up)
                MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            if (lvLibrary.SelectedIndex >= 0 && e.Key == Key.Enter)
            {
                ((MediaExplorerViewModel)DataContext).AddSelectedItemToPlaylist();
            }
        }
    }
}
