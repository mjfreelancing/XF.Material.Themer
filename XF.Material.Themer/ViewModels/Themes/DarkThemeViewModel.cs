using Xamarin.Forms;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels.Themes
{
  public class DarkThemeViewModel : BaseThemeViewModel
  {
    public DarkThemeViewModel()
      : this(DependencyService.Resolve<IThemeColorsFactory>())
    {
    }

    internal DarkThemeViewModel(IThemeColorsFactory themeColorsFactory)
      : base(themeColorsFactory, Theme.Dark)
    {
    }
  }
}