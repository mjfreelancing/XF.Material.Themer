using System;
using System.Globalization;
using Xamarin.Forms;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Models;

namespace XF.Material.Themer.Converters
{
  public class SurfaceElevationConverter
    : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var color = GetColor(value);    // assumed to be the theme's surface color
      var elevation = GetElevationLevel(parameter);

      var opacity = ElevationHelper.GetOverlayOpacity(elevation);
      return ColorHelper.CombineColors(color, Color.White, opacity);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    private static Color GetColor(object value)
    {
      switch (value)
      {
        case Color asColor:
          return asColor;

        case string asString:
          return Color.FromHex(asString);

        default:
          throw new NotSupportedException();
      }
    }

    private static ElevationLevel GetElevationLevel(object value)
    {
      switch (value)
      {
        case null:
          return ElevationLevel.dp0;

        case string asString:
          return EnumHelper.AsEnum<ElevationLevel>(asString);

        default:
          throw new NotSupportedException();
      }
    }
  }
}