using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.ViewModels;

namespace XF.Material.Themer.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseThemePage : ContentPage
  {
    protected BaseThemeViewModel ViewModel => BindingContext as BaseThemeViewModel;

    public BaseThemePage()
    {
      InitializeComponent();
    }

    protected IReadOnlyList<ThemePage> GetThemePages()
    {
      return
        (from resource in Resources
          where resource.Value is DataTemplate
          select new ThemePage(resource.Key, resource.Value as DataTemplate)
        ).ToList();
    }

    protected static void SetThemeStyles(ResourceDictionary themeResources)
    {
      var currentResources = Application.Current.Resources;

      foreach (var key in themeResources.Keys)
      {
        currentResources[key] = themeResources[key];
      }

      foreach (var themeMergedDictionary in themeResources.MergedDictionaries)
      {
        currentResources.MergedDictionaries.Add(themeMergedDictionary);
      }
    }
  }
}