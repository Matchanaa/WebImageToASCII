using System.Drawing;

namespace WebImageToAscii.Services
{
  /// <summary>
  /// Interface for the ResizeImage service.
  /// </summary>
  public interface IResizeImage
  {
    /// <summary>
    /// Resizes image based on valid scalar, so the full image can be realistically displayed.
    /// </summary>
    /// <param name="image"> Original image file. </param>
    /// <returns> An image appropriately resized. </returns>
    public Bitmap Resize(Bitmap image);
  }
}