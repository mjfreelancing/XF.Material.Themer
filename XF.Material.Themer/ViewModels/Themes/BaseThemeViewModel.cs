using System.Collections.Generic;
using System.Collections.ObjectModel;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels.Themes
{
  public class BaseThemeViewModel : ViewModelBase
  {
    public Theme Theme { get; }
    public IThemeColors ThemeColors { get; }

    public ObservableCollection<ThemeDataTemplate> Pages { get; }

    protected BaseThemeViewModel(IThemeColorsFactory themeColorsFactory, Theme theme)
    {
      Theme = theme;
      ThemeColors = themeColorsFactory.GetThemeColors(theme);
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