using MGSC;
using System;
using System.Reflection;
using static MGSC.ConsoleDaemon;

namespace QM_UpdateWorkshopByName
{
    public static class Plugin
    {
        public static string ModAssemblyName => Assembly.GetExecutingAssembly().GetName().Name;

        public static State GameState;

        [Hook(ModHookType.BeforeBootstrap)]
        public static void BeforeBootstrap(IModContext context)
        {
            GameState = context.State;

            InjectCommand(typeof(ModUpdateByName), ModUpdateByName.CommandName);

            InjectCommand(typeof(ModBrowse), ModBrowse.CommandName);
            
        }

        public static void InjectCommand(Type commandType, string name)
        {

            ConsoleDaemon consoleDaemon = ConsoleDaemon.Instance;

            if (consoleDaemon == null) return;


            MethodInfo helpMethod = commandType.GetMethod("Help", BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Standard, new Type[2]
            {
                typeof(string),
                typeof(bool)
            }, null);

            MethodInfo fetchAutocompleteMethod = commandType.GetMethod("FetchAutocompleteOptions", BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Standard,
              new Type[2]
              {
                typeof(string),
                typeof(string[])
              }, null);

            if (helpMethod == null && fetchAutocompleteMethod == null) return;

            MethodInfo isAvailableMethod = commandType.GetMethod("IsAvailable", BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Standard, new Type[0], null);
            MethodInfo showInHelpAndAutocompleteMethod = commandType.GetMethod("ShowInHelpAndAutocomplete", BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Standard, new Type[0], null);

            consoleDaemon.Commands[name.ToLower()] = new CommandInterface(commandType, consoleDaemon.Resolve, helpMethod, fetchAutocompleteMethod,
                isAvailableMethod, showInHelpAndAutocompleteMethod);

            //Seems to always set this, even without alts.
            //Oddly does not do a ToLower
            consoleDaemon.AlternateCommandNames[name] = name;
        }

    }

}
