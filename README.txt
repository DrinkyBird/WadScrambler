WadScrambler v1.0.0
   by NotTheActualSean

WadScrambler is a tool that mutilates your WAD file, by swapping around the data of lumps of similar type.
It works on any Doom WAD file (PK3s are not supported, (yet)).
This tool will IRRECOVERABLY damage any WAD file you use it on - so MAKE BACKUPS!

Some things to note:
* Requires .NET Framework 4.0. Probably works in Mono on Linux/macOS(I don't see why it wouldn't), 
  but it's untested.
* The "All graphics" option only works with source ports that do not expect an image to be in a
  specific format. It works fine in ZDoom and derivatives (e.g. GZDoom, Zandronum), but is likely
  to crash in "vanilla" ports (e.g. PrBoom)
* If a mod defines a custom skin via ZDoom's S_SKIN/Zandronum's SKININFO lump, this is likely to
  cause it to crash due to the sprites being mismatched. No workaround is available so far, unless
  you want to open up your scrambled WAD in Slade and fix the sprites yourself...
* I hacked this tool together in a few hours and it's possibly likely to miss things or break. I know
  it's definitely going miss some lumps that would fall under the "Misc graphics" category, but
  they're hard to detect anyway, so...
* Speaking of, Misc graphics option currently picks up:
  * Doom's standard fonts
  * Menu graphics
  * Viewport border
  * Some HUD lumps
  * A few other lumps

Source code is at https://github.com/csnxs/WadScrambler

May God have mercy on you and whatever unholy thing you create using this tool