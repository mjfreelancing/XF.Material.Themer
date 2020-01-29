using System;
using System.Collections.Generic;

namespace XF.Material.Themer.Helpers
{
  public static class EnumHelper
  {
    public static IReadOnlyCollection<TType> GetValueList<TType>() where TType : Enum
    {
      return ((TType[])Enum.GetValues(typeof(TType)));
    }
  }
}