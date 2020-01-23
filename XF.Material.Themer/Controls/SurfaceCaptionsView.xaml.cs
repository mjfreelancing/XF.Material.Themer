using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Models;

namespace XF.Material.Themer.Controls
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SurfaceCaptionsView : Grid
  {
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(SurfaceCaptionsView), default(string), propertyChanged: OnTitlePropertyChanged);
    public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(nameof(TitleColor), typeof(Color), typeof(SurfaceCaptionsView), default(Color), propertyChanged: OnTitleColorPropertyChanged);
    public static readonly BindableProperty TitleBackgroundColorProperty = BindableProperty.Create(nameof(TitleBackgroundColor), typeof(Color), typeof(SurfaceCaptionsView), default(Color), propertyChanged: OnTitleBackgroundColorPropertyChanged);
    public static readonly BindableProperty SurfaceCaptionsProperty = BindableProperty.Create(nameof(SurfaceCaptions), typeof(IList<SurfaceCaption>), typeof(SurfaceCaptionsView), default(IList<SurfaceCaption>), propertyChanged: OnSurfaceCaptionsPropertyChanged);

    public string Title
    {
      get => (string)GetValue(TitleProperty);
      set => SetValue(TitleProperty, value);
    }

    public Color TitleColor
    {
      get => (Color)GetValue(TitleColorProperty);
      set => SetValue(TitleColorProperty, value);
    }

    public Color TitleBackgroundColor
    {
      get => (Color)GetValue(TitleBackgroundColorProperty);
      set => SetValue(TitleBackgroundColorProperty, value);
    }

    public IList<SurfaceCaption> SurfaceCaptions
    {
      get => (IList<SurfaceCaption>)GetValue(SurfaceCaptionsProperty);
      set => SetValue(SurfaceCaptionsProperty, value);
    }

    public SurfaceCaptionsView()
    {
      InitializeComponent();
    }

    private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<string>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.TitleLabel.Text = propertyValue;
        });
    }

    private static void OnTitleColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<Color>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.TitleLabel.TextColor = propertyValue;
          view.TitleLine.Color = propertyValue;
        });
    }

    private static void OnTitleBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<Color>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.TitleLabel.BackgroundColor = propertyValue;
        });
    }

    private static void OnSurfaceCaptionsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<IList<SurfaceCaption>>(bindable, newValue,
        (view, propertyValue) =>
        {
          // update the binding
          view.CaptionsCollection.ItemsSource = view.SurfaceCaptions;
        });
    }

    private static void SetProperty<TPropertyType>(BindableObject bindable, object newValue, Action<SurfaceCaptionsView, TPropertyType> propertyAssigner)
    {
      if (!(bindable is SurfaceCaptionsView view) || !(newValue is TPropertyType propertyValue))
      {
        return;
      }

      propertyAssigner.Invoke(view, propertyValue);
    }
  }
}