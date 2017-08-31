using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PoS.Helper
{
	[ValueConversion(typeof(byte[]), typeof(ImageSource))]
	public class ByteToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is byte[]) {
				byte[] data = value as byte[];
				BitmapImage im = new BitmapImage();
				MemoryStream stream = new MemoryStream(data);
				im.BeginInit();
				im.StreamSource = stream;
				im.EndInit();

				return im;
			}

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
