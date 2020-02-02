using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.DataTemplateSelectors;
using XF.Material.Themer.Themes;

namespace XF.Material.Themer.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class LightThemePage : BaseThemePage
  {
    public LightThemePage()
    {
      InitializeComponent();

      var themePages = GetThemePages();
      ViewModel.AddThemePages(themePages);

      // and hand them over to the theme DataTemplate selector
      CarouselView.ItemTemplate = new ThemeDataTemplateSelector(themePages);
    }

    protected override void OnAppearing()
    {
      SetThemeStyles(new LightThemeStyles());

      base.OnAppearing();
    }
  }
}