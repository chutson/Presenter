using presenter.Models;

namespace presenter.Messages
{
    internal class ShowSlideMessage(SongImage image)
    {
        public SongImage Image { get; } = image;
    }
}
