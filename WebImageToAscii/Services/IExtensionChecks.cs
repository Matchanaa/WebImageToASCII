namespace WebImageToAscii.Services
{
  /// <summary>
  /// Interface for the ExtensionChecks Service
  /// </summary>
  public interface IExtensionChecks
  {
    /// <summary>
    /// Checks if the given image is a .jpg, .bmp or .png.
    /// </summary>
    /// <param name="imagePath"> File name of the image. </param>
    /// <returns> True if the extension is .jpg, .bmp or .png, false otherwise. </returns>
    public bool IsImage(string imagePath);
  }
}