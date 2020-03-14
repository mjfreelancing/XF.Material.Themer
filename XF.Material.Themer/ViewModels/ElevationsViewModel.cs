using AllOverIt.Helpers;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Models;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels
{
  public class ElevationsViewModel : ViewModelBase
  {
    public IList<SurfaceElevation> DarkElevations { get; }

    public ElevationsViewModel()
      : this(DependencyService.Resolve<IThemeColorsFactory>())
    {
    }

    internal ElevationsViewModel(IThemeColorsFactory themeColorsFactory)
    {
      var darkTheme = themeColorsFactory.GetThemeColors(Theme.Dark);
      var elevations = EnumHelper.GetEnumValues<ElevationLevel>();

      DarkElevations = elevations
        .Select(elevation => new SurfaceElevation(darkTheme, elevation))
        .ToList();
    }
  }
}