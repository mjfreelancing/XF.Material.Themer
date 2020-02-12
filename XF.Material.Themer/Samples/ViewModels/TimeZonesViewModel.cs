using System;
using System.Collections.Generic;
using System.Linq;
using XF.Material.Themer.ViewModels;

namespace XF.Material.Themer.Samples.ViewModels
{
  public class TimeZonesViewModel : ViewModelBase
  {
    private static readonly IEnumerable<TimeZoneInfo> TimeZoneInfo =
      System.TimeZoneInfo.GetSystemTimeZones().OrderBy(item => item.BaseUtcOffset.TotalMinutes);

    public IList<TimeZoneInfo> TimeZones { get; }

    public TimeZonesViewModel()
    {
      TimeZones = TimeZoneInfo.ToList();
    }
  }
}