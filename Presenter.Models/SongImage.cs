using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presenter.Models
{
    public class SongImage : INotifyPropertyChanged
    {
        private bool _enabled;

        public int Id { get; set; }
        public int SongId { get; set; }
        [Column("song_number")]
        public string? SongNumber { get; set; }
        [Column("verse")]
        public string Verse { get; set; }
        public string ImageNumber { get; set; }
        public string Image { get; set; }
        [Column("Enabled")]
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled == value)
                    return;

                _enabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Enabled)));
            }
        }

        public virtual Song Song { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return $"{Verse}-{ImageNumber}";
        }
    }
}
