using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.DataTemplateSelectors;

namespace XF.Material.Themer.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class DarkThemePage : BaseThemePage
  {
    public DarkThemePage()
    {
      InitializeComponent();// collect all DataTemplates

      var themePages = GetThemePages();
      ViewModel.AddThemePages(themePages);

      // and hand them over to the theme DataTemplate selector
      CarouselView.ItemTemplate = new ThemeDataTemplateSelector(themePages);
    }
  }
}