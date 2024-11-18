using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using presenter.Messages;
using presenter.Models;
using presenter.Services;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace presenter.ViewModels
{

    [ObservableObject]
    [ObservableRecipient]
    public partial class MediaExplorerViewModel
    {
        private const string SEARCH_LABEL_DEFAULT = "Search...";
        private readonly SongContext _songContext;
        private readonly object _lockObject = new();

        [ObservableProperty]
        private string? _searchLabel = SEARCH_LABEL_DEFAULT;
        [ObservableProperty]
        private string? _searchText;
        [ObservableProperty]
        private Song? _selectedSong;

        public ObservableCollection<Song> Songs { get; set; }
        public CollectionViewSource FilteredSongs { get; set; } = new CollectionViewSource();

        public MediaExplorerViewModel(IMessenger messenger, SongContext songContext) 
        {
            Messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            _songContext = songContext ?? throw new ArgumentNullException(nameof(songContext));

            _songContext.Songs.Load();
            Songs = _songContext.Songs.Local.ToObservableCollection();
            BindingOperations.EnableCollectionSynchronization(Songs, _lockObject); // allows the collection to be updated by another thread
            FilteredSongs.Source = Songs;
            FilteredSongs.View.Filter = SongFilter;
        }

        partial void OnSearchTextChanged(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                SearchLabel = SEARCH_LABEL_DEFAULT;
            else
                SearchLabelClear();

            FilteredSongs.View.Refresh();
        }

        public void AddSelectedItemToPlaylist()
        {
            Messenger.Send(new AddToPlaylistMessage(SelectedSong));
        }

        [RelayCommand]
        public void SearchLabelClear()
        {
            SearchLabel = "";
        }

        private bool SongFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchText))
                return true;

            if (item is not Song song)
                return false;

            if (int.TryParse(SearchText, out _))
                return song.Number != null && song.Number.StartsWith(SearchText);

            return song.Title != null && song.Title.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase);
        }
    }
}
