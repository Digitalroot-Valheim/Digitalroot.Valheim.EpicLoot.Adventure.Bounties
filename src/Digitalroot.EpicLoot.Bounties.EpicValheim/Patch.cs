using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Reflection;

namespace Digitalroot.EpicLoot.Bounties.EpicValheim
{
  [UsedImplicitly]
  public class Patch
  {
    [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.CopyOtherDB))]
    public class PatchObjectDBCopyOtherDB
    {
      [UsedImplicitly]
      [HarmonyPostfix]
      [HarmonyBefore(Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Guid)]
      [HarmonyPriority(Priority.Normal)]
      // ReSharper disable once InconsistentNaming
      public static void Postfix([NotNull] ref ObjectDB __instance)
      {
        try
        {
          if (!IsObjectDBReady())
          {
            Main.Instance.Log.LogDebug($"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] ObjectDB not ready - skipping");
            return;
          }

          Main.Instance.OnObjectDBCopyOtherDB(ref __instance);
        }
        catch (Exception e)
        {
          Main.Instance.Log.LogError(e);
        }
      }
    }

    private static bool IsObjectDBReady()
    {
      return ObjectDB.instance != null && ObjectDB.instance.m_items.Count != 0 && ObjectDB.instance.GetItemPrefab("Amber") != null;
    }
  }
}
