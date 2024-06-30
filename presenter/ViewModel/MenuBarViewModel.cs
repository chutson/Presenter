using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace presenter.ViewModel
{
    [ObservableObject]
    internal partial class MenuBarViewModel
    {
        [RelayCommand]
        private static void Import()
        {
            var song = PptToBinaryConverter.ConvertToSong(@"C:\Users\Caleb\Desktop\song_manager\pptx\A Beautiful Prayer-sfpe.pptx");
        }
    }
}
