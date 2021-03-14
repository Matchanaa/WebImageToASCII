using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using WebImageToAscii.Services;
using System.Drawing;
using System.IO;
using System;

namespace WebImageToAsciiNUnitTesting
{
  public class ImageConverterTest
  {
    private WebImageToAscii.Services.ImageConverter imageConverter;
    private readonly string testImagePath = @"Test Data\TestConvertImage.png";
    private readonly string expected = @"                        OOOOMMMM&&&&&&&&&&&&MMMMOOOO                        
                        OOOOMMMM&&&&&&&&&&&&MMMMOOOO                        
                OOOOMMMM{{{{~~~~~~~~zzzz{{{{{{{{{{{{MMMMOOOO                
                OOOOMMMM{{{{~~~~~~~~zzzz{{{{{{{{{{{{MMMMOOOO                
            OOOO{{{{;;;;::::::::~~~~~~~~~~~~~~~~zzzzTTTT{{{{OOOO            
            OOOO{{{{;;;;::::::::~~~~~~~~~~~~~~~~zzzzTTTT{{{{OOOO            
        OOOO{{{{::::        ::::;;;;~~~~~~~~~~~~~~~~{{{{VVVV~~~~OOOO        
        OOOO{{{{::::        ::::;;;;~~~~~~~~~~~~~~~~{{{{VVVV~~~~OOOO        
        MMMM::::    ::::;;;;~~~~~~~~~~~~~~~~~~~~~~~~zzzzVVVV{{{{$$$$        
        MMMM::::    ::::;;;;~~~~~~~~~~~~~~~~~~~~~~~~zzzzVVVV{{{{$$$$        
    OOOO{{{{    ::::;;;;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~{{{{VVVV~~~~OOOO    
    OOOO{{{{    ::::;;;;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~{{{{VVVV~~~~OOOO    
    MMMM;;;;    ;;;;MMMM~~~~~~~~MMMM~~~~~~~~~~~~~~~~~~~~VVVVVVVV{{{{$$$$    
    MMMM;;;;    ;;;;MMMM~~~~~~~~MMMM~~~~~~~~~~~~~~~~~~~~VVVVVVVV{{{{$$$$    
OOOO{{{{::::::::~~~~MMMMzzzz~~~~MMMMzzzz~~~~~~~~~~~~{{{{VVVVVVVVVVVV::::OOOO
OOOO{{{{::::::::~~~~MMMMzzzz~~~~MMMMzzzz~~~~~~~~~~~~{{{{VVVVVVVVVVVV::::OOOO
OOOO{{{{~~~~::::~~~~MMMMzzzz~~~~MMMMzzzz~~~~~~~~{{{{VVVVVVVVVVVVVVVV~~~~MMMM
OOOO{{{{~~~~::::~~~~MMMMzzzz~~~~MMMMzzzz~~~~~~~~{{{{VVVVVVVVVVVVVVVV~~~~MMMM
MMMMVVVV{{{{~~~~~~~~~~~~~~~~~~~~~~~~zzzz{{{{{{{{VVVVVVVVVVVVVVVV{{{{::::MMMM
MMMMVVVV{{{{~~~~~~~~~~~~~~~~~~~~~~~~zzzz{{{{{{{{VVVVVVVVVVVVVVVV{{{{::::MMMM
OOOOVVVVVVVV{{{{{{{{{{{{{{{{{{{{{{{{{{{{VVVVVVVVVVVVVVVVVVVV{{{{{{{{....OOOO
OOOOVVVVVVVV{{{{{{{{{{{{{{{{{{{{{{{{{{{{VVVVVVVVVVVVVVVVVVVV{{{{{{{{....OOOO
MMMMMMMMVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV{{{{{{{{....MMMMMMMM
MMMMMMMMVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV{{{{{{{{....MMMMMMMM
    MMMMOOOOMMMMVVVVVVVVVVVVVVVVVVVVVVVVVVVV{{{{~~~~~~~~::::$$$$OOOOMMMM    
    MMMMOOOOMMMMVVVVVVVVVVVVVVVVVVVVVVVVVVVV{{{{~~~~~~~~::::$$$$OOOOMMMM    
            MMMMOOOOMMMMMMMM&&&&&&&&&&&&&&&&MMMMMMMMOOOOOOOOMMMM            
            MMMMOOOOMMMMMMMM&&&&&&&&&&&&&&&&MMMMMMMMOOOOOOOOMMMM            
";

    [SetUp]
    public void Setup()
    {
      imageConverter = new WebImageToAscii.Services.ImageConverter();
    }

    [Test]
    public void ReadPixels_ConvertImage_ConvertsCorrectly()
    {
      //Arrange
      Bitmap testImage = new Bitmap(testImagePath);

      //Act
      string result = imageConverter.ReadPixels(testImage);

      //Assert
      Assert.AreEqual(expected, result);
    }
  }
}