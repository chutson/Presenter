using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Presenter.WPF.Utilities
{
    public class HexImageConverter : IValueConverter
    {
        /// <summary>
        /// Implementation for converting a hex string into an image
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is not string s)
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
