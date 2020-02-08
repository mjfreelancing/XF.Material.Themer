using Xamarin.Forms;

namespace XF.Material.Themer.Models.Themes
{
  public class LightThemeColors : ThemeColorsBase
  {
    public override Color Primary { get; set; } = Color.FromHex("6200EE");
    public override Color PrimaryVariant { get; set; } = Color.FromHex("3700B3");
    public override Color Secondary { get; set; } = Color.FromHex("03DAC6");
    public override Color SecondaryVariant { get; set; } = Color.FromHex("018786");
    public override Color Background { get; set; } = Color.FromHex("FFFFFF");
    public override Color Surface { get; set; } = Color.FromHex("FFFFFF");
    public override Color Error { get; set; } = Color.FromHex("B00020");
    public override Color OnPrimary { get; set; } = Color.FromHex("FFFFFF");
    public override Color OnSecondary { get; set; } = Color.FromHex("000000");
    public override Color OnBackground { get; set; } = Color.FromHex("000000");
    public override Color OnSurface { get; set; } = Color.FromHex("000000");
    public override Color OnError { get; set; } = Color.FromHex("FFFFFF");
  }
}