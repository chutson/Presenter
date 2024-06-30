﻿using System.IO;
using Microsoft.Office.Interop.PowerPoint;

namespace presenter
{
    class PptToBinaryConverter
    {
        public static Data.Song ConvertToSong(string file)
        {
            if (!File.Exists(file) || Path.GetExtension(file) != ".pptx")
                throw new FileNotFoundException(file);

            var filename = Path.GetFileNameWithoutExtension(file);
            var song = new Data.Song
            {
                Title = filename
            };

            // Create a temp directory to hold image files
            var tempDir = Directory.CreateTempSubdirectory();

            try
            {
                // export slides as images
                var ppApp = new Application();
                var presentation = ppApp.Presentations.Open(file, 0, 0, 0);
                for (var i = 1; i <= presentation.Slides.Count; i++)
                {
                    presentation.Slides[i].Export(Path.Join(tempDir.FullName, i.ToString()), "PNG", 1024, 768);
                }

                presentation.Close();
                ppApp.Quit();

                // convert slide images to hex string and add to song
                var index = 1;
                foreach (FileInfo imageFile in tempDir.GetFiles().OrderBy(f => Convert.ToInt32(f.Name)))
                {
                    var songImage = new Data.SongImage() { Verse = "1", ImageNumber = imageFile.Name };
                    var imageBytes = File.ReadAllBytes(imageFile.FullName);
                    songImage.Image = Convert.ToHexString(imageBytes);

                    song.Slides.Add(songImage);
                    index++;
                }
            }
            finally
            {
                tempDir.Delete(true);
            }
            return song;
        }

        public static void UpgradeToPptx(string dir)
        {
            var saveDir = Path.Join(dir, "new");
            var ppApp = new Application();
            foreach (var file in Directory.GetFiles(dir).Where(f => f.EndsWith(".ppt")))
            {
                var newFileName = $"{Path.GetFileNameWithoutExtension(file)}.pptx";
                var presentation = ppApp.Presentations.Open(file, 0, 0, 0);
                presentation.SaveAs(Path.Join(saveDir, newFileName), PpSaveAsFileType.ppSaveAsOpenXMLPresentation);
                presentation.Close();
            }
            ppApp.Quit();
        }
    }
}