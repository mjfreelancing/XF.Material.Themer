using Xamarin.Forms;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.Models
{
  public class SurfaceElevation
  {
    private readonly IThemeColors _themeColors;
    public ElevationLevel Elevation { get; set; }
    public Color SurfaceColor => _themeColors.GetSurfaceColor(Elevation);
    public Color BrandedSurfaceColor => _themeColors.GetBrandedSurfaceColor(Elevation);

    public SurfaceElevation(IThemeColors themeColors, ElevationLevel elevation = ElevationLevel.dp0)
    {
      _themeColors = themeColors;
      Elevation = elevation;
    }
  }
}