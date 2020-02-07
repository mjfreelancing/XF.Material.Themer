using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Models.Themes;
using XF.Material.Themer.ViewModels;

namespace XF.Material.Themer.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseThemePage : ContentPage
  {
    private const string ThemeKeyPrefix = "ThemeColor";
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

    protected static void SetCurrentTheme(IThemeColorsBase themeColors, ResourceDictionary themeResources)
    {
      // set the current theme colors that will be referenced by the theme styles
      CurrentTheme.Instance.ThemeColors = themeColors;

      // merge the XAML based light/dark theme set of styles
      ResourceDictionaryHelper.MergeIntoApplicationResources(themeResources);
    }
  }
}