# ASCII Draw

ASCII Draw is a small console application that I am in the process of developing to work on my C# abilities. The goal of this project was to teach myself how to use classes and methods in my applications. The main development is the class library, with the ASCII drawing application simply being a demonstration of how the classes work.

## How It Works

This program works using a kind of "rendering engine". It works by making a 2D char array of a specified size and then printing it to the console. ASCII art can then be drawn onto this array which will print it on the screen.

## Classes

There are 4 classes that make this application work.

- Render()
- Draw()
- Menu()
- Character()

### Render()

Render is the base class that makes everything work. It initializes the viewport char array and then displays it.

### Draw()

Draw is one of the most important classes. This class provides different drawing methods to place things on the viewport. All of the other classes reference this one in some capacity. There are 7 methods within this class.

1. Single - draws a single character.
2. Sentence - draws a string horizontally on the viewport.
3. Line - draws a line from one point to another (needs work).
4. Rectangle - draws a rectangle from two specified corner points, of a specified fill character.
5. Box - a rectangle but with only a 1 character thick border.
6. Perpendicular Line - a line that is perpendicular with the viewport x or y axis.
7. Sprite - draws a char array to a char array. Useful if you have an ASCII logo or something that you want to draw to the viewport.

With these methods, one can construct most elements of an application.

### Menu()

Menu is a class that will dynamically create different ASCII menus to add user choice to the application.

#### Types
- Sprawl - creates a menu bar similar to the one present in operating systems like Windows.
- Dropdown - a dropdown menu, meant to be used with the sprawl, although can be used separately.
- Dialog - draws a popup dialogue box.

The GetInput() method allows the user to get user input for any of these menu options. It then returns a specified string for each option allowing the user to incorporate the logic.

### Character()

This method allows the user to add entities such as cursors or game characters. It contains methods to draw the character and also to get user input.


## Conclusion

These classes are less useful in the real world as there are much faster, more established, and better working options for those looking to make ASCII applications. Instead, this program is more of a learning experience.
