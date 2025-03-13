using MGSC;
using System;
using System.Reflection;
using static MGSC.ConsoleDaemon;

namespace QM_UpdateWorkshopByName
{
    public static class Plugin
    {
        public static State GameState;

        [Hook(ModHookType.BeforeBootstrap)]
        public static void BeforeBootstrap(IModContext context)
        {
            GameState = context.State;
        }

    }

}
