using Xamarin.Forms;

namespace XF.Material.Themer.ViewModels.Themes
{
  public class ThemeDataTemplate
  {
    public string Key { get; }
    public DataTemplate DataTemplate { get; }

    public ThemeDataTemplate(string key, DataTemplate dataTemplate)
    {
      Key = key;
      DataTemplate = dataTemplate;
    }
  }
}