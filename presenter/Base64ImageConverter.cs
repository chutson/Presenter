using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace presenter
{
    public class HexImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = value as string;

            if (s == null)
                return null;

            BitmapImage bi = new BitmapImage();

            bi.BeginInit();
            bi.StreamSource = new MemoryStream(System.Convert.FromHexString(s));
            bi.EndInit();

            return bi;
            //var image = new BitmapImage();
            //using (var mem = new MemoryStream(System.Convert.FromHexString(s)))
            //{
            //    mem.Position = 0;
            //    image.BeginInit();
            //    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            //    image.CacheOption = BitmapCacheOption.OnLoad;
            //    image.UriSource = null;
            //    image.StreamSource = mem;
            //    image.EndInit();
            //    //image.Freeze();
            //}
            //return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
