using System.Collections.Generic;
using Xamarin.Forms;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Models;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels
{
  public class PaletteViewModel : ViewModelBase
  {
    private readonly IThemeColorsFactory _themeColorsFactory = DependencyService.Resolve<IThemeColorsFactory>();

    private IDictionary<int, Color> _primaryTones = new Dictionary<int, Color>
    {
      {900, Color.FromHex("ff7221")},
      {800, Color.FromHex("ff9123")},
      {700, Color.FromHex("ffa124")},
      {600, Color.FromHex("ffb426")},
      {500, Color.FromHex("ffc22a")},
      {400, Color.FromHex("ffca3a")},
      {300, Color.FromHex("ffd559")},
      {200, Color.FromHex("ffe088")},
      {100, Color.FromHex("ffecb6")},
      {50, Color.FromHex("fff8e2")}
    };

    private IDictionary<int, Color> _secondaryTones = new Dictionary<int, Color>
    {
      {900, Color.FromHex("195aa4")},
      {800, Color.FromHex("1d7bc7")},
      {700, Color.FromHex("1f8cdb")},
      {600, Color.FromHex("209fef")},
      {500, Color.FromHex("21aeff")},
      {400, Color.FromHex("33baff")},
      {300, Color.FromHex("54c7ff")},
      {200, Color.FromHex("84d7ff")},
      {100, Color.FromHex("b5e7ff")},
      {50, Color.FromHex("e2f6ff")},
    };

    public IThemeColors LightTheme { get; }
    public IThemeColors DarkTheme { get; }
    public IList<PaletteElement> LightThemeColorElements { get; }
    public IList<PaletteElement> DarkThemeColorElements { get; }

    public PaletteViewModel()
    {
      LightTheme = _themeColorsFactory.GetThemeColors(Theme.Light);
      DarkTheme = _themeColorsFactory.GetThemeColors(Theme.Dark);

      LightThemeColorElements = new List<PaletteElement>
      {
        new PaletteElement {Caption="Primary", ThemeColor=LightTheme.Primary},
        new PaletteElement {Caption="Primary Variant", ThemeColor=LightTheme.PrimaryVariant},
        new PaletteElement {Caption="Secondary", ThemeColor=LightTheme.Secondary},
        new PaletteElement {Caption="Secondary Variant", ThemeColor=LightTheme.SecondaryVariant},
        new PaletteElement {Caption="Background", ThemeColor=LightTheme.Background},
        new PaletteElement {Caption="Branded Background", ThemeColor=LightTheme.BrandedBackground},
        new PaletteElement {Caption="Surface", ThemeColor=LightTheme.Surface},
        new PaletteElement {Caption="Branded Surface", ThemeColor=LightTheme.BrandedSurface},
        new PaletteElement {Caption="Error", ThemeColor=LightTheme.Error},
        new PaletteElement {Caption="On Primary", ThemeColor=LightTheme.OnPrimary},
        new PaletteElement {Caption="On Secondary", ThemeColor=LightTheme.OnSecondary},
        new PaletteElement {Caption="On Background", ThemeColor=LightTheme.OnBackground},
        new PaletteElement {Caption="On Surface", ThemeColor=LightTheme.OnSurface},
        new PaletteElement {Caption="On Error", ThemeColor=LightTheme.OnError}
      };

      DarkThemeColorElements = new List<PaletteElement>
      {
        new PaletteElement {Caption="Primary", ThemeColor=DarkTheme.Primary},
        new PaletteElement {Caption="Primary Variant", ThemeColor=DarkTheme.PrimaryVariant},
        new PaletteElement {Caption="Secondary", ThemeColor=DarkTheme.Secondary},
        new PaletteElement {Caption="Secondary Variant", ThemeColor=DarkTheme.SecondaryVariant},
        new PaletteElement {Caption="Background", ThemeColor=DarkTheme.Background},
        new PaletteElement {Caption="Branded Background", ThemeColor=DarkTheme.BrandedBackground},
        new PaletteElement {Caption="Surface", ThemeColor=DarkTheme.Surface},
        new PaletteElement {Caption="Branded Surface", ThemeColor=DarkTheme.BrandedSurface},
        new PaletteElement {Caption="Error", ThemeColor=DarkTheme.Error},
        new PaletteElement {Caption="On Primary", ThemeColor=DarkTheme.OnPrimary},
        new PaletteElement {Caption="On Secondary", ThemeColor=DarkTheme.OnSecondary},
        new PaletteElement {Caption="On Background", ThemeColor=DarkTheme.OnBackground},
        new PaletteElement {Caption="On Surface", ThemeColor=DarkTheme.OnSurface},
        new PaletteElement {Caption="On Error", ThemeColor=DarkTheme.OnError}
      };
    }

    private static string ToDisplayHex(Color color)
    {
      return $"#{(uint)(color.R * byte.MaxValue):X2}{(uint)(color.G * byte.MaxValue):X2}{(uint)(color.B * byte.MaxValue):X2}";
    }




    // ------------

    // todo: make these input values
    //public string UserBaseBackgroundColor { get; }
    //public string UserPrimaryColor { get; }
    //public string UserOnBackgroundColor { get; }


    // text emphasis
    //
    //public Color BackgroundColor => ColorHelper.CombineColors(UserBaseBackgroundColor, UserPrimaryColor, 0.02);
    //public Color OnBackgroundHighColor => ColorHelper.FromHexWithOpacity(UserOnBackgroundColor, 0.87);
    //public Color OnBackgroundMediumColor => ColorHelper.FromHexWithOpacity(UserOnBackgroundColor, 0.60);
    //public Color OnBackgroundDisabledColor => ColorHelper.FromHexWithOpacity(UserOnBackgroundColor, 0.38);

    //public double OnBackgroundHighContrastRatio => ColorHelper.GetContrastRatio(OnBackgroundHighColor, BackgroundColor);
    //public double OnBackgroundMediumContrastRatio => ColorHelper.GetContrastRatio(OnBackgroundMediumColor, BackgroundColor);
    //public double OnBackgroundDisabledContrastRatio => ColorHelper.GetContrastRatio(OnBackgroundDisabledColor, BackgroundColor);

    //public string OnBackgroundHighColorHex => ColorHelper.CombineColors(BackgroundColor, OnBackgroundHighColor, OnBackgroundHighColor.A).ToHex();
    //public string OnBackgroundMediumColorHex => ColorHelper.CombineColors(BackgroundColor, OnBackgroundMediumColor, OnBackgroundMediumColor.A).ToHex();
    //public string OnBackgroundDisabledColorHex => ColorHelper.CombineColors(BackgroundColor, OnBackgroundDisabledColor, OnBackgroundDisabledColor.A).ToHex();



  }
}