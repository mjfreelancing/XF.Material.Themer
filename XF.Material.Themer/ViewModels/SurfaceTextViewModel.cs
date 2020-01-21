﻿using System.Collections.Generic;
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
      LightItems = CreateSurfaceItems(lightTheme);

      var darkTheme = new DarkThemeColors();
      DarkItems = CreateSurfaceItems(darkTheme);
    }

    private static IList<SurfaceCaptions> CreateSurfaceItems(IThemeColors themeColors)
    {
      var errorCaption = new SurfaceCaption
      {
        Caption = "Sample Error Text",
        CaptionColor = themeColors.OnError,
        BackgroundColor = themeColors.Error,
        ContrastRatio = ColorHelper.GetContrastRatio(themeColors.OnError, themeColors.Error),
        ContrastRatioColor = themeColors.OnError
      };

      return new List<SurfaceCaptions>
      {
        CreateSurfaceItems("Default Surface", "OnSurface Text", themeColors.OnSurface, themeColors.Surface, themeColors.Surface, errorCaption),
        CreateSurfaceItems("Default Surface", "Branded Text", themeColors.Primary, themeColors.Surface, themeColors.Surface, errorCaption),
        CreateSurfaceItems("Branded Surface", "OnSurface Text", themeColors.OnSurface, themeColors.BrandedSurface, themeColors.BrandedSurface, errorCaption),
        CreateSurfaceItems("Branded Surface", "Branded Text", themeColors.Primary, themeColors.BrandedSurface, themeColors.BrandedSurface, errorCaption)
      };
    }

    private static SurfaceCaptions CreateSurfaceItems(string title, string caption, Color captionColor,
      Color captionBackgroundColor, Color backgroundColor, SurfaceCaption errorCaption)
    {
      return new SurfaceCaptions(
        title,
        CreateGeneralCaptions(caption, captionColor, captionBackgroundColor, backgroundColor)
          .Concat(new[] {errorCaption})
          .ToList()
      );
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