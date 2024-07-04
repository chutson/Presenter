using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System.IO;
using System.Windows.Media.Imaging;
using presenter.Messages;
using presenter.Models;

namespace presenter.ViewModel
{
    [ObservableObject]
    [ObservableRecipient]
    public partial class PlaylistViewModel : IRecipient<AddToPlaylistMessage>, IRecipient<PresentMessage>
    {
        public ObservableCollection<Song> Playlist { get; set; }
        public PlaylistViewModel(IMessenger messenger)
        {
            Playlist = new ObservableCollection<Song>();
            Messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            Messenger.RegisterAll(this);
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

        void IRecipient<PresentMessage>.Receive(PresentMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
