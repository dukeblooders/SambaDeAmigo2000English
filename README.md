
# English conversion for Samba de Amigo Version 2000

First, this is not a translation, but a conversion. I don't speak japanese and my english is passable, at best :D

Most of the texts come from the US/PAL version of Samba de Amigo or the Wii version.  
Some have been adapted to fit the available space and there are probably mistakes.

Let me know if you see something incorrect and I'll see what I can do.


## How to patch the game ?

Download Universal Dreamcast Patcher and the .dcp file. Run the program and follow the instructions.


## Does the patched version work on original hardware ?

I haven't tested myself, but since it's just a texture and sound replacement with the same attributes, it should work.


## This Is Not the Text You Are Looking For

Technically, there is no text in this game, only images (at least for the big part).  
I did my best to reproduce those graphics with the same color palette Sega used.  
I'm not an artist, nor a photoshop expert, so expect some flaws in my textures.  
(but believe me, this game has its share of poor quality textures). 

## Known issues / Missing conversions

1. **Internet menu is not translated**  
The menu use a secondary 'application' with files to modify which are different from the base game.  
I'm not even sure it's usable in some way, so I won't work on it, but if someone wants to deal with it, (s)he's welcome.

2. **Love Love results are still in Japanese**  
This part uses matrixes (images with japanese characters).  
There is a matrix with an alphabet, but I have no idea how to change the text to use this matrix (probably in the 1ST_READ.BIN, but it's out of my league).
  
3. **The volleyball instructions voice was removed**   
Since I'm not using the text from the Wii version because I'm not sure the mini-games are the same, the voice was simply removed.


## Fonts

The game uses the following fonts (for the US/PAL version):
- **Comic Sans MS** for the basic texts
- **Chilada** for the rest (I didn't find the exact same font the game uses, but this one is really close)


## SambAFSEditor

A custom .Net 6.0 application I develop to edit the AFS files for Samba de Amigo with the help of the Puyo Tools source code.  
It's a bit wonky, but it gets the job done and could probably be used with other games which had the same structure.

Each .pvm/.pvr file is automatically decompressed and displayed in a tree view and can be easily updated (the attributes of the file are maintain to prevent issues).


## Credits

Puyo Tools, to compress/decompress files or create/extract archives:  
https://github.com/nickworonekin/puyotools

AltoRetrato for the very helpful documentation:  
https://github.com/AltoRetrato/samba-de-amigo-2k_modding

And other people of the different existing Dreamcast tools:  
GD-ROM Explorer, GDIbuilder, VMU Explorer, Universal Dreamcast Patcher, ...
