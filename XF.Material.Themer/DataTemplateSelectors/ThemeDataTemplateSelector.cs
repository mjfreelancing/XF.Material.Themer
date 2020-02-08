using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XF.Material.Themer.ViewModels.Themes;

namespace XF.Material.Themer.DataTemplateSelectors
{
  public class ThemeDataTemplateSelector : DataTemplateSelector
  {
    private readonly IDictionary<string, DataTemplate> _dataTemplates;

    public ThemeDataTemplateSelector(IEnumerable<ThemeDataTemplate> themePages)
    {
      _dataTemplates = themePages.ToDictionary(item => item.Key, item => item.DataTemplate);
    }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
      var themePage = item as ThemeDataTemplate;
      return _dataTemplates[themePage.Key];
    }
  }
}