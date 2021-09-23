using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Reflection;

namespace Digitalroot.EpicLoot.Bounties.EpicValheim
{
  [UsedImplicitly]
  public class Patch
  {
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    public class PatchZNetSceneAwake
    {
      [UsedImplicitly]
      [HarmonyPostfix]
      [HarmonyBefore(Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Guid)]
      [HarmonyPriority(Priority.Normal)]
      // ReSharper disable once InconsistentNaming
      public static void Postfix([NotNull] ref ZNetScene __instance)
      {
        try
        {
          if (!IsZNetSceneReady())
          {
            Main.Instance.Log.LogDebug($"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] ObjectDB not ready - skipping");
            return;
          }

          Main.Instance.OnZNetSceneAwake(ref __instance);
        }
        catch (Exception e)
        {
          Main.Instance.Log.LogError(e);
        }
      }
    }
    
    private static bool IsZNetSceneReady()
    {
      return ZNetScene.instance != null && ZNetScene.instance.m_prefabs.Count != 0 && ZNetScene.instance.GetPrefab("Boar") != null;
    }
  }
}
