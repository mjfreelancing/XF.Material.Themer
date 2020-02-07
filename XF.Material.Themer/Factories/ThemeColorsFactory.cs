using System;
using System.Collections.Generic;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.Factories
{
  public class ThemeColorsFactory : IThemeColorsFactory
  {
    private readonly IDictionary<Theme, Lazy<IThemeColors>> _registry = new Dictionary<Theme, Lazy<IThemeColors>>
    {
      {Theme.Light, new Lazy<IThemeColors>(() => new LightThemeColors())},
      {Theme.Dark, new Lazy<IThemeColors>(() => new DarkThemeColors())}
    };

    public IThemeColors GetThemeColors(Theme theme)
    {
      return _registry[theme].Value;
    }
  }
}