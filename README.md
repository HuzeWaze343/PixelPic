# PixelPic
A simple nonogram puzzle game made in Unity.

This game was made as my end of year programming project for Level 6 Software Development.

The numbers in each row/column indicate how many tiles need to be filled in each row

  ex - a row marker that says "5" means the correct solution has: 5 connected tiles somewhere in the row
  
  ex - a column marker that says "1 3" means the correct solution has, in order from top to bottom: 1 filled tile, at least 1 tile of white space, 3 connected tiles
  
The toggle button at the bottom of each screen toggles flags. When the switch is toggled, clicking on a tile will flag the tile in red. This is to help the player mark off tiles where there is no chance the tile needs to be filled to complete the puzzle.
When the player fills the required amount of tiles the puzzle will try to validate by checking if the players solution matches the intended solution.

This game is intended for mobile devices in portrait mode (ex - 1080x2400 resolution). Many UI Elements will break if you attempt to run the game in wider resolutions or landscape mode.
