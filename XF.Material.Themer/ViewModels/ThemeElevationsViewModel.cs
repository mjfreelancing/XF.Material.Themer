using System;
using System.Collections.Generic;
using System.Linq;
using XF.Material.Themer.Models;

namespace XF.Material.Themer.ViewModels
{
  public class ThemeElevationsViewModel : ViewModelBase
  {
    public IList<SurfaceElevation> DarkElevations { get; }

    public ThemeElevationsViewModel()
    {
      // temp for now
      var elevations = ((ElevationLevel[])Enum.GetValues(typeof(ElevationLevel)));
      var darkTheme = new DarkThemeColors();

      DarkElevations = elevations
        .Select(elevation => new SurfaceElevation(elevation, darkTheme))
        .ToList();
    }
  }
}