using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Win32;
using Presenter.Services;
using Presenter.Services.Messages;
using Presenter.WPF.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using WpfScreenHelper;

namespace Presenter.WPF.ViewModels
{
    [ObservableObject]
    public partial class MainWindowViewModel
    {
        private readonly IMessenger _messenger;
        public MediaExplorerViewModel MediaExplorerViewModel { get; }
        public PlaylistViewModel PlaylistViewModel { get; }
        public SongContext SongContext { get; }

        [ObservableProperty]
        private int _importPercentProgress;

        [ObservableProperty]
        private ObservableCollection<Screen> _screens = new(Screen.AllScreens);

        public MainWindowViewModel(IMessenger messenger, MediaExplorerViewModel mediaExplorerViewModel, PlaylistViewModel playlistViewModel, SongContext songContext)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
            SongContext = songContext ?? throw new ArgumentNullException(nameof(songContext));
            MediaExplorerViewModel = mediaExplorerViewModel ?? throw new ArgumentNullException(nameof(mediaExplorerViewModel));
            PlaylistViewModel = playlistViewModel ?? throw new ArgumentNullException(nameof(playlistViewModel));
        }

        [RelayCommand]
        private async Task Import()
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "Presentations (*.pptx)|*.pptx",
                Multiselect = true,
                Title = "Import"
            };
            var result = fileDialog.ShowDialog();

            if (!result.HasValue || !result.Value)
                return;

            var progress = new Progress<int>(percent => ImportPercentProgress = percent);
            await ConvertAndSave(fileDialog.FileNames, progress);
            MessageBox.Show("Import Complete");
        }

        [RelayCommand]
        private void StartPresentation()
        {
            _messenger.Send(new PresentationEventMessage(PresentationEventType.Start));

        }

        [RelayCommand]
        private void Next()
        {
            _messenger.Send(new PresentationEventMessage(PresentationEventType.Next));
        }

        [RelayCommand]
        private void End()
        {
            _messenger.Send(new PresentationEventMessage(PresentationEventType.Stop));
        }

        private async Task ConvertAndSave(string[] files, IProgress<int> progress)
        {
            await Task.Run(() => { for(var i = 0; i < files.Length; i++)
                {
                    var song = PptToBinaryConverter.ConvertToSong(files[i]);
                    SongContext.Add(song);
                    SongContext.SaveChanges();
                    progress.Report(i / files.Length * 100);
                }
            });
        }

        [RelayCommand]
        private void Exit()
        {
            //await SongContext.SaveChangesAsync();
            Application.Current.Shutdown();
        }
    }
}
