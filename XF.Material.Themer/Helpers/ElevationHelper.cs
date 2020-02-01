﻿using System;
using XF.Material.Themer.Models;

namespace XF.Material.Themer.Helpers
{
  public static class ElevationHelper
  {
    // return a value between 0 and 1 (0 to 100%)
    public static double GetOverlayOpacity(ElevationLevel elevation)
    {
      // elevation dp => white overlay transparency %
      switch (elevation)
      {
        case ElevationLevel.dp0: return 0.0d;
        case ElevationLevel.dp1: return 0.05d;
        case ElevationLevel.dp2: return 0.07d;
        case ElevationLevel.dp3: return 0.08d;
        case ElevationLevel.dp4: return 0.09d;
        case ElevationLevel.dp6: return 0.11d;
        case ElevationLevel.dp8: return 0.12d;
        case ElevationLevel.dp12: return 0.14d;
        case ElevationLevel.dp16: return 0.15d;
        case ElevationLevel.dp24: return 0.16d;

        default:
          throw new ArgumentOutOfRangeException(nameof(elevation), elevation, null);
      }
    }

    public static int GetDevicePixels(ElevationLevel elevation)
    {
      // elevation dp => white overlay transparency %
      switch (elevation)
      {
        case ElevationLevel.dp0: return 0;
        case ElevationLevel.dp1: return 1;
        case ElevationLevel.dp2: return 2;
        case ElevationLevel.dp3: return 3;
        case ElevationLevel.dp4: return 4;
        case ElevationLevel.dp6: return 6;
        case ElevationLevel.dp8: return 8;
        case ElevationLevel.dp12: return 12;
        case ElevationLevel.dp16: return 16;
        case ElevationLevel.dp24: return 24;

        default:
          throw new ArgumentOutOfRangeException(nameof(elevation), elevation, null);
      }
    }
  }
}