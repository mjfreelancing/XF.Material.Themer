using System.Collections.Generic;
using XF.Material.Themer.Samples.Models;

namespace XF.Material.Themer.Samples.ViewModels
{
  public class WeatherViewModel
  {
    public IList<WeatherForecastItem> WeatherForecastItems { get; }

    public WeatherViewModel()
    {
      WeatherForecastItems = new List<WeatherForecastItem>
      {
        new WeatherForecastItem
        {
          Title = "0-3 hrs",
          AvgTemp = "25\u00B0 C",
          Humidity = "90%",
          Wind = "15 km/h",
        },
        new WeatherForecastItem
        {
          Title = "3-6 hrs",
          AvgTemp = "26\u00B0 C",
          Humidity = "90%",
          Wind = "12 km/h",
        },
        new WeatherForecastItem
        {
          Title = "6-9 hrs",
          AvgTemp = "27\u00B0 C",
          Humidity = "85%",
          Wind = "12 km/h",
        },
        new WeatherForecastItem
        {
          Title = "9-12 hrs",
          AvgTemp = "28\u00B0 C",
          Humidity = "85%",
          Wind = "10 km/h",
        },
        new WeatherForecastItem
        {
          Title = "12-15 hrs",
          AvgTemp = "28\u00B0 C",
          Humidity = "85%",
          Wind = "10 km/h",
        },
        new WeatherForecastItem
        {
          Title = "15-18 hrs",
          AvgTemp = "26\u00B0 C",
          Humidity = "80%",
          Wind = "15 km/h",
        },
        new WeatherForecastItem
        {
          Title = "18-21 hrs",
          AvgTemp = "24\u00B0 C",
          Humidity = "75%",
          Wind = "16 km/h",
        },
        new WeatherForecastItem
        {
          Title = "21-24 hrs",
          AvgTemp = "22\u00B0 C",
          Humidity = "75%",
          Wind = "20 km/h",
        },
      };
    }
  }
}