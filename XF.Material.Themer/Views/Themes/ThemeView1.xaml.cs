using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.Views.Themes
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ThemeView1 : ContentView
  {
    private readonly IThemeColorsFactory _themeColorsFactory = DependencyService.Resolve<IThemeColorsFactory>();

    public ThemeView1()
    {
      InitializeComponent();
    }

    private void Button_OnLightClicked(object sender, EventArgs e)
    {
      CurrentTheme.Instance.ThemeColors = _themeColorsFactory.GetThemeColors(Theme.Light);

    }

    private void Button_OnDarkClicked(object sender, EventArgs e)
    {
      CurrentTheme.Instance.ThemeColors = _themeColorsFactory.GetThemeColors(Theme.Dark);
    }
  }
}