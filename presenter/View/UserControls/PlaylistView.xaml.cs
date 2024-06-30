using Data;
using Microsoft.Office.Interop.PowerPoint;
using presenter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
