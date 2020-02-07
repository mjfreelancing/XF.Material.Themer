using Xamarin.Forms;
using XF.Material.Themer.Helpers;

namespace XF.Material.Themer.Models
{
  public class EmphasisColor
  {
    public Color Color { get; }
    public Color HighEmphasisColor => ColorHelper.FromColorWithOpacity(Color, Constants.HighEmphasisOpacity);
    public Color MediumEmphasisColor => ColorHelper.FromColorWithOpacity(Color, Constants.MediumEmphasisOpacity);
    public Color DisabledEmphasisColor => ColorHelper.FromColorWithOpacity(Color, Constants.DisabledEmphasisOpacity);

    public EmphasisColor(Color color)
    {
      Color = color;
    }
  }
}