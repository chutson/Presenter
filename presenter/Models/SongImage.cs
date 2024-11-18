using System.ComponentModel.DataAnnotations.Schema;

namespace presenter.Models
{
    public class SongImage
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        [Column("song_number")]
        public string? SongNumber { get; set; }
        [Column("verse")]
        public string Verse { get; set; }
        public string ImageNumber { get; set; }
        public string Image {  get; set; }
        [Column("Enabled")]
        public bool Enabled { get; set; }

        public virtual Song Song { get; set; }

        public override string ToString()
        {
            return $"{Verse}-{ImageNumber}"; 
        }
    }
}
