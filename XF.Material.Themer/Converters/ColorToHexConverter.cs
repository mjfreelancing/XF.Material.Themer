using System;
using System.Globalization;
using Xamarin.Forms;

namespace XF.Material.Themer.Converters
{
  public class ColorToHexConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var color = (Color) value;

      // not using color.ToHex() as I don't want the alpha channel included
      return $"#{(uint)(color.R * byte.MaxValue):X2}{(uint)(color.G * byte.MaxValue):X2}{(uint)(color.B * byte.MaxValue):X2}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}