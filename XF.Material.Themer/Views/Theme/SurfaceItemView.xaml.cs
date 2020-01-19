using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Helpers;

namespace XF.Material.Themer.Views.Theme
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SurfaceItemView : Grid
  {
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(SurfaceItemView), default(string), propertyChanged: OnTitlePropertyChanged);
    public static readonly BindableProperty CaptionProperty = BindableProperty.Create(nameof(Caption), typeof(string), typeof(SurfaceItemView), default(string), propertyChanged: OnCaptionPropertyChanged);
    public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(nameof(TitleColor), typeof(Color), typeof(SurfaceItemView), default(Color), propertyChanged: OnTitleColorPropertyChanged);
    public static readonly BindableProperty TitleBackgroundColorProperty = BindableProperty.Create(nameof(TitleBackgroundColor), typeof(Color), typeof(SurfaceItemView), default(Color), propertyChanged: OnTitleBackgroundColorPropertyChanged);
    public static readonly BindableProperty CaptionColorProperty = BindableProperty.Create(nameof(CaptionColor), typeof(Color), typeof(SurfaceItemView), default(Color), propertyChanged: OnCaptionColorPropertyChanged);
    public static readonly BindableProperty ErrorTextColorProperty = BindableProperty.Create(nameof(ErrorTextColor), typeof(Color), typeof(SurfaceItemView), default(Color), propertyChanged: OnErrorTextColorPropertyChanged);
    public static readonly BindableProperty ErrorBackgroundColorProperty = BindableProperty.Create(nameof(ErrorBackgroundColor), typeof(Color), typeof(SurfaceItemView), default(Color), propertyChanged: OnErrorBackgroundColorPropertyChanged);

    public string Title
    {
      get => (string)GetValue(TitleProperty);
      set => SetValue(TitleProperty, value);
    }
    public string Caption
    {
      get => (string)GetValue(CaptionProperty);
      set => SetValue(CaptionProperty, value);
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

    public Color CaptionColor
    {
      get => (Color)GetValue(CaptionColorProperty);
      set => SetValue(CaptionColorProperty, value);
    }

    public Color ErrorTextColor
    {
      get => (Color)GetValue(ErrorTextColorProperty);
      set => SetValue(ErrorTextColorProperty, value);
    }

    public Color ErrorBackgroundColor
    {
      get => (Color)GetValue(ErrorBackgroundColorProperty);
      set => SetValue(ErrorBackgroundColorProperty, value);
    }

    public SurfaceItemView()
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

    private static void OnCaptionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<string>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.CaptionLabel.Text = $"{propertyValue} (100%)";
          view.CaptionHighEmphasisLabel.Text = $"{propertyValue} (HighEmphasis)";
          view.CaptionMediumEmphasisLabel.Text = $"{propertyValue} (MediumEmphasis)";
          view.CaptionDisabledEmphasisLabel.Text = $"{propertyValue} (DisabledEmphasis)";
        });
    }

    private static void OnCaptionColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<Color>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.CaptionLabel.TextColor = propertyValue;

          var emphasisColor = new EmphasisColor(propertyValue);

          view.CaptionHighEmphasisLabel.TextColor = emphasisColor.HighEmphasisColor;
          view.CaptionMediumEmphasisLabel.TextColor = emphasisColor.MediumEmphasisColor;
          view.CaptionDisabledEmphasisLabel.TextColor = emphasisColor.DisabledEmphasisColor;
        });
    }

    private static void OnErrorTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<Color>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.ErrorLabel.TextColor = propertyValue;
        });
    }

    private static void OnErrorBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<Color>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.ErrorLabel.BackgroundColor = propertyValue;
        });
    }

    private static void SetProperty<TPropertyType>(BindableObject bindable, object newValue, Action<SurfaceItemView, TPropertyType> propertyAssigner)
    {
      if (!(bindable is SurfaceItemView view) || !(newValue is TPropertyType propertyValue))
      {
        return;
      }

      propertyAssigner.Invoke(view, propertyValue);
    }
  }
}