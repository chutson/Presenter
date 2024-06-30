using Data;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using presenter.Model;
using Microsoft.Office.Interop.PowerPoint;
using System.IO;
using System.Windows.Media.Imaging;

namespace presenter.ViewModel
{
    [ObservableObject]
    [ObservableRecipient]
    public partial class PlaylistViewModel : IRecipient<AddToPlaylistMessage>
    {
        public ObservableCollection<Song> Playlist { get; set; }
        public PlaylistViewModel(IMessenger messenger)
        {
            Playlist = new ObservableCollection<Song>();
            Messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            Messenger.Register(this);
        }

        private Song _selectedSong;
        public Song SelectedSong
        {
            get { return _selectedSong; }
            set
            {
                _selectedSong = value;
                OnPropertyChanged();
            }
        }

        public void Receive(AddToPlaylistMessage message)
        {
            Playlist.Add(message.Song);
        }
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
                //image.Freeze();
            }
            return image;
        }
    }
}
