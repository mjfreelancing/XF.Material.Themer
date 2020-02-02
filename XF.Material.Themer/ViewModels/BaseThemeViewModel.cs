using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XF.Material.Themer.Factories;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.ViewModels
{
  public class ThemePage
  {
    public string Key { get; }
    public DataTemplate DataTemplate { get; }

    public ThemePage(string key, DataTemplate dataTemplate)
    {
      Key = key;
      DataTemplate = dataTemplate;
    }
  }

  public class BaseThemeViewModel : ViewModelBase
  {
    private readonly IThemeColorsFactory _themeColorsFactory = DependencyService.Resolve<IThemeColorsFactory>();

    public IThemeColors ThemeColors { get; }

    public ObservableCollection<ThemePage> Pages { get; }

    protected BaseThemeViewModel(Theme theme)
    {
      ThemeColors = _themeColorsFactory.CreateThemeColors(theme);
      Pages = new ObservableCollection<ThemePage>();
    }

    public void AddThemePages(IEnumerable<ThemePage> themePages)
    {
      foreach (var themePage in themePages)
      {
        Pages.Add(themePage);
      }
    }
  }
}