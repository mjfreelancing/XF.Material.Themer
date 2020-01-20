using System.Collections.Generic;

namespace XF.Material.Themer.Models
{
  public class SurfaceItem
  {
    public string Title { get; set; }
    public IList<SurfaceCaption> SurfaceCaptions { get; set; }
  }
}