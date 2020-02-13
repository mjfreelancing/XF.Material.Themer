using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels.Themes
{
  public class BaseThemeViewModel : ViewModelBase
  {
    private readonly IThemeColorsFactory _themeColorsFactory = DependencyService.Resolve<IThemeColorsFactory>();

    public Theme Theme { get; }
    public IThemeColors ThemeColors { get; }

    public ObservableCollection<ThemeDataTemplate> Pages { get; }

    protected BaseThemeViewModel(Theme theme)
    {
      Theme = theme;
      ThemeColors = _themeColorsFactory.GetThemeColors(theme);
      Pages = new ObservableCollection<ThemeDataTemplate>();
    }

    public void AddThemePages(IEnumerable<ThemeDataTemplate> themePages)
    {
      foreach (var themePage in themePages)
      {
        Pages.Add(themePage);
      }
    }
  }
}