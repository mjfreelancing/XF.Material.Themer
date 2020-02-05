using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using XF.Material.Themer.Models.Themes;

namespace XF.Material.Themer.Helpers
{
  public static class ResourceDictionaryHelper
  {
    public static void MergeIntoApplicationResources(ResourceDictionary resources)
    {
      var currentResources = Application.Current.Resources;

      foreach (var key in resources.Keys)
      {
        currentResources[key] = resources[key];
      }

      foreach (var themeMergedDictionary in resources.MergedDictionaries)
      {
        currentResources.MergedDictionaries.Add(themeMergedDictionary);
      }
    }

    public static void MergeIntoApplicationResources(string keyPrefix, IThemeColors themeColors)
    {
      var currentResources = Application.Current.Resources;
      var properties = typeof(IThemeColors).GetTypeInfo().DeclaredProperties.Where(prop => prop.CanRead);

      foreach (var property in properties)
      {
        var key = $"{keyPrefix}{property.Name}";
        var value = property.GetValue(themeColors);

        currentResources[key] = value;
      }
    }
  }
}