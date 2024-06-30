using Data;

using (var context = new SongContext(@"Data Source=C:\Users\Caleb\Desktop\song_manager\Songs.db"))
{
    var song = context.Songs.First();
    Console.WriteLine(song.Title);
    foreach(var slide in song.Slides)
    {
        Console.WriteLine($"Verse: {slide.Verse}; Image Number: {slide.ImageNumber}");
    }
}
