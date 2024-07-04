using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using presenter.Messages;
using presenter.Models;

namespace presenter.ViewModel
{

    [ObservableObject]
    [ObservableRecipient]
    public partial class PresentationWindowViewModel : IRecipient<ShowSlideMessage>
    {
        [ObservableProperty]
        private SongImage _image;

        public PresentationWindowViewModel(IMessenger messenger, SongImage initImage) 
        { 
            _image = initImage;
            Messenger = messenger;
            Messenger.Register(this);
        }

        void IRecipient<ShowSlideMessage>.Receive(ShowSlideMessage message)
        {
            Image = message.Image;
        }
    }
}
