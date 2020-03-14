using Xamarin.Forms;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels.Themes
{
  public class LightThemeViewModel : BaseThemeViewModel
  {
    public LightThemeViewModel()
      : this(DependencyService.Resolve<IThemeColorsFactory>())
    {
    }

    internal LightThemeViewModel(IThemeColorsFactory themeColorsFactory)
      : base(themeColorsFactory, Theme.Light)
    {
    }
  }
}