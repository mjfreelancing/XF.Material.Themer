using System.Collections.Generic;
using Xamarin.Forms;

namespace XF.Material.Themer.Helpers
{
  public static class ResourceDictionaryHelper
  {
    public static void MergeIntoApplicationResources(ResourceDictionary resources)
    {
      MergeDictionaryIntoApplicationResources(resources);

      var currentResources = Application.Current.Resources;

      foreach (var themeMergedDictionary in resources.MergedDictionaries)
      {
        currentResources.MergedDictionaries.Add(themeMergedDictionary);
      }
    }

    public static void MergeIntoApplicationResources(IDictionary<string, object> resources)
    {
      MergeDictionaryIntoApplicationResources(resources);
    }

    private static void MergeDictionaryIntoApplicationResources(IDictionary<string, object> resources)
    {
      var currentResources = Application.Current.Resources;

      foreach (var resource in resources)
      {
        currentResources[resource.Key] = resource.Value;
      }
    }
  }
}