using MGSC;
using QM_UpdateWorkshopByName;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

[ConsoleCommand(new string[] { CommandName, "mb" })]
public class ModBrowse
{

    private static UserMods UserMods { get; set; }

    public const string CommandName = "mod_browse";

    public static string Help(string command, bool verbose)
    {
        return $"Opens a browser to the mod's Steam Workshop page.  Usage: {CommandName} <unique mod name>, <steam id>, or -. Dash uses the last mod updated by {ModUpdateByName.CommandName}. Supports auto complete.";
    }

    static ModBrowse()
    {
        UserMods = Plugin.GameState.Get<UserMods>();
    }

    public string Execute(string[] tokens)
    {
        string modName = tokens.Length == 0 ? "" : tokens[0].Trim();

        if (modName == "")
        {
            return $"Requires the unique mod name, Steam ID, or use '-' for the last updated mod using {ModUpdateByName.CommandName}";
        }

        ulong steamId;

        if (modName == "-")
        {
            if (ModUpdateByName.LastUpdatedSteamId == null)
            {
                return $"No mods have been updated using {ModUpdateByName.CommandName}";
            }

            steamId = ModUpdateByName.LastUpdatedSteamId.Value;
        }
        //Check for steam ID
        else if (!ulong.TryParse(modName, out steamId))
        {
            //Find the mod
            UserMod mod = UserMods.Values.FirstOrDefault(x => string.Compare(x.UniqueModName, modName, true) == 0);

            if (mod == null)
            {
                return $"Unable to find mod with the unique name of '{modName}'.";
            }

            steamId = mod.SteamItemId;
        }

        Process.Start($"https://steamcommunity.com/sharedfiles/filedetails/?id={steamId}");
        return "done";
    }

    public static List<string> FetchAutocompleteOptions(string command, string[] tokens)
    {
        var modsFilter = UserMods.Values.AsQueryable();

        string nameQuery = null;

        if (tokens.Length != 0 && !string.IsNullOrWhiteSpace(tokens[0]))
        {
            nameQuery = tokens[0].Trim();

            modsFilter = modsFilter.Where(x => x.UniqueModName
                .IndexOf(nameQuery, System.StringComparison.OrdinalIgnoreCase) != -1);
        }

        List<string> results = modsFilter
            .Select(x => $"{CommandName} {x.UniqueModName}")
            .ToList();

        return results;

    }

    public static bool IsAvailable()
    {
        return true;
    }

    public static bool ShowInHelpAndAutocomplete()
    {
        return true;
    }
}
