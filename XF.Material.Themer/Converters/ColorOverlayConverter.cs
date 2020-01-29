using System;
using System.Globalization;
using Xamarin.Forms;
using XF.Material.Themer.Helpers;

namespace XF.Material.Themer.Converters
{
  public class ColorOverlayConverter
    : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      // todo: input validation checking
      var color = (Color)value;
      var opacity = (double)parameter;

      return ColorHelper.FromHexWithOpacity(color.ToHex(), opacity);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}