using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Converters;
using XF.Material.Themer.Models;
using XF.Material.Themer.Models.Themes;
using XF.Material.Themer.Samples.ViewModels;

namespace XF.Material.Themer.Samples.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ThemeView2 : ContentView
  {
    public ThemeView2()
    {
      InitializeComponent();

      // cannot set these on the 'ThemedWeatherBackgroundGradients' style
      if (CurrentTheme.Instance.Theme == Theme.Light)
      {
        WeatherInfo.BackgroundGradientStops[0].Color = CurrentTheme.Instance.Primary;
        WeatherInfo.BackgroundGradientStops[1].Color = CurrentTheme.Instance.Primary;
        WeatherInfo.BackgroundGradientStops[2].Color = CurrentTheme.Instance.Surface;
      }
      else
      {
        var elevationConverter = new SurfaceElevationConverter();
        var brandedSurface = (Color)elevationConverter.Convert(CurrentTheme.Instance.BrandedSurface, typeof(Color), ElevationLevel.dp1, null);

        WeatherInfo.BackgroundGradientStops[0].Color = brandedSurface;
        WeatherInfo.BackgroundGradientStops[1].Color = brandedSurface;
        WeatherInfo.BackgroundGradientStops[2].Color = CurrentTheme.Instance.Background;
      }

      // todo: the XAML isn't picking up the binding - workaround for now
      var viewModel = BindingContext as WeatherViewModel;
      CollectionView.ItemsSource = viewModel.WeatherForecastItems;
    }
  }
}