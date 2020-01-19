using Xamarin.Forms;

namespace XF.Material.Themer.Helpers
{
  public class EmphasisColor
  {
    public Color Color { get; }
    public Color HighEmphasisColor => ColorHelper.FromColorWithOpacity(Color, 0.87);
    public Color MediumEmphasisColor => ColorHelper.FromColorWithOpacity(Color, 0.60);
    public Color DisabledEmphasisColor => ColorHelper.FromColorWithOpacity(Color, 0.38);

    public EmphasisColor(Color color)
    {
      Color = color;
    }
  }
}