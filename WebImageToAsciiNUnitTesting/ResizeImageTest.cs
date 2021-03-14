using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using WebImageToAscii.Services;

namespace WebImageToAsciiNUnitTesting
{
  public class ResizeImageTest
  {
    private ResizeImage resizeImage;
    private readonly string testImagePath = @"Test Data\\TestOriginalImage.png";
    private readonly string expectedResizedPath = @"Test Data\\TestResizedImage.png";

    [SetUp]
    public void Setup()
    {
      resizeImage = new ResizeImage();
    }

    [Test]
    public void Resize_ResizesImage_ResizesCorrectly()
    {
      //Arrange
      Bitmap testImage = new Bitmap(testImagePath);
      Bitmap expectedResized = new Bitmap(expectedResizedPath);

      //Act
      Bitmap resizedOutput = resizeImage.Resize(testImage);

      //Assert
      Assert.AreEqual(resizedOutput.PhysicalDimension, expectedResized.PhysicalDimension);
    }
  }
}

