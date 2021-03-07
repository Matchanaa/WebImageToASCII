using System.Drawing;

namespace WebImageToAscii.Services
{
  public class ResizeImage : IResizeImage
  {
    ///<inheritdoc/>
    public Bitmap Resize(Bitmap image)
    {
      int scale = image.Width / 150;
      if (scale <= 0) scale = 1;

      var resizedImage = new Bitmap(image, new Size(image.Width / scale, image.Height / scale));

      return resizedImage;
    }
  }
}
