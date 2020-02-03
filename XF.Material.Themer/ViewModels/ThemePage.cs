using Xamarin.Forms;

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
}