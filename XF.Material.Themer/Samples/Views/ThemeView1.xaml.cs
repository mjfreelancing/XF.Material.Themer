using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Samples.ViewModels;

namespace XF.Material.Themer.Samples.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ThemeView1 : ContentView
  {
    private TimeZonesViewModel ViewModel { get; }

    public static DateTime CurrentDate { get; private set; }
    public IList<TimeZoneInfo> TimeZones => ViewModel.TimeZones;
    
    public ThemeView1()
    {
      // want to display the same time on all items
      CurrentDate = DateTime.UtcNow;

      ViewModel = new TimeZonesViewModel();
      BindingContext = this;

      InitializeComponent();
    }

    private void LoadTimeZones(object sender, EventArgs e)
    {
      LoadTimeZones();
    }

    private void ScrollToLocalTimeZone(object sender, EventArgs e)
    {
      ScrollToLocalTimeZone(true);
    }

    private void LoadTimeZones()
    {
      CollectionView.ItemsSource = ViewModel.TimeZones;
      ScrollToLocalTimeZone(false);
    }

    private void ScrollToLocalTimeZone(bool animate)
    {
      var localTimeZone = ViewModel.TimeZones.FirstOrDefault(item => System.TimeZoneInfo.Local.Equals(item));
      CollectionView.ScrollTo(localTimeZone, position: ScrollToPosition.Center, animate: animate);
      CollectionView.SelectedItem = localTimeZone;
    }
  }
}