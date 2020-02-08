using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Models;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels
{
  public class ElevationsViewModel : ViewModelBase
  {
    private readonly IThemeColorsFactory _themeColorsFactory = DependencyService.Resolve<IThemeColorsFactory>();

    public IList<SurfaceElevation> DarkElevations { get; }

    public ElevationsViewModel()
    {
      var darkTheme = _themeColorsFactory.GetThemeColors(Theme.Dark);
      var elevations = EnumHelper.GetValueList<ElevationLevel>();

      DarkElevations = elevations
        .Select(elevation => new SurfaceElevation(darkTheme, elevation))
        .ToList();
    }
  }
}