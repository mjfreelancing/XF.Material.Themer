using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.DataTemplateSelectors;
using XF.Material.Themer.Themes;

namespace XF.Material.Themer.Pages.Themes
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class DarkThemePage : BaseThemePage
  {
    private readonly ResourceDictionary _styles = new DarkThemeStyles();

    public DarkThemePage()
    {
      InitializeComponent();

      var themePages = GetThemePages();
      ViewModel.AddThemePages(themePages);

      CarouselView.ItemTemplate = new ThemeDataTemplateSelector(themePages);
    }

    protected override void OnAppearing()
    {
      SetCurrentTheme(ViewModel.ThemeColors, _styles);

      base.OnAppearing();
    }
  }
}