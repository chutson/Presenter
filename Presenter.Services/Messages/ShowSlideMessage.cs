using Presenter.Models;

namespace Presenter.Services.Messages
{
    public class ShowSlideMessage(SongImage image)
    {
        public SongImage Image { get; } = image;
    }
}
