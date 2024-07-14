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
        //public PlaylistView()
        //{
        //    InitializeComponent();
        //}
        public PlaylistView(PlaylistViewModel viewModel)
        {
            DataContext = _viewModel = viewModel;
            InitializeComponent();
        }

        private void trvPlaylist_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            var song = e.NewValue as Song;

            switch (e.NewValue)
            {
                case Song s:
                    _viewModel.SelectedSong = s;
                    _viewModel.CurrentSlide = new SongImage();
                    break;
                case SongImage i:
                    _viewModel.CurrentSlide = i;
                    break;
            }
        }
    }
}
