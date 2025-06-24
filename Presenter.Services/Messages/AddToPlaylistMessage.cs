using Presenter.Models;

namespace Presenter.Services.Messages
{
    public class AddToPlaylistMessage(Song song)
    {
        public Song Song { get; set; } = song;
    }
}
