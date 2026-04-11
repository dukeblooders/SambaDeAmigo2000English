
# English conversion for Samba de Amigo Version 2000

[![SAMBA DE AMIGO](http://img.youtube.com/vi/BrYIlFHXL88/0.jpg)](https://youtu.be/BrYIlFHXL88 "Click to watch the video!")  

First of all, this is not a translation, but a conversion. I don't speak Japanese and my English is passable, at best :D

Most of the text comes from the US/PAL version of Samba De Amigo or the Wii version.  
Some were adapted to fit the available space and there are probably mistakes.

If you notice anything incorrect, feel free to let me know and I'll see what I can do.

**All DLC songs are available in the Download section of the official website, which is integrated and accessible <ins>offline</ins> through the Internet menu.**


## How to patch the game?

Download Universal Dreamcast Patcher and the .dcp file. Run the program and follow the instructions.


## How to create a CDI to play on original hardware?

1. Patch your GDI (obviously).
2. Download GD-ROM Explorer, Lazyboot and ImgBurn, available in the **various** folder.
3. Open the GDI with GD-ROM Explorer and extract IP.bin and all files under SAMBA_V2K into Lazyboot's **data** folder.
4. Start **Lazyboot.cmd**, select **1** (Audio/Data) or **4** (Data/Data) if you have issues with 1. At **step 2**, enter **SAMBA_V2K**, then keep pressing Enter until the end.
5. Test your CDI with a Dreamcast emulator.
6. Burn the file with ImgBurn (or another software). A Readme.txt file is included in the archive.


## Fonts

This conversion uses the following fonts:
- **Comic Sans MS** for basic text
- **Chilada** for everything else (it's not the exact game font, but it's very close)


## SambAFSEditor

A custom .Net 8.0 application I developed for editing AFS files for Samba De Amigo, with Puyo Tools source code.  
It's a bit rough around the edges, but it gets the job done, and could probably be used with other games that share the same structure.

Each .pvm/.pvr file is automatically decompressed and displayed in a tree view and can be updated easily (file attributes are preserved to avoid issues).
Also includes an editor for Love Love keywords and a PVR converter supporting palettes (PVP or VQ).


## Tools and usage

A big thanks to the people who developed the following tools:
- flycast (Dreamcast emulator)
- GD-ROM Explorer (open GDI/CDI file and extract content)
- GDIBuilder (create a "track03.bin" file for GDI)
- CrystalTile2 (replace VMU logo in 1st_read.bin, Display:Tile, size:48x32, form:GBA 8pp)
- HxD and wxMEdit (hex editors, HxD includes a comparison tool, wxMEdit supports Shift-JIS encoding)
- VMUExplorer (edit VMU content, fix VMU CRC)
- And other scripts or tools I used


## Special credits

Puyo Tools, for compressing/decompressing files or creating/extracting archives:  
https://github.com/nickworonekin/puyotools

AltoRetrato for the very helpful documentation:  
https://github.com/AltoRetrato/samba-de-amigo-2k_modding

And the people who helped me (ateam, yzb and the others) here:<br>
https://www.dreamcast-talk.com/forum/viewtopic.php?t=18162
