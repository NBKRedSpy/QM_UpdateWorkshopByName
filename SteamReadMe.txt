[h1]Quasimorph Update Workshop By Name and Browse Commands[/h1]


[h1]Important - This is only for the opt in beta version of the game![/h1]

This is a temporary version that supports the 0.8.6 beta, and not the current game's version.
The non beta version [i]must[/i] be uninstalled.
When the 0.8.6 becomes the main version, this mod will be deleted.
Note that the beta is expected to change many times before release.
As such, this mod may break on each beta release.

[h1]Docs[/h1]

Adds the following commands:

[i]mod_updateworkshopitem <name>[/i]: Updates a mod by name instead of by id and path.
[i]mod_browse <name>[/i]: Opens a browser to a mod by name.
[i]mod_browse <Steam ID>[/i]: Opens a browser to a mod by Steam ID
[i]mod_browse -[/i]: Opens a browser to the last mod that was updated with the [i]mod_updateworkshopitem[/i] command.

Usage:
[code]
mod_updatebyname foo_mod
mod_browse foo_mod
mod_browse 3378744839
mod_browse -
[/code]

Behind the scenes, the [i]mod_updateworkshopitem[/i] command invokes the game's [i]mod_updateworkshopitem[/i] command, passing in the parameters for the selected mod.
Always updates the thumbnail.

[h1]Auto Complete[/h1]

List all mods by unique name by entering the command name and tab.

Can auto complete a mod name by entering the command, space, part of a mod's name, then tab.

For example: [i]mod_updatebyname bi[/i] and tab could auto complete to [i]mod_updatebyname foo_biz[/i].

[h1]Support[/h1]

If you enjoy my mods and want to buy me a coffee, check out my [url=https://ko-fi.com/nbkredspy71915]Ko-Fi[/url] page.
Thanks!

[h1]Source Code[/h1]

Source code is available on GitHub at https://github.com/NBKRedSpy/QM_UpdateWorkshopByName

[h1]Change Log[/h1]

[h2]1.2.0[/h2]
[list]
[*]Version 0.8.6 compatibility.
[*]Added mb, mun aliases
[*]Add - argument for mod_browse
[/list]

[h2]1.1.0[/h2]
[list]
[*]Added browse by Steam ID.
[/list]
