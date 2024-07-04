using presenter.Models;

namespace presenter.Messages
{
    public class AddToPlaylistMessage(Song song)
    {
        public Song Song { get; set; } = song;
    }
}
