using Xamarin.Forms;

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
  }
}