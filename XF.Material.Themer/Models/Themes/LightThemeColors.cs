using Xamarin.Forms;

namespace XF.Material.Themer.Models.Themes
{
  public class LightThemeColors : ThemeColorsBase
  {
    public override Color Primary { get; set; } = CreateColor("6200EE");
    public override Color PrimaryVariant { get; set; } = CreateColor("3700B3");
    public override Color Secondary { get; set; } = CreateColor("03DAC6");
    public override Color SecondaryVariant { get; set; } = CreateColor("018786");
    public override Color Background { get; set; } = CreateColor("FFFFFF");
    public override Color Surface { get; set; } = CreateColor("FFFFFF");
    public override Color Error { get; set; } = CreateColor("B00020");
    public override Color OnPrimary { get; set; } = CreateColor("FFFFFF");
    public override Color OnSecondary { get; set; } = CreateColor("000000");
    public override Color OnBackground { get; set; } = CreateColor("000000");
    public override Color OnSurface { get; set; } = CreateColor("000000");
    public override Color OnError { get; set; } = CreateColor("FFFFFF");
  }
}