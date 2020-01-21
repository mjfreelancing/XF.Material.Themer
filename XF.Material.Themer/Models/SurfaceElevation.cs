using Xamarin.Forms;
using XF.Material.Themer.Models.ThemeColors;

namespace XF.Material.Themer.Models
{
  public class SurfaceElevation
  {
    public ElevationLevel Elevation { get; }
    public Color SurfaceColor { get; }
    public Color BrandedSurfaceColor { get; }

    public SurfaceElevation(ElevationLevel elevation, IThemeColors themeColors)
    {
      Elevation = elevation;
      SurfaceColor = themeColors.GetSurfaceColor(elevation);
      BrandedSurfaceColor = themeColors.GetBrandedSurfaceColor(elevation);
    }
  }
}