using HarmonyLib;
using System;
using Verse;

namespace Rimdark_MorePowerArmors
{
    [StaticConstructorOnStartup]
    internal static class Startup
    {
        static Startup()
        {
            LongEventHandler.ExecuteWhenFinished(() =>
            {
                Harmony harmony = new Harmony("rimdark.morepowerarmors");
                try
                {
                    harmony.PatchAll(typeof(Startup).Assembly);
                    Log.Message("[RMPA] PatchAll finished.");
                }
                catch (Exception exception)
                {
                    Log.Error("[RMPA] PatchAll failed: " + exception);
                }
            });
        }
    }
}
