using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Models;

namespace XF.Material.Themer.ViewModels.Theme
{
  public class SurfaceTextViewModel : ViewModelBase
  {
    public IList<SurfaceItem> LightItems { get; }
    public IList<SurfaceItem> DarkItems { get; }

    public SurfaceTextViewModel()
    {
      // todo - Create a factory to create these theme colors as it is being performed in multiple places
      var lightTheme = new LightThemeColors();
      LightItems = CreateSurfaceItems(lightTheme);

      var darkTheme = new DarkThemeColors();
      DarkItems = CreateSurfaceItems(darkTheme);
    }

    private static IList<SurfaceItem> CreateSurfaceItems(IThemeColors themeColors)
    {
      var errorCaption = new SurfaceCaption
      {
        Caption = "Sample Error Text",
        CaptionColor = themeColors.OnError,
        BackgroundColor = themeColors.Error,
        ContrastRatio = ColorHelper.GetContrastRatio(themeColors.OnError, themeColors.Error),
        ContrastRatioColor = themeColors.OnError
      };

      return new List<SurfaceItem>
      {
        new SurfaceItem
        {
          Title = "Default Surface",
          SurfaceCaptions = CreateGeneralCaptions("OnSurface Text", themeColors.OnSurface, themeColors.Surface, themeColors.Surface)
            .Concat(new[] {errorCaption})
            .ToList()
        },
        new SurfaceItem
        {
          Title = "Default Surface",
          SurfaceCaptions = CreateGeneralCaptions("Branded Text", themeColors.Primary, themeColors.Surface, themeColors.Surface)
            .Concat(new[] {errorCaption})
            .ToList()
        },
        new SurfaceItem
        {
          Title = "Branded Surface",
          SurfaceCaptions = CreateGeneralCaptions("OnSurface Text", themeColors.OnSurface, themeColors.BrandedSurface, themeColors.BrandedSurface)
            .Concat(new[] {errorCaption})
            .ToList()
        },
        new SurfaceItem
        {
          Title = "Branded Surface",
          SurfaceCaptions = CreateGeneralCaptions("Branded Text", themeColors.Primary, themeColors.BrandedSurface, themeColors.BrandedSurface)
            .Concat(new[] {errorCaption})
            .ToList()
        }
      };
    }

    private static IEnumerable<SurfaceCaption> CreateGeneralCaptions(string caption, Color captionColor, Color captionBackgroundColor, Color backgroundColor)
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
        BackgroundColor = captionBackgroundColor,
        ContrastRatio = ColorHelper.GetContrastRatio(item.Color, backgroundColor),
        ContrastRatioColor = captionColor
      });
    }
  }
}