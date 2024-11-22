using presenter.ViewModels;
using presenter.Models;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace presenter.Views
{
    /// <summary>
    /// Interaction logic for Playlist.xaml
    /// </summary>
    public partial class PlaylistView : UserControl
    {
        private PlaylistViewModel _viewModel { get; }
        public PlaylistView(PlaylistViewModel viewModel)
        {
            DataContext = _viewModel = viewModel;
            InitializeComponent();
        }

        private void trvPlaylist_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            switch (e.NewValue)
            {
                case Song s:
                    _viewModel.SelectedSong = s;
                    _viewModel.CurrentSlide = new SongImage(); // show a blank slide when the song title is selected
                    break;
                case SongImage i:
                    _viewModel.CurrentSlide = i;
                    break;
            }
        }

        /// <summary>
        /// Puts focus on the TreeViewItem that was right clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvPlaylist_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }
        private static TreeViewItem? VisualUpwardSearch(DependencyObject? source)
        {
            while (source != null && source is not TreeViewItem)
            {
                source = VisualTreeHelper.GetParent(source);
            }

            return source as TreeViewItem;
        }

        private void mniRemove_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveFromPlaylistCommand.Execute(e);
        }
    }
}
