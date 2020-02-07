using Xamarin.Forms;

namespace XF.Material.Themer.Models.Themes
{
  // applying material all explained at: https://www.youtube.com/watch?v=FSxgFKlbV9Y
  // colour theming complexities explained here: https://uxplanet.org/designing-systematic-colors-b5d2605b15c

  public interface IThemeColors : IThemeColorsBase
  {
    // 0-1
    double BrandOpacity { get; }

    Color GetSurfaceColor(ElevationLevel elevation);
    Color GetBrandedSurfaceColor(ElevationLevel elevation);
  }
}