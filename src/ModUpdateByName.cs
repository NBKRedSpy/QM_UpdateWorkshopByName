﻿using MGSC;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading;
using UnityEngine;

namespace QM_UpdateWorkshopByName
{
    [ConsoleCommand(new string[] { CommandName })]
    public class ModUpdateByName
    {

        private static UserMods UserMods { get; set; }

        public const string CommandName = "mod_updatebyname";

        public static string Help(string command, bool verbose)
        {
            return $"Updates a Steam Workshop mod by name.  Usage: {CommandName} <unique mod name>.  Supports auto complete.";
        }

        static ModUpdateByName()
        {
            UserMods = Plugin.GameState.Get<UserMods>();
        }

        public string Execute(string[] tokens)
        {
            string modName = tokens.Length == 0 ? "" : tokens[0].Trim();

            if (modName == "")
            {
                return "Requires the unique mod name to be provided";
            }

            //Find the mod
            UserMod mod = UserMods.Values.FirstOrDefault(x => string.Compare(x.UniqueModName, modName, true) == 0);

            if (mod == null)
            {
                return $"Unable to find mod with the unique name of '{modName}'.";
            }

            //Execute using the update workshop command
            ConsoleDaemon consoleDaemon = ConsoleDaemon.Instance;

            UpdateSteamWorkshopItemCommand workshopCommand = new UpdateSteamWorkshopItemCommand();

            return workshopCommand.Execute(new string[] {
                mod.SteamItemId.ToString(), mod.ContentPath, "true" });
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
}