using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.ViewModels;

namespace XF.Material.Themer.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SurfaceTextPage : ContentPage
  {
    public SurfaceTextPage()
    {
      InitializeComponent();
    }

    private void SetElevationLevel(object sender, ValueChangedEventArgs eventArgs)
    {
      var viewModel = BindingContext as SurfaceTextViewModel;
      var elevationLevels = viewModel.ElevationLevels;
      var newElevationIndex = (int)Math.Floor(eventArgs.NewValue * (elevationLevels.Count - 1));
      var newElevation = elevationLevels.ElementAt(newElevationIndex);

      viewModel.SetDarkElevationLevel(newElevation);
    }
  }
}