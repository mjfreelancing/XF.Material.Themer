using System;
using XF.Material.Themer.Models;

namespace XF.Material.Themer.Helpers
{
  public static class ElevationHelper
  {
    // return a value between 0 and 1 (0 to 100%)
    public static double GetOverlayOpacity(ElevationLevel elevation)
    {
      // elevation dp => white overlay transparency %
      return elevation switch
      {
        ElevationLevel.dp0 => 0.0d,
        ElevationLevel.dp1 => 0.05d,
        ElevationLevel.dp2 => 0.07d,
        ElevationLevel.dp3 => 0.08d,
        ElevationLevel.dp4 => 0.09d,
        ElevationLevel.dp6 => 0.11d,
        ElevationLevel.dp8 => 0.12d,
        ElevationLevel.dp12 => 0.14d,
        ElevationLevel.dp16 => 0.15d,
        ElevationLevel.dp24 => 0.16d,
        _ => throw new ArgumentOutOfRangeException(nameof(elevation), elevation, null),
      };
    }

    public static int GetDevicePixels(ElevationLevel elevation)
    {
      // elevation dp => white overlay transparency %
      return elevation switch
      {
        ElevationLevel.dp0 => 0,
        ElevationLevel.dp1 => 1,
        ElevationLevel.dp2 => 2,
        ElevationLevel.dp3 => 3,
        ElevationLevel.dp4 => 4,
        ElevationLevel.dp6 => 6,
        ElevationLevel.dp8 => 8,
        ElevationLevel.dp12 => 12,
        ElevationLevel.dp16 => 16,
        ElevationLevel.dp24 => 24,
        _ => throw new ArgumentOutOfRangeException(nameof(elevation), elevation, null)
      };
    }
  }
}