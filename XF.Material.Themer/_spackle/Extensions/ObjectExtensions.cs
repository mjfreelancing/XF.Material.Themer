//using System;

//namespace Spackle.Extensions
//{
//  public static class ObjectExtensions
//  {/// <summary>Determines if the specified object is an integral type (signed or unsigned).</summary>
//    /// <param name="instance">The object instance to be compared to an integral type.</param>
//    /// <returns>Returns <c>true</c> if the specified object is an integral type (signed or unsigned).</returns>
//    public static bool IsIntegral(this object instance)
//    {
//      return instance is byte || instance is sbyte || instance is short || instance is ushort
//             || instance is int || instance is uint || instance is long || instance is ulong;
//    }

//    /// <summary>Converts a specified source <paramref name="instance"/> to another type.</summary>
//    /// <typeparam name="TType">The type that <paramref name="instance"/> is to be converted to.</typeparam>
//    /// <param name="instance">The object instance to be converted.</param>
//    /// <param name="defaultValue">The default value to be returned when <paramref name="instance"/> is <c>null</c>.</param>
//    /// <returns>Returns <paramref name="instance"/> converted to the specified <c>Type</c>.</returns>
//    public static TType As<TType>(this object instance, TType defaultValue = default(TType))
//    {
//      if (instance == null)
//      {
//        return defaultValue;
//      }

//      // return same value if no conversion is required or the destination is a class reference
//      var isClassType = typeof(TType).IsClassType() && typeof(TType) != typeof(string);

//      if (typeof(TType) == instance.GetType() || typeof(TType) == typeof(object) || isClassType)
//      {
//        return (TType)instance;
//      }

//      // convert from integral to bool (conversion from a string is handled further below)
//      if (typeof(TType) == typeof(bool) && instance.IsIntegral())
//      {
//        var intValue = (int)Convert.ChangeType(instance, typeof(int));

//        if ((intValue < 0) || (intValue > 1))
//        {
//          throw new InvalidCastException($"Cannot convert integral '{intValue}' to a Boolean.");
//        }

//        // convert the integral to a boolean
//        instance = (bool)Convert.ChangeType(intValue, typeof(bool));

//        return (TType)instance;
//      }

//      // converting from Enum to byte, sbyte, short, ushort, int, uint, long, or ulong
//      if (instance is Enum && typeof(TType).IsIntegralType())
//      {
//        // cater for when Enum has an underlying type other than 'int'
//        instance = GetEnumAsUnderlyingValue(instance, instance.GetType());

//        // now attempt to perform the converted value to the required type
//        return (TType)Convert.ChangeType(instance, typeof(TType));
//      }

//      // converting from byte, sbyte, short, ushort, int, uint, long, or ulong to Enum
//      if (typeof(TType).IsEnumType() && instance.IsIntegral())
//      {
//        // cater for when Enum has an underlying type other than 'int'
//        instance = GetEnumAsUnderlyingValue(instance, typeof(TType));

//        if (!Enum.IsDefined(typeof(TType), instance))
//        {
//          throw new InvalidCastException($"Cannot cast '{instance}' to a '{typeof(TType)}' value.");
//        }

//        return (TType)instance;
//      }

//      if (typeof(TType) == typeof(bool) || instance is bool || typeof(TType) == typeof(char) || instance is char)
//      {
//        return (TType)Convert.ChangeType(instance, typeof(TType));
//      }

//      // all other cases
//      var strValue = instance.ToString();
//      return StringExtensions.As(strValue, defaultValue);
//    }

//    /// <summary>Converts a specified source <paramref name="instance"/> to its corresponding nullable type.</summary>
//    /// <typeparam name="TType">The (nullable) type that <paramref name="instance"/> is to be converted to.</typeparam>
//    /// <param name="instance">The object instance to be converted.</param>
//    /// <returns>Returns the instance value as its corresponding nullable type.</returns>
//    public static TType? AsNullable<TType>(this object instance)
//      where TType : struct
//    {
//      return instance?.As<TType>();
//    }

//    // gets the enum value as its underlying type (such as short)
//    private static object GetEnumAsUnderlyingValue(object instance, Type enumType)
//    {
//      var underlyingType = Enum.GetUnderlyingType(enumType);
//      return Convert.ChangeType(instance, underlyingType);
//    }
//  }
//}