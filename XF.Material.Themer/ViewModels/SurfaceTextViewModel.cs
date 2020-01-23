using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Models;
using XF.Material.Themer.Models.ThemeColors;

namespace XF.Material.Themer.ViewModels
{
  public class SurfaceTextViewModel : ViewModelBase
  {
    public IList<SurfaceCaptions> LightItems { get; }
    public IList<SurfaceCaptions> DarkItems { get; }

    public SurfaceTextViewModel()
    {
      // todo - Create a factory to create these theme colors as it is being performed in multiple places
      var lightTheme = new LightThemeColors();
      LightItems = CreateSurfaceItems(lightTheme, ElevationLevel.dp00);

      var darkTheme = new DarkThemeColors();
      DarkItems = CreateSurfaceItems(darkTheme, ElevationLevel.dp00, ElevationLevel.dp24);
    }

    private static IList<SurfaceCaptions> CreateSurfaceItems(IThemeColors themeColors, params ElevationLevel[] elevations)
    {
      var errorCaption = new SurfaceCaption
      {
        Caption = "Sample Error Text",
        CaptionColor = themeColors.OnError,
        BackgroundColor = themeColors.Error,
        ContrastRatio = ColorHelper.GetContrastRatio(themeColors.OnError, themeColors.Error),
        ContrastRatioColor = themeColors.OnError
      };

      return (from elevation in elevations
          let surfaceElevation = new SurfaceElevation(elevation, themeColors)
          select new[]
          {
            CreateSurfaceItems($"Default Surface at {elevation}", "OnSurface Text", themeColors.OnSurface, surfaceElevation.SurfaceColor, errorCaption),
            CreateSurfaceItems($"Default Surface at {elevation}", "Branded Text", themeColors.Primary, surfaceElevation.SurfaceColor, errorCaption),
            CreateSurfaceItems($"Branded Surface at {elevation}", "OnSurface Text", themeColors.OnSurface, surfaceElevation.BrandedSurfaceColor, errorCaption),
            CreateSurfaceItems($"Branded Surface at {elevation}", "Branded Text", themeColors.Primary, surfaceElevation.BrandedSurfaceColor, errorCaption)
          })
        .SelectMany(item => item)
        .ToList();
    }

    private static SurfaceCaptions CreateSurfaceItems(string title, string caption, Color captionColor, Color backgroundColor, SurfaceCaption errorCaption)
    {
      return new SurfaceCaptions(
        title,
        CreateGeneralCaptions(caption, captionColor, backgroundColor)
          .Concat(new[] { errorCaption })
          .ToList()
      );
    }

    private static IEnumerable<SurfaceCaption> CreateGeneralCaptions(string caption, Color captionColor, Color backgroundColor)
    {
      var emphasis = new EmphasisColor(captionColor);

      var captionItems = new[]
      {
        new {Color = emphasis.Color, Caption = $"{caption} (100%)"},
        new {Color = emphasis.HighEmphasisColor, Caption = $"{caption} (High)"},
        new {Color = emphasis.MediumEmphasisColor, Caption = $"{caption} (Medium)"},
        new {Color = emphasis.DisabledEmphasisColor, Caption = $"{caption} (Disabled)"}
      };

      return captionItems.Select(item => new SurfaceCaption
      {
        Caption = item.Caption,
        CaptionColor = item.Color,
        BackgroundColor = backgroundColor,
        ContrastRatio = ColorHelper.GetContrastRatio(item.Color, backgroundColor),
        ContrastRatioColor = captionColor
      });
    }
  }
}