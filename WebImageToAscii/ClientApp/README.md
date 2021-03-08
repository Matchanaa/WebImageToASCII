# WebImageToASCII

A simple React app that takes a user uploaded .jpg, .png or .bmp image, posts it to a image converter API and responds with a ASCII converted image.

**Setup**
This app requires Node.js to run. You can install the latest version at https://nodejs.org/. Once installed, your development environment may automatically use package.json to install necesasry packages.
If this does not work, please open command prompt, navigate to the ClientApp folder contained in the project and run "nmp install".

This project was based upon my previous ASCIIGenerator project, found at https://github.com/MattLopl/ASCIIGenerator. While the API function has been added, I have temporarily removed .gif support, and hope to add this functionality down the line.

"ASCII characters are selected based on the relative luminances of a subset of the printable ASCII. Percentage 'Opacity' (for lack of a better term) was found by calculating the percentage of a character's 8x16 pixels space was taken up by the character's pixels. This 'Opacity', which ranged from 0% for space to 33.59% for @, was mapped proportionally to the full 0-255 range of luminance to get a relative luminance for each character. This allows for characters to be selected appropriately for their luminance, corrected for uneven differences in character luminances. (The difference in luminance between space and - is significantly greater than the difference between n and r, for example.)"
"The calculation for relative luminance, (0.375 * Red) + (0.5 * Green) + (0.125 * Blue) is an approximation of (0.2126 * R) + (0.7152 * G) + (0.0722 * B), a reflection of how much certain light colours are perceived by the eye."

                        OOOOMMMM&&&&&&&&&&&&MMMMOOOO                        
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

Date Created: 07/03/21 Last Updated: 07/03/21 Matt Kanumilli