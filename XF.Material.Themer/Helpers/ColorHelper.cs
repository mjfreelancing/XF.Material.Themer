using System;
using Xamarin.Forms;

namespace XF.Material.Themer.Helpers
{
  public static class ColorHelper
  {
    // foreground must be the lighter color and background must be the darker color
    // not auto-switching based on luminosity because the foreground color may have an
    // alpha / opacity that needs to be applied.
    public static double GetContrastRatio(Color foregroundColor, Color backgroundColor)
    {
      // https://medium.muz.li/the-science-of-color-contrast-an-expert-designers-guide-33e84c41d156

      if (foregroundColor.Luminosity < backgroundColor.Luminosity)
      {
        throw new ArgumentOutOfRangeException(nameof(foregroundColor), "The foreground color must be lighter than the background color");
      }

      var combinedColor = CombineColors(backgroundColor, foregroundColor, foregroundColor.A);

      var luminance1 = GetRelativeLuminance(combinedColor);
      var luminance2 = GetRelativeLuminance(backgroundColor);

      return Math.Round((luminance1 + 0.05) / (luminance2 + 0.05), 2);
    }

    public static double GetRelativeLuminance(Color color)
    {
      // https://www.w3.org/TR/WCAG20/#relativeluminancedef

      double GetComponent(double value)
      {
        return value <= 0.03928
          ? value / 12.92
          : Math.Pow((value + 0.055) / 1.055, 2.4);
      }

      var r = GetComponent(color.R);
      var g = GetComponent(color.G);
      var b = GetComponent(color.B);

      return 0.2126 * r + 0.7152 * g + 0.0722 * b;
    }

    // combines two opaque colors, with the overlay having a specified opacity (0-1)
    public static Color CombineColors(string baseColorHex, string overlayColorHex, double overlayOpacity)
    {
      var baseColor = Color.FromHex(baseColorHex);
      var overlayColor = Color.FromHex(overlayColorHex);

      var combinedRed = (int)Math.Ceiling((1 - overlayOpacity) * GetRed(baseColor) + overlayOpacity * GetRed(overlayColor));
      var combinedGreen = (int)Math.Ceiling((1 - overlayOpacity) * GetGreen(baseColor) + overlayOpacity * GetGreen(overlayColor));
      var combinedBlue = (int)Math.Ceiling((1 - overlayOpacity) * GetBlue(baseColor) + overlayOpacity * GetBlue(overlayColor));

      return Color.FromRgb(combinedRed, combinedGreen, combinedBlue);
    }

    public static Color CombineColors(Color baseColor, Color overlayColor, double overlayOpacity)
    {
      var combinedRed = (int)Math.Ceiling((1 - overlayOpacity) * GetRed(baseColor) + overlayOpacity * GetRed(overlayColor));
      var combinedGreen = (int)Math.Ceiling((1 - overlayOpacity) * GetGreen(baseColor) + overlayOpacity * GetGreen(overlayColor));
      var combinedBlue = (int)Math.Ceiling((1 - overlayOpacity) * GetBlue(baseColor) + overlayOpacity * GetBlue(overlayColor));

      return Color.FromRgb(combinedRed, combinedGreen, combinedBlue);
    }

    // opacity = 0-1
    public static Color FromHexWithOpacity(string colorHex, double opacity)
    {
      var color = Color.FromHex(colorHex);

      return Color.FromRgba(color.R, color.G, color.B, opacity);
    }

    public static int GetRed(Color color)
    {
      return (int)(color.R * 255);
    }

    public static int GetGreen(Color color)
    {
      return (int)(color.G * 255);
    }

    public static int GetBlue(Color color)
    {
      return (int)(color.B * 255);
    }
  }
}