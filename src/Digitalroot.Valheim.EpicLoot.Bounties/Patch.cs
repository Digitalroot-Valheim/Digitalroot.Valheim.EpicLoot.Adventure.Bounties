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
    [HarmonyAfter(global::EpicLoot.EpicLoot.PluginId
      , "som.Bears"
      , "DYBAssets"
    )]
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    public class PatchZNetSceneAwake
    {
      [UsedImplicitly]
      [HarmonyPostfix]
      [HarmonyPriority(Priority.Normal)]
      // ReSharper disable once InconsistentNaming
      public static void Postfix([NotNull] ref ZNetScene __instance)
      {
        try
        {
          Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");

          if (!Common.Utils.IsZNetSceneReady())
          {
            Log.Debug(Main.Instance, $"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] ObjectDB not ready - skipping");
            return;
          }

          Main.Instance.OnPatchZNetSceneAwake(ref __instance);
        }
        catch (Exception e)
        {
          Log.Error(Main.Instance, e);
        }
      }
    }

    [HarmonyBefore("org.bepinex.plugins.foodstaminaregen")]
    [HarmonyAfter(global::EpicLoot.EpicLoot.PluginId
      , "som.Bears"
      , "DYBAssets"
    )]
    [HarmonyPatch(typeof(StoreGui), nameof(StoreGui.Show))]
    public class PatchStoreGuiShow
    {
      [UsedImplicitly]
      [HarmonyPostfix]
      [HarmonyPriority(Priority.Normal)]
      // ReSharper disable once InconsistentNaming
      public static void Postfix([NotNull] ref StoreGui __instance)
      {
        try
        {
          Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
          if (Common.Utils.IsDedicated) return;

          Main.Instance.OnStoreGuiShow(ref __instance);
        }
        catch (Exception e)
        {
          Log.Error(Main.Instance, e);
        }
      }
    }
  }
}
