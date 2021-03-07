using System.Drawing;

namespace WebImageToAscii.Services
{
  /// <summary>
  /// Interface for the ImageConverter Service.
  /// </summary>
  public interface IImageConverter
  {
    /// <summary>
    /// Uses image size to iterate over each pixel, select an appropriate ASCII character, and add it to a mutable string.
    /// </summary>
    /// <param name="resizedImage"> The resized version of the original image. </param>
    /// <returns> Full ASCII image as a string. </returns>
    public string ReadPixels(Bitmap resizedImage);
  }
}