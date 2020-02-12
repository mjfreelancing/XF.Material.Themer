using System;
using System.Globalization;
using Xamarin.Forms;
using XF.Material.Themer.Samples.Views;

namespace XF.Material.Themer.Samples.Converters
{
  public class CurrentTimeConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      // only using a static time - it's only a sample view ;-)
      var timeZone = (TimeZoneInfo)value;
      var newDate = TimeZoneInfo.ConvertTimeFromUtc(ThemeView1.CurrentDate, timeZone);

      return $"{newDate:t}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}