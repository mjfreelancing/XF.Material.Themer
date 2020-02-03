using System;
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
    private readonly IDictionary<string, Func<object>> StyleRegistry = new Dictionary<string, Func<object>>();
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

    protected void RegisterDynamicResource(string key, Func<object> valueResolver)
    {
      StyleRegistry.Add(key, valueResolver);
    }

    protected void ApplyDynamicResources()
    {
      foreach (var style in StyleRegistry)
      {
        Application.Current.Resources[style.Key] = style.Value.Invoke();
      }
    }
  }
}