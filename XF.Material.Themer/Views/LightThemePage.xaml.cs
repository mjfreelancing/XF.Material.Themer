using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.DataTemplateSelectors;
using XF.Material.Themer.ViewModels;

namespace XF.Material.Themer.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class LightThemePage : ContentPage
  {
    public LightThemePage()
    {
      InitializeComponent();

      // collect all DataTemplates
      var dataTemplates =
        (from resource in Resources
          where resource.Value is DataTemplate
          select (resource.Key, resource.Value as DataTemplate)
        ).ToList();

      // update the view model so the DataTemplates can be displayed in the CarouselView
      AddDataTemplatesToViewModel(dataTemplates.Select(item => item.Key));

      // and hand them over to the theme DataTemplate selector
      CarouselView.ItemTemplate = new ThemeDataTemplateSelector(dataTemplates);
    }

    private void AddDataTemplatesToViewModel(IEnumerable<string> dataTemplateKeys)
    {
      var viewModel = BindingContext as LightThemeViewModel;

      foreach (var key in dataTemplateKeys)
      {
        var themePage =new ThemePage
        {
          Key = key
        };

        viewModel.Pages.Add(themePage);
      }
    }
  }
}