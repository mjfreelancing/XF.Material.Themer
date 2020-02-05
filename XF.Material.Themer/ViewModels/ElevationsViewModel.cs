using System.Collections.Generic;
using System.Linq;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Models;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels
{
  public class ElevationsViewModel : ViewModelBase
  {
    public IList<SurfaceElevation> DarkElevations { get; }

    public ElevationsViewModel()
    {
      // temp for now
      var elevations = EnumHelper.GetValueList<ElevationLevel>();
      var darkTheme = new DarkThemeColors();

      DarkElevations = elevations
        .Select(elevation => new SurfaceElevation(darkTheme, elevation))
        .ToList();
    }
  }
}