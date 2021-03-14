using NUnit.Framework;
using System.Collections.Generic;
using WebImageToAscii.Services;

namespace WebImageToAsciiNUnitTesting
{
  public class ExtensionChecksTest
  {
    private ExtensionChecks extensionChecks;

    [SetUp]
    public void Setup()
    {
      extensionChecks = new ExtensionChecks();
    }

    [Test]
    public void IsImage_ValidExtension_ReturnsTrue()
    {
      //Arrange
      List<string> extensions = new List<string> {".jpg", ".jpeg", ".bmp", ".png" };
      bool result;

      //Act
      foreach (string extension in extensions)
      {
        result = extensionChecks.IsImage(extension);

        //Assert
        Assert.IsTrue(result);
      }
    }

    [Test]
    public void IsImage_InvalidExtension_ReturnsFalse()
    {
      //Arrange
      string invalidExtension = ".this is not a valid extension";
      bool result;

      //Act
      result = extensionChecks.IsImage(invalidExtension);

      //Assert
      Assert.IsFalse(result);
    }
  }
}