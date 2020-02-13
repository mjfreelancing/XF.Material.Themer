using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace XF.Material.Themer.Models.Themes
{
  public class CurrentTheme : BindableObject, IThemeColorsBase
  {
    public static readonly BindableProperty ThemeColorsProperty = BindableProperty.Create(nameof(ThemeColors), typeof(IThemeColorsBase), typeof(CurrentTheme),
      default(IThemeColorsBase), propertyChanged: OnThemeColorsChanged);

    public static readonly BindableProperty PrimaryProperty = BindableProperty.Create(nameof(Primary), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty PrimaryVariantProperty = BindableProperty.Create(nameof(PrimaryVariant), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty SecondaryProperty = BindableProperty.Create(nameof(Secondary), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty SecondaryVariantProperty = BindableProperty.Create(nameof(SecondaryVariant), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty BrandedBackgroundProperty = BindableProperty.Create(nameof(BrandedBackground), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty SurfaceProperty = BindableProperty.Create(nameof(Surface), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty BrandedSurfaceProperty = BindableProperty.Create(nameof(BrandedSurface), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty ErrorProperty = BindableProperty.Create(nameof(Error), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty OnPrimaryProperty = BindableProperty.Create(nameof(OnPrimary), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty OnSecondaryProperty = BindableProperty.Create(nameof(OnSecondary), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty OnBackgroundProperty = BindableProperty.Create(nameof(OnBackground), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty OnSurfaceProperty = BindableProperty.Create(nameof(OnSurface), typeof(Color), typeof(CurrentTheme), default(Color));
    public static readonly BindableProperty OnErrorProperty = BindableProperty.Create(nameof(OnError), typeof(Color), typeof(CurrentTheme), default(Color));

    public Color Primary
    {
      get => (Color)GetValue(PrimaryProperty);
      set => SetValue(PrimaryProperty, value);
    }

    public Color PrimaryVariant
    {
      get => (Color)GetValue(PrimaryVariantProperty);
      set => SetValue(PrimaryVariantProperty, value);
    }

    public Color Secondary
    {
      get => (Color)GetValue(SecondaryProperty);
      set => SetValue(SecondaryProperty, value);
    }

    public Color SecondaryVariant
    {
      get => (Color)GetValue(SecondaryVariantProperty);
      set => SetValue(SecondaryVariantProperty, value);
    }

    public Color Background
    {
      get => (Color)GetValue(BackgroundProperty);
      set => SetValue(BackgroundProperty, value);
    }

    public Color BrandedBackground
    {
      get => (Color)GetValue(BrandedBackgroundProperty);
      set => SetValue(BrandedBackgroundProperty, value);
    }

    public Color Surface
    {
      get => (Color)GetValue(SurfaceProperty);
      set => SetValue(SurfaceProperty, value);
    }

    public Color BrandedSurface
    {
      get => (Color)GetValue(BrandedSurfaceProperty);
      set => SetValue(BrandedSurfaceProperty, value);
    }

    public Color Error
    {
      get => (Color)GetValue(ErrorProperty);
      set => SetValue(ErrorProperty, value);
    }

    public Color OnPrimary
    {
      get => (Color)GetValue(OnPrimaryProperty);
      set => SetValue(OnPrimaryProperty, value);
    }

    public Color OnSecondary
    {
      get => (Color)GetValue(OnSecondaryProperty);
      set => SetValue(OnSecondaryProperty, value);
    }

    public Color OnBackground
    {
      get => (Color)GetValue(OnBackgroundProperty);
      set => SetValue(OnBackgroundProperty, value);
    }

    public Color OnSurface
    {
      get => (Color)GetValue(OnSurfaceProperty);
      set => SetValue(OnSurfaceProperty, value);
    }

    public Color OnError
    {
      get => (Color)GetValue(OnErrorProperty);
      set => SetValue(OnErrorProperty, value);
    }

    public Theme Theme { get; private set; }

    public static CurrentTheme Instance { get; } = new CurrentTheme();

    private CurrentTheme()
    {
    }

    public static void SetTheme(Theme theme, IThemeColorsBase themeColors)
    {
      Instance.Theme = theme;
      Instance.ThemeColors = themeColors;
    }

    public IThemeColorsBase ThemeColors
    {
      get => (IThemeColorsBase)GetValue(ThemeColorsProperty);
      set => SetValue(ThemeColorsProperty, value);
    }

    private static void OnThemeColorsChanged(BindableObject bindable, object oldValue, object newValue)
    {
      if (oldValue == newValue)
      {
        return;
      }

      if (!(newValue is IThemeColorsBase))
      {
        throw new ArgumentException("Cannot assign the current theme");
      }

      var themeColors = (IThemeColorsBase) newValue;
      Instance.SetCurrentTheme(themeColors);
    }

    private void SetCurrentTheme(IThemeColorsBase themeColors)
    {
      // set all values found on the IThemeColorsBase
      var sourceProperties = typeof(IThemeColorsBase).GetTypeInfo().DeclaredProperties;
      var destinationProperties = typeof(CurrentTheme).GetTypeInfo().DeclaredProperties.ToList();

      foreach (var property in sourceProperties)
      {
        var sourceValue = property.GetValue(themeColors);
        var destinationProperty = destinationProperties.Single(item => item.Name == property.Name);
        destinationProperty.SetValue(this, sourceValue);
      }

      // the above is more OCP, but will need to check if there are any performance concerns compared to the code below

      //Primary = themeColors.Primary;
      //PrimaryVariant = themeColors.PrimaryVariant;
      //Secondary = themeColors.Secondary;
      //SecondaryVariant = themeColors.SecondaryVariant;
      //Background = themeColors.Background;
      //BrandedBackground = themeColors.BrandedBackground;
      //Surface = themeColors.Surface;
      //BrandedSurface = themeColors.BrandedSurface;
      //Error = themeColors.Error;
      //OnPrimary = themeColors.OnPrimary;
      //OnSecondary = themeColors.OnSecondary;
      //OnBackground = themeColors.OnBackground;
      //OnSurface = themeColors.OnSurface;
      //OnError = themeColors.OnError;
    }
  }
}