using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.DataTemplateSelectors;
using XF.Material.Themer.Helpers;
using XF.Material.Themer.Themes;

namespace XF.Material.Themer.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class DarkThemePage : BaseThemePage
  {
    public DarkThemePage()
    {
      InitializeComponent();

      var themePages = GetThemePages();
      ViewModel.AddThemePages(themePages);

      CarouselView.ItemTemplate = new ThemeDataTemplateSelector(themePages);

      RegisterDynamicResource("ThemedSampleLabelTextColor", () => ColorHelper.FromColorWithOpacity(ViewModel.ThemeColors.OnSurface, 0.87));
    }

    protected override void OnAppearing()
    {
      // apply dynamic style values provided by the view model
      ApplyDynamicResources();

      // merge the theme into the global resource dictionary
      ResourceDictionaryHelper.MergeIntoApplicationResources(new DarkThemeStyles());

      base.OnAppearing();
    }
  }
}