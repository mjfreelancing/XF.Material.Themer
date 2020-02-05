using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Models;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels
{
  public class SurfaceTextViewModel : ViewModelBase
  {
    private readonly IThemeColorsFactory _themeColorsFactory = DependencyService.Resolve<IThemeColorsFactory>();

    public ObservableCollection<SurfaceCaptions> LightItems { get; } = new ObservableCollection<SurfaceCaptions>();
    public ObservableCollection<SurfaceCaptions> DarkItems { get; } = new ObservableCollection<SurfaceCaptions>();
    public IReadOnlyCollection<ElevationLevel> ElevationLevels { get; } = EnumHelper.GetValueList<ElevationLevel>();

    public SurfaceTextViewModel()
    {
      SetLightTheme();
      SetDarkTheme(ElevationLevel.dp0);
    }

    public void SetDarkTheme(ElevationLevel elevation)
    {
      var darkTheme = _themeColorsFactory.CreateThemeColors(Theme.Dark);

      DarkItems.Clear();
      PopulateSurfaceCaptions(DarkItems, darkTheme, elevation);
    }

    private void SetLightTheme()
    {
      var lightTheme = _themeColorsFactory.CreateThemeColors(Theme.Light);
      PopulateSurfaceCaptions(LightItems, lightTheme, ElevationLevel.dp0);
    }

    private static void PopulateSurfaceCaptions(ICollection<SurfaceCaptions> themeItems, IThemeColors themeColors, ElevationLevel elevation)
    {
      var errorCaption = new SurfaceCaption
      {
        Caption = "Sample Error Text",
        CaptionColor = themeColors.OnError,
        BackgroundColor = themeColors.Error,
        ContrastRatio = ColorHelper.GetContrastRatio(themeColors.OnError, themeColors.Error),
        ContrastRatioColor = themeColors.OnError
      };

      var surfaceElevation = new SurfaceElevation(themeColors, elevation);

      AddSurfaceCaption(themeItems, $"Default Surface at {elevation}", "OnSurface Text", themeColors.OnSurface, surfaceElevation.SurfaceColor, errorCaption);
      AddSurfaceCaption(themeItems, $"Default Surface at {elevation}", "Branded Text", themeColors.Primary, surfaceElevation.SurfaceColor, errorCaption);
      AddSurfaceCaption(themeItems, $"Branded Surface at {elevation}", "OnSurface Text", themeColors.OnSurface, surfaceElevation.BrandedSurfaceColor, errorCaption);
      AddSurfaceCaption(themeItems, $"Branded Surface at {elevation}", "Branded Text", themeColors.Primary, surfaceElevation.BrandedSurfaceColor, errorCaption);
    }

    private static void AddSurfaceCaption(ICollection<SurfaceCaptions> themeItems, string title, string caption, Color captionColor,
      Color backgroundColor, SurfaceCaption errorCaption)
    {
      var surfaceCaption = new SurfaceCaptions(
        title,
        CreateGeneralCaptions(caption, captionColor, backgroundColor)
          .Concat(new[] { errorCaption })
          .ToList()
      );

      themeItems.Add(surfaceCaption);
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