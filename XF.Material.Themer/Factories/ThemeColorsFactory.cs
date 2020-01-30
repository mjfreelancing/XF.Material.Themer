using System;
using System.Collections.Generic;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.Factories
{
  public class ThemeColorsFactory : IThemeColorsFactory
  {
    private IDictionary<Theme, Func<IThemeColors>> _registry = new Dictionary<Theme, Func<IThemeColors>>
    {
      {Theme.Light, () => new LightThemeColors()},
      {Theme.Dark, () => new DarkThemeColors()}
    };

    public IThemeColors CreateThemeColors(Theme theme)
    {
      return _registry[theme].Invoke();
    }
  }
}