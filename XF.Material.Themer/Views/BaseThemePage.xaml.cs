using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Helpers;
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

    protected void SetCurrentTheme(ResourceDictionary themeResources)
    {
      // update the current theme colors
      ResourceDictionaryHelper.MergeIntoApplicationResources("ThemeColors", ViewModel.ThemeColors);

      // update the current styles using the most recent theme colors (light/dark styles use different colors / surfaces)
      ResourceDictionaryHelper.MergeIntoApplicationResources(themeResources);
    }
  }
}