using presenter.ViewModel;
using presenter.Models;
using System.Windows.Controls;

namespace presenter.View.UserControls
{
    /// <summary>
    /// Interaction logic for Playlist.xaml
    /// </summary>
    public partial class PlaylistView : UserControl
    {
        private PlaylistViewModel _viewModel { get; }
        public PlaylistView()
        {
            InitializeComponent();
        }
        public PlaylistView(PlaylistViewModel viewModel)
        {
            DataContext = _viewModel = _viewModel;
            InitializeComponent();
        }

        private void trvPlaylist_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            var song = e.NewValue as Song;

            switch (e.NewValue)
            {
                case Song s:
                    ((PlaylistViewModel)DataContext).SelectedSong = s;
                    break;
                case SongImage i:
                    ((PlaylistViewModel)DataContext).CurrentSlide = i;
                    break;
            }
        }
    }
}
