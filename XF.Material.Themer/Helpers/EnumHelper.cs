using System;
using System.Collections.Generic;

namespace XF.Material.Themer.Helpers
{
  public static class EnumHelper
  {
    public static IReadOnlyCollection<TType> GetValueList<TType>() where TType : struct, Enum
    {
      return ((TType[])Enum.GetValues(typeof(TType)));
    }

    public static TType AsEnum<TType>(string value) where TType : struct, Enum
    {
      if (Enum.TryParse(value, out TType result))
      {
        return result;
      }

      throw new ArgumentException(nameof(value));
    }
  }
}