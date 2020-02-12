using System;
using System.Globalization;
using Xamarin.Forms;

namespace XF.Material.Themer.Samples.Converters
{
  public class TimeSpanToGmtConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var offset = (TimeSpan) value;

      var hours = offset.Hours;
      var minutes = offset.Minutes;

      // https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
      return $"(GMT{hours:+00;-00;+00}:{minutes:00})";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}