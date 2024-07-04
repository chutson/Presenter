using Microsoft.Office.Interop.PowerPoint;
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
        private PlaylistViewModel ViewModel { get; }
        public PlaylistView()
        {
            InitializeComponent();
        }
        public PlaylistView(PlaylistViewModel viewModel)
        {
            DataContext = ViewModel = ViewModel;
            InitializeComponent();
        }

        public void RefreshGrid()
        {
            var thumbnailCount = ViewModel.Playlist.Sum(s => s.Slides.Count);
            for (var i = 0; i < thumbnailCount / 3; i++)
            {
                grdContent.RowDefinitions.Add(new RowDefinition());
            }

            foreach (Song song in ViewModel.Playlist)
            {
                foreach (Slide slide in song.Slides)
                {

                }
            }
        }


    }
}
