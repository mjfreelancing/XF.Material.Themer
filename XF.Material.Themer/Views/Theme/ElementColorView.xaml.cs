﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Themer.Helpers;

namespace XF.Material.Themer.Views.Theme
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ElementColorView : Grid
  {
    public static readonly BindableProperty CaptionProperty = BindableProperty.Create(nameof(Caption), typeof(string), typeof(ElementColorView), default(string), propertyChanged: OnCaptionPropertyChanged);
    public static readonly BindableProperty ColorHexProperty = BindableProperty.Create(nameof(ColorHex), typeof(string), typeof(ElementColorView), default(string), propertyChanged: OnColorHexPropertyChanged);
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ElementColorView), default(Color), propertyChanged: OnTextColorPropertyChanged);
    
    // ThemeColor auto-sets the TextColor that produces the greatest contrast. For manual
    // setting of TextColor use BackgroundColor instead of ThemeColor.
    public static readonly BindableProperty ThemeColorProperty = BindableProperty.Create(nameof(ThemeColor), typeof(Color), typeof(ElementColorView), default(Color), propertyChanged: OnThemeColorPropertyChanged);

    public string Caption
    {
      get => (string)GetValue(CaptionProperty);
      set => SetValue(CaptionProperty, value);
    }

    public string ColorHex
    {
      get => (string)GetValue(ColorHexProperty);
      set => SetValue(ColorHexProperty, value);
    }

    public Color TextColor
    {
      get => (Color)GetValue(TextColorProperty);
      set => SetValue(TextColorProperty, value);
    }

    public Color ThemeColor
    {
      get => (Color)GetValue(ThemeColorProperty);
      set => SetValue(ThemeColorProperty, value);
    }

    public ElementColorView()
    {
      InitializeComponent();
    }

    private static void OnCaptionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<string>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.CaptionLabel.Text = propertyValue;
        });
    }

    private static void OnColorHexPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<string>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.ColorHexLabel.Text = propertyValue;
        });
    }

    private static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<Color>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.CaptionLabel.TextColor = propertyValue;
          view.ColorHexLabel.TextColor = propertyValue;
        });
    }

    private static void OnThemeColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
      SetProperty<Color>(bindable, newValue,
        (view, propertyValue) =>
        {
          view.BackgroundColor = propertyValue;

          // determine which of Black / White produces the best contrast
          var whiteContrast = ColorHelper.GetContrastRatio(Color.White, propertyValue);
          var blackContrast = ColorHelper.GetContrastRatio(propertyValue, Color.Black);

          view.TextColor = whiteContrast > blackContrast
            ? Color.White
            : Color.Black;
        });
    }

    private static void SetProperty<TPropertyType>(BindableObject bindable, object newValue, Action<ElementColorView, TPropertyType> propertyAssigner)
    {
      if (!(bindable is ElementColorView view) || !(newValue is TPropertyType propertyValue))
      {
        return;
      }

      propertyAssigner.Invoke(view, propertyValue);
    }
  }
}