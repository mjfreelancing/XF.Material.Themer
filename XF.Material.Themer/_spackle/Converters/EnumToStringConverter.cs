using System;
using System.Globalization;
using Xamarin.Forms;

namespace Spackle.Converters
{
  public class EnumToStringConverter<TEnum> : IValueConverter
    where TEnum : struct
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return Enum.GetName(typeof(TEnum), value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}