using Xamarin.Forms;
using XF.Material.Themer.Factories;

namespace XF.Material.Themer
{
  public partial class App : Application
  {

    public App()
    {
      InitializeComponent();

      DependencyService.Register<IThemeColorsFactory, ThemeColorsFactory>();

      MainPage = new AppShell();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
