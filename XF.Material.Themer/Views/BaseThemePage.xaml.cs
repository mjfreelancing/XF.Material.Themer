using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Models;
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

    protected void SetCurrentTheme(ResourceDictionary themeResources)
    {
      // append all theme colors with keys prefixed with (the value of) 'ThemeKeyPrefix'
      MergeThemeColorsIntoApplicationResources();

      // merge the XAML based light/dark theme set of styles
      ResourceDictionaryHelper.MergeIntoApplicationResources(themeResources);
    }

    private void MergeThemeColorsIntoApplicationResources()
    {
      var dynamicResources = new Dictionary<string, object>();

      AppendThemeColors(dynamicResources);
      AppendThemeSurfaceColors(dynamicResources);

      ResourceDictionaryHelper.MergeIntoApplicationResources(dynamicResources);
    }

    private void AppendThemeColors(IDictionary<string, object> resources)
    {
      var properties = typeof(IThemeColors).GetTypeInfo().DeclaredProperties.Where(prop => prop.CanRead);

      foreach (var property in properties)
      {
        var key = $"{ThemeKeyPrefix}{property.Name}";
        var value = property.GetValue(ViewModel.ThemeColors);

        resources[key] = value;
      }
    }

    private void AppendThemeSurfaceColors(IDictionary<string, object> resources)
    {
      var surfaceElevation = new SurfaceElevation(ViewModel.ThemeColors);
      var elevations = EnumHelper.GetValueList<ElevationLevel>();

      foreach (var elevation in elevations)
      {
        surfaceElevation.Elevation = elevation;

        var surfaceColor = surfaceElevation.SurfaceColor;
        var brandedSurfaceColor = surfaceElevation.BrandedSurfaceColor;

        resources[$"{ThemeKeyPrefix}Surface{elevation}"] = surfaceColor;
        resources[$"{ThemeKeyPrefix}BrandedSurface{elevation}"] = brandedSurfaceColor;
      }
    }
  }
}