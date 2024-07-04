using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace presenter
{
    public class HexImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var s = value as string;

            if (s == null)
                return null;

            var image = new BitmapImage();

            image.BeginInit();
            image.StreamSource = new MemoryStream(System.Convert.FromHexString(s));
            image.EndInit();

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
