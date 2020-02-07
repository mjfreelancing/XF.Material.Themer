using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.Factories
{
  public interface IThemeColorsFactory
  {
    IThemeColors GetThemeColors(Theme theme);
  }
}