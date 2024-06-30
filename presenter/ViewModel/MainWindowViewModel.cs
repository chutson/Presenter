﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Data;
using Microsoft.Office.Core;
using Microsoft.Win32;
using presenter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace presenter.ViewModel
{
    [ObservableObject]
    public partial class MainWindowViewModel
    {
        private readonly IMessenger _messenger;
        public MediaExplorerViewModel MediaExplorerViewModel { get; }
        public PlaylistViewModel PlaylistViewModel { get; }
        public SongContext SongContext { get; }
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

            await ConvertAndSave(fileDialog.FileNames);
            _messenger.Send<ImportMessage>();
            MessageBox.Show("Import Complete");
        }

        private async Task ConvertAndSave(string[] files)
        {
            await Task.Run(() => { foreach (string file in files)
                {
                    var song = PptToBinaryConverter.ConvertToSong(file);
                    SongContext.Add(song);
                    SongContext.SaveChanges();
                }
            });
        }
    }
}