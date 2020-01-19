using System.Collections.Generic;
using XF.Material.Themer.Models;

namespace XF.Material.Themer.ViewModels.Theme
{
  public class SurfaceTextViewModel : ViewModelBase
  {
    public IList<SurfaceItem> LightItems { get; }
    public IList<SurfaceItem> DarkItems { get; }

    public SurfaceTextViewModel()
    {
      // todo - Create a factory to create these theme colors as it is being performed in mulitple places
      var lightTheme = new LightThemeColors();
      LightItems = CreateSurfaceItems(lightTheme);

      var darkTheme = new DarkThemeColors();
      DarkItems = CreateSurfaceItems(darkTheme);
    }

    private static IList<SurfaceItem> CreateSurfaceItems(IThemeColors themeColors)
    {
      return new List<SurfaceItem>
      {
        new SurfaceItem
        {
          Title = "Default Surface", Caption = "OnSurface Text",
          BackgroundColor = themeColors.Surface,
          CaptionColor = themeColors.OnSurface,
          ErrorBackgroundColor = themeColors.Error,
          ErrorTextColor = themeColors.OnError
        },
        new SurfaceItem
        {
          Title = "Default Surface", Caption = "Branded Text",
          BackgroundColor = themeColors.Surface,
          CaptionColor = themeColors.Primary,
          ErrorBackgroundColor = themeColors.Error, 
          ErrorTextColor = themeColors.OnError
        },
        new SurfaceItem
        {
          Title = "Branded Surface", Caption = "OnSurface Text", 
          BackgroundColor = themeColors.BrandedSurface,
          CaptionColor = themeColors.OnSurface,
          ErrorBackgroundColor = themeColors.Error,
          ErrorTextColor = themeColors.OnError
        },
        new SurfaceItem
        {
          Title = "Branded Surface", Caption = "Branded Text", 
          BackgroundColor = themeColors.BrandedSurface,
          CaptionColor = themeColors.Primary,
          ErrorBackgroundColor = themeColors.Error,
          ErrorTextColor = themeColors.OnError
        }
      };
    }
  }
}