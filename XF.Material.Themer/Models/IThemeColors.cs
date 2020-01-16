using Xamarin.Forms;

namespace XF.Material.Themer.Models
{
  // applying material all explained at: https://www.youtube.com/watch?v=FSxgFKlbV9Y
  // colour theming complexities explained here: https://uxplanet.org/designing-systematic-colors-b5d2605b15c

  public interface IThemeColors
  {
    Color Primary { get; }
    Color PrimaryVariant { get; }
    Color OnPrimary { get; }

    Color Secondary { get; }
    Color SecondaryVariant { get; }
    Color OnSecondary { get; }

    Color Background { get; }
    Color BrandedBackground { get; }
    Color OnBackground { get; }

    Color Surface { get; }
    Color BrandedSurface { get; }
    Color OnSurface { get; }

    Color Error { get; }
    Color OnError { get; }

    Color GetSurfaceColor(ElevationLevel elevation);
    Color GetBrandedSurfaceColor(ElevationLevel elevation);
  }
}