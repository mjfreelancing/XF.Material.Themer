using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Material.Themer.MarkupExtensions
{
  [ContentProperty(nameof(Source))]
  public class ImageSourceExtension : IMarkupExtension
  {
    public string Source { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
      return Source == null
        ? null
        : ImageSource.FromResource(Source, typeof(ImageSourceExtension).GetTypeInfo().Assembly);
    }
  }
}