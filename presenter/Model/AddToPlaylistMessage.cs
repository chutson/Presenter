using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presenter.Model
{
    public class AddToPlaylistMessage(Song song)
    {
        public Song Song { get; set; } = song;
    }
}
