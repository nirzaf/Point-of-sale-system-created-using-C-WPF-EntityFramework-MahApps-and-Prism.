using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PoS.Helper
{
	[ValueConversion(typeof(BitmapImage), typeof(byte[]))]
	public class ByteToImageConverter: IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is byte[]) {
				byte[] data = (byte[])value;
				MemoryStream stream = new MemoryStream(data);
				BitmapImage bitImage = new BitmapImage();

				bitImage.BeginInit ();
				bitImage.StreamSource = stream;
				bitImage.EndInit ();
				return bitImage;
			}
			return null;
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is BitmapImage) {
				BitmapImage imSrc = value as BitmapImage;
				Stream str = imSrc.StreamSource;
				byte[] oBuffer = null;

				if (str != null && str.Length != 0) {
					using (BinaryReader br = new BinaryReader (str)) {
						oBuffer = br.ReadBytes ((int)str.Length);
					}

					return oBuffer;
				}
			}

			return null;
		}
	}
}
