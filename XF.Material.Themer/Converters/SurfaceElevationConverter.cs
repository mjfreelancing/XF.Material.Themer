using AllOverIt.Extensions;
using AllOverIt.XamarinForms.Helpers;
using System;
using System.Globalization;
using Xamarin.Forms;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Models;

namespace XF.Material.Themer.Converters
{
  public class SurfaceElevationConverter : IValueConverter
  {
    // applies a white overlay on top of the source color at a specified opacity
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var color = GetColor(value);    // assumed to be the theme's surface color, but can be any color
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
      return value switch
      {
        Color asColor => asColor,
        string asString => Color.FromHex(asString),
        _ => throw new NotSupportedException()
      };
    }

    private static ElevationLevel GetElevationLevel(object value)
    {
      return value switch
      {
        null => ElevationLevel.dp0,
        string asString => asString.As<ElevationLevel>(),
        ElevationLevel asElevationLevel => asElevationLevel,
        _ => throw new NotSupportedException()
      };
    }
  }
}