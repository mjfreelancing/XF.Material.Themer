using System;
using System.Globalization;
using Xamarin.Forms;

namespace XF.Material.Themer.Converters
{
  public class ColorToHexConverter
    : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return ToDisplayHex((Color)value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    private static string ToDisplayHex(Color color)
    {
      return $"#{(uint)(color.R * byte.MaxValue):X2}{(uint)(color.G * byte.MaxValue):X2}{(uint)(color.B * byte.MaxValue):X2}";
    }
  }
}