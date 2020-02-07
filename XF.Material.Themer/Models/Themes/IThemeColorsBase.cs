using Xamarin.Forms;

namespace XF.Material.Themer.Models.Themes
{
  public interface IThemeColorsBase
  {
    // Primary color used for light theme, and a desaturated version is used for the dark theme (50-400 tonal value, default to 200).
    // In the dark theme, either of the light/dark theme primary colors can be used but use of the light theme color should be limited
    // to one or two branded elements, such as a logo or a branded button.
    Color Primary { get; }

    // A tonal variant of the Primary color, for both light and dark themes.
    Color PrimaryVariant { get; }

    Color Secondary { get; }
    Color SecondaryVariant { get; }

    Color Background { get; }
    Color BrandedBackground { get; }

    Color Surface { get; }
    Color BrandedSurface { get; }

    Color Error { get; }

    // 'On' colors are applied to text, icons, and strokes which are placed on top of surfaces that use a primary,
    // secondary, surface, background, or error color.
    // In dark theme, the text on every surface / background can be a shade of white or the primary (desaturated) color, using
    // opacity values of 87%, 60% or 38% (high, medium, disabled emphasis). That is, the text color can use Primary or OnPrimary.
    Color OnPrimary { get; }
    Color OnSecondary { get; }
    Color OnBackground { get; }
    Color OnSurface { get; }
    Color OnError { get; }
  }
}