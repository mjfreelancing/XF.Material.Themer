using System.Collections.Generic;

namespace XF.Material.Themer.Models
{
  public class SurfaceCaptions
  {
    public string Title { get; }
    public IList<SurfaceCaption> Captions { get; }

    public SurfaceCaptions(string title, IList<SurfaceCaption> captions)
    {
      Title = title;
      Captions = captions;
    }
  }
}