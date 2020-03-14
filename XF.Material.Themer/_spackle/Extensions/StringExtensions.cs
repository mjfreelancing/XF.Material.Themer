//using System;
//using System.ComponentModel;

//namespace Spackle.Extensions
//{
//  public static class StringExtensions
//  {
//    /// <summary>Converts a given string to another type.</summary>
//    /// <typeparam name="TType">The type to convert to.</typeparam>
//    /// <param name="value">The value to be converted.</param>
//    /// <param name="default">The value to return if <c>value</c> is <c>null</c>, empty or contains whitespace, or is considered
//    /// invalid for the <typeparamref name="TType"/> converter.</param>
//    /// <returns>The converted value, or the <c>default</c> value if the conversion cannot be performed.</returns>
//    /// <remarks>
//    ///   <para>Supported conversions include byte, sbyte, decimal, double, float, int, uint, long, ulong, short, ushort, string and enum.</para>
//    ///   <para>Char and Boolean type conversions must be performed using the <see cref="ObjectExtensions.As{TType}"/> method.</para>
//    ///   <para>No attempt is made to avoid overflow exceptions.</para>
//    /// </remarks>
//    public static TType As<TType>(this string value, TType @default = default(TType))
//    {
//      if (string.IsNullOrWhiteSpace(value) || !TypeDescriptor.GetConverter(typeof(TType)).IsValid(value))
//      {
//        return @default;
//      }

//      if (typeof(TType).IsEnum)
//      {
//        return (TType)Enum.Parse(typeof(TType), value);
//      }

//      return (TType)TypeDescriptor.GetConverter(typeof(TType)).ConvertFromString(value);
//    }

//    /// <summary>Converts a given string to another nullable type.</summary>
//    /// <typeparam name="TType">The nullable type to convert to.</typeparam>
//    /// <param name="value">The value to be converted.</param>
//    /// <returns>The converted value, or <c>null</c> if the conversion cannot be performed.</returns>
//    public static TType? AsNullable<TType>(this string value)
//      where TType : struct
//    {
//      if (string.IsNullOrWhiteSpace(value) || !TypeDescriptor.GetConverter(typeof(TType)).IsValid(value))
//      {
//        return null;
//      }

//      return As<TType>(value);
//    }
//  }
//}