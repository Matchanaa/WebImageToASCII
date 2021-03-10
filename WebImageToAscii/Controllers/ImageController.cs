using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WebImageToAscii.Services;

namespace WebImageToAscii.Controllers
{
  /// <summary>
  /// Image Handler.
  /// </summary>
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class ImageController : ControllerBase
  {
    private readonly IExtensionChecks _extensionChecks;
    private readonly IResizeImage _resizeImage;
    private readonly IImageConverter _imageConverter;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="extensionChecks"> Checks the extension of a loaded image. </param>
    /// <param name="resizeImage"> Resizes image based on valid scalar, so the full image can be realistically displayed. </param>
    /// <param name="imageConverter"> Iterates over each pixel in a frame and selects an ASCII character for each, 
    ///   concatenating each into a string. </param>
    public ImageController(IExtensionChecks extensionChecks, 
      IResizeImage resizeImage, IImageConverter imageConverter)
    {
      _extensionChecks = extensionChecks;
      _resizeImage = resizeImage;
      _imageConverter = imageConverter;
    }

    /// <summary>
    /// Converts the uploaded Image to ASCII.
    /// </summary>
    /// <param name="formData"> Key/Value pair of image byte array.</param>
    /// <returns> Generated ASCII as string. </returns>
    [HttpPost]
    [ActionName("UploadImage")]
    public async Task<ActionResult> UploadImage(IFormCollection formData)
    {
      if ((formData.Files == null)) 
       return NotFound("No Files Found On Request");
      
      //Checks whether the image is a supported extension using ExtensionChecks service.
      var file = formData.Files[0];
      if (!_extensionChecks.IsImage(file.FileName)) 
        return BadRequest("Unsupported file type");

      //Asynchronously adds the file to a memory stream.
      var imageStream = new MemoryStream();
      await file.CopyToAsync(imageStream);

      //Converts the file to a Bitmap object and resizes the image using the Resize Image Service. 
      Bitmap image;
      try
      {
        image = new Bitmap(imageStream);
      }
      catch (ArgumentException)
      {
        return BadRequest("Unsupported file type");
      }

      var resizedImage = _resizeImage.Resize(image);

      //Converts the resized image to ASCII using the ImageConverter service.
      var ascii = _imageConverter.ReadPixels(resizedImage);
            
      return Ok(ascii);
    }
  }
}
