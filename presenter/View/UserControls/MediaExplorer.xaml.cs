using System.Windows.Controls;
using CommunityToolkit.Mvvm.Messaging;
using presenter.ViewModel;

namespace presenter.View.UserControls
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
        }
    }
}
