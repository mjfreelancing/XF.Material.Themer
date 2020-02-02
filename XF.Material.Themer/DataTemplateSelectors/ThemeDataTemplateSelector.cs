using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XF.Material.Themer.ViewModels;

namespace XF.Material.Themer.DataTemplateSelectors
{
  public class ThemeDataTemplateSelector : DataTemplateSelector
  {
    private readonly IDictionary<string, DataTemplate> _dataTemplates;

    public ThemeDataTemplateSelector(IEnumerable<ThemePage> themePages)
    {
      _dataTemplates = themePages.ToDictionary(item => item.Key, item => item.DataTemplate);
    }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
      var themePage = item as ThemePage;
      return _dataTemplates[themePage.Key];
    }
  }
}