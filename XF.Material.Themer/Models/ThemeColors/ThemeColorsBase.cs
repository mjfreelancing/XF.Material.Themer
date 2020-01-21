using Xamarin.Forms;
using XF.Material.Themer.Helpers;

namespace XF.Material.Themer.Models.ThemeColors
{
  public abstract class ThemeColorsBase : IThemeColors
  {
    public abstract Color Primary { get; set; }
    public abstract Color PrimaryVariant { get; set; }
    public abstract Color Secondary { get; set; }
    public abstract Color SecondaryVariant { get; set; }
    public abstract Color Background { get; set; }
    public abstract Color Surface { get; set; }
    public abstract Color Error { get; set; }
    public abstract Color OnPrimary { get; set; }
    public abstract Color OnSecondary { get; set; }
    public abstract Color OnBackground { get; set; }
    public abstract Color OnSurface { get; set; }
    public abstract Color OnError { get; set; }
    public double BrandOpacity { get; set; } = 0.075d;

    public Color BrandedBackground => ColorHelper.CombineColors(Background, Primary, BrandOpacity);
    public Color BrandedSurface => ColorHelper.CombineColors(Surface, Primary, BrandOpacity);

    protected static Color CreateColor(string hex)
    {
      return Color.FromHex(hex);
    }

    public Color GetSurfaceColor(ElevationLevel elevation)
    {
      var opacity = (double)elevation / 100;
      return ColorHelper.CombineColors(Background, Color.White, opacity);
    }

    public Color GetBrandedSurfaceColor(ElevationLevel elevation)
    {
      var opacity = (double)elevation / 100;
      return ColorHelper.CombineColors(BrandedBackground, Color.White, opacity);
    }
  }
}