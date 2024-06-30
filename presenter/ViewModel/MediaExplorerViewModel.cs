using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Data;
using presenter.Model;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace presenter.ViewModel
{

    [ObservableObject]
    [ObservableRecipient]
    public partial class MediaExplorerViewModel : IRecipient<ImportMessage>
    {
        private readonly SongContext _SongContext;
        public ObservableCollection<Song> Songs { get; set; }
        public CollectionViewSource FilteredSongs { get; set; } = new CollectionViewSource();

        public MediaExplorerViewModel(IMessenger messenger, SongContext songContext) 
        {
            Messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            _SongContext = songContext ?? throw new ArgumentNullException(nameof(songContext));
            Messenger.Register(this);
            
            RefreshSongs();
            FilteredSongs.Source = Songs;
            FilteredSongs.View.Filter = SongFilter;
        }

        [ObservableProperty]
        private string? _searchText;
        partial void OnSearchTextChanged(string? value)
        {
            FilteredSongs.View.Refresh();
        }

        [ObservableProperty]
        private Song? _selectedSong;

        public void AddSelectedItemToPlaylist()
        {
            Messenger.Send(new AddToPlaylistMessage(_selectedSong));
        }

        private bool SongFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchText))
                return true;

            if (int.TryParse(SearchText, out _))
                return (item as Song).Number.StartsWith(SearchText);

            return (item as Song).Title.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase);
        }

        private void RefreshSongs()
        {
            Songs = new ObservableCollection<Song>(_SongContext.Songs);
        }

        void IRecipient<ImportMessage>.Receive(ImportMessage message)
        {
            RefreshSongs();
        }
    }
}
