using System.IO;

namespace WebImageToAscii.Services
{
  /// <summary>
  /// Checks the extension of a loaded image.
  /// </summary>
  public class ExtensionChecks : IExtensionChecks
  {
    ///<inheritdoc/>
    public bool IsImage(string imagePath)
    {
      var ext = Path.GetExtension(imagePath).ToLower();
      return (ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".png");
    }
  }
}
