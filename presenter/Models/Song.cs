using System.ComponentModel.DataAnnotations.Schema;

namespace presenter.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Column("song_number")]
        public string? Number { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("atitle")]
        public string? AltTitle { get; set; }
        [Column("leadernotes")]
        public string? LeaderNotes {  get; set; }
        [Column("intronotes")]
        public string? IntroNotes { get; set; }
        [Column("lyricauthor")]
        public string? LyricAuthor { get; set; }
        [Column("lyricdate")]
        public string? LyricDate { get; set; }
        [Column("engtranslator")]
        public string? EngTranslator { get; set; }
        [Column("engtranslatedate")]
        public string? EngTranslateDate { get; set; }

        [Column("composer")]
        public string? Composer { get; set; }

        public virtual ICollection<SongImage> Slides { get; set; } = new List<SongImage>();

        public override string ToString()
        {
            var prefix = "";
            if (Number != null)
                prefix = $"{Number} - ";

            return $"{prefix}{Title}";
        }
    }
}
