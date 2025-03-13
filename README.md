# Quasimorph Update Workshop By Name and Browse Commands

![thumbnail icon](media/thumbnail.png)

# Important - This is only for the opt in beta version of the game!

This is a temporary version that supports the 0.8.6 beta, and not the current game's version.
The non beta version *must* be uninstalled.  
When the 0.8.6 becomes the main version, this mod will be deleted.
Note that the beta is expected to change many times before release.
As such, this mod may break on each beta release.

# Docs


Adds the following commands:

`mod_updateworkshopitem <name>`: Updates a mod by name instead of by id and path.
`mod_browse <name>`: Opens a browser to a mod by name.
`mod_browse <Steam ID>`: Opens a browser to a mod by Steam ID
`mod_browse -`: Opens a browser to the last mod that was updated with the `mod_updateworkshopitem` command.


Usage:

```
mod_updatebyname foo_mod
mod_browse foo_mod
mod_browse 3378744839
mod_browse -
```

Behind the scenes, the `mod_updateworkshopitem` command invokes the game's `mod_updateworkshopitem` command, passing in the parameters for the selected mod.
Always updates the thumbnail.

# Auto Complete
List all mods by unique name by entering the command name and tab.

Can auto complete a mod name by entering the command, space, part of a mod's name, then tab.

For example: `mod_updatebyname bi` and tab could auto complete to `mod_updatebyname foo_biz`.  

# Support
If you enjoy my mods and want to buy me a coffee, check out my [Ko-Fi](https://ko-fi.com/nbkredspy71915) page.
Thanks!

# Source Code
Source code is available on GitHub at https://github.com/NBKRedSpy/QM_UpdateWorkshopByName

# Change Log

## 1.2.0
* Version 0.8.6 compatibility.
* Added mb, mun aliases
* Add - argument for mod_browse

## 1.1.0
* Added browse by Steam ID.