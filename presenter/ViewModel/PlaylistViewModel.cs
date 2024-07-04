﻿using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using presenter.Messages;
using presenter.Models;
using presenter.View;
using WpfScreenHelper;

namespace presenter.ViewModel
{
    [ObservableObject]
    [ObservableRecipient]
    public partial class PlaylistViewModel : IRecipient<AddToPlaylistMessage>, IRecipient<PresentationEventMessage>
    {
        private Screen _presentationScreen;
        private Window _presentationWindow;
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

        void IRecipient<PresentationEventMessage>.Receive(PresentationEventMessage message)
        {
            switch (message.EventType)
            {
                case PresentationEventType.Start:
                    StartPresentation();
                    break;
                case PresentationEventType.Next: 
                    Messenger.Send(new ShowSlideMessage(_selectedSong.Slides.Last()));
                    break;
                case PresentationEventType.Previous:
                    break;
                case PresentationEventType.Stop:
                    _presentationWindow.Close();
                    break;
            }
        }

        private void StartPresentation()
        {
            _presentationWindow = new PresentationWindow(new PresentationWindowViewModel(Messenger, SelectedSong.Slides.First()));
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary)
                    continue;

                _presentationScreen = screen;
            }

            if (!_presentationWindow.IsLoaded)
                _presentationWindow.WindowStartupLocation = WindowStartupLocation.Manual;

            var workingArea = _presentationScreen.WorkingArea;
            _presentationWindow.Left = workingArea.Left;
            _presentationWindow.Top = workingArea.Top;
            _presentationWindow.Width = workingArea.Width;
            _presentationWindow.Height = workingArea.Height;

            _presentationWindow.Show();
        }
    }
}
