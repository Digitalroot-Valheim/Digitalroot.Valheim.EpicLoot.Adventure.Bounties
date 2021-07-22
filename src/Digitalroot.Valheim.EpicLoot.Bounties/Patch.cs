using Digitalroot.Valheim.Common;
using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Reflection;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  [UsedImplicitly]
  public class Patch
  {
    [HarmonyBefore("org.bepinex.plugins.foodstaminaregen")]
    [HarmonyAfter(global::EpicLoot.EpicLoot.PluginId)]
    [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.CopyOtherDB))]
    public class PatchObjectDBCopyOtherDB
    {
      [UsedImplicitly]
      [HarmonyPostfix]
      [HarmonyPriority(Priority.Normal)]
      // ReSharper disable once InconsistentNaming
      public static void Postfix([NotNull] ref ObjectDB __instance)
      {
        try
        {
          Log.Trace($"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
          if (!Common.Utils.IsObjectDBReady())
          {
            Log.Debug($"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] ObjectDB not ready - skipping");
            return;
          }

          Main.Instance.OnObjectDBCopyOtherDB(ref __instance);
        }
        catch (Exception e)
        {
          Log.Error(e);
        }
      }
    }
  }
}
