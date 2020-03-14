using AllOverIt.XamarinForms.Helpers;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Models.Themes;
using XF.Material.Themer.ViewModels.Themes;

namespace XF.Material.Themer.Pages.Themes
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseThemePage : ContentPage
  {
    protected BaseThemeViewModel ViewModel => BindingContext as BaseThemeViewModel;

    public BaseThemePage()
    {
      InitializeComponent();
    }

    protected IReadOnlyList<ThemeDataTemplate> GetThemePages()
    {
      return
        (from resource in Resources
          where resource.Value is DataTemplate
          select new ThemeDataTemplate(resource.Key, resource.Value as DataTemplate)
        ).ToList();
    }

    protected static void SetCurrentTheme(Theme theme, IThemeColorsBase themeColors, ResourceDictionary themeResources)
    {
      // set the current theme colors that will be referenced by the theme styles
      //CurrentTheme.Instance.ThemeColors = themeColors;
      CurrentTheme.SetTheme(theme, themeColors);

      // merge the XAML based light/dark theme set of styles
      ResourceDictionaryHelper.MergeIntoApplicationResources(themeResources);
    }
  }
}