using Presenter.WPF.ViewModels;
using Presenter.Models;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace Presenter.WPF.Views
{
    /// <summary>
    /// Interaction logic for Playlist.xaml
    /// </summary>
    public partial class PlaylistView : UserControl
    {
        private PlaylistViewModel _viewModel { get; }

        public PlaylistView()
        {
            DataContext = _viewModel = new PlaylistViewModel(null);
            InitializeComponent();
        }
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

        private void FullVerseContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            if (sender is not ContextMenu contextMenu || contextMenu.PlacementTarget is not FrameworkElement target)
                return;

            if (target.DataContext is not SongImage slide)
                return;

            if (contextMenu.Items.Count < 2 || contextMenu.Items[1] is not MenuItem menuItem)
                return;

            menuItem.DataContext = slide;
            menuItem.Header = IsFullVerseEnabled(slide) ? "Disable Full Verse" : "Enable Full Verse";
        }

        private void mniToggleFullVerse_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not MenuItem menuItem || menuItem.DataContext is not SongImage slide)
                return;

            ToggleFullVerse(slide, !IsFullVerseEnabled(slide));
        }

        private bool IsFullVerseEnabled(SongImage slide)
        {
            var song = _viewModel.Playlist.FirstOrDefault(s => s.Slides.Contains(slide));
            if (song == null)
                return false;

            var verseSlides = song.Slides.Where(s => s.Verse == slide.Verse).ToList();
            return verseSlides.Count > 0 && verseSlides.All(s => s.Enabled);
        }

        private void ToggleFullVerse(SongImage slide, bool enable)
        {
            var song = _viewModel.Playlist.FirstOrDefault(s => s.Slides.Contains(slide));
            if (song == null)
                return;

            foreach (var verseSlide in song.Slides.Where(s => s.Verse == slide.Verse))
                verseSlide.Enabled = enable;
        }

        private void btnCollapse_Click(object sender, RoutedEventArgs e)
        {
            ToggleTreeViewExpansion(trvPlaylist, false);
        }

        private void btnExpand_Click(object sender, RoutedEventArgs e)
        {
            ToggleTreeViewExpansion(trvPlaylist, true);
        }

        private void ToggleTreeViewExpansion(TreeView tv, bool doExpand)
        {
            foreach (var item in tv.Items)
            {
                if (tv.ItemContainerGenerator.ContainerFromItem(item) is TreeViewItem tvi)
                {
                    tvi.IsExpanded = doExpand;
                }
            }
        }
    }
}
