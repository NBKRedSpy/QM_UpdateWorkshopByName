[h1]Quasimorph Update Workshop By Name and Browse Commands[/h1]


Adds the following commands:

[i]mod_updateworkshopitem[/i]: Updates a mod by name instead of by id and path.
[i]mod_browse[/i]: Opens a browser to a mod by name.

Usage:
[code]
mod_updatebyname foo_mod
mod_browse foo_mod
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
