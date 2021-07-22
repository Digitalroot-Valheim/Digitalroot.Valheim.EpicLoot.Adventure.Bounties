using Digitalroot.Valheim.Common;
using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Reflection;
using UnityEngine;

namespace Digitalroot.Valheim.PluginTemplate
{
  [UsedImplicitly]
  public class Patch
  {
    [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.Awake))]
    public class PatchObjectDBAwake
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

          Main.Instance.OnObjectDBAwake(ref __instance);
        }
        catch (Exception e)
        {
          Log.Error(e);
        }
      }
    }

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

    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    public static class PatchZNetSceneAwake
    {
      [UsedImplicitly]
      [HarmonyPostfix]
      [HarmonyPriority(Priority.Normal)]
      // ReSharper disable once InconsistentNaming
      public static void Postfix([NotNull] ref ZNetScene __instance)
      {
        try
        {
          Log.Trace($"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
          if (!Common.Utils.IsZNetSceneReady())
          {
            Log.Debug($"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] ZNetScene not ready - skipping");
            return;
          }

          Main.Instance.OnZNetSceneAwake(ref __instance);
        }
        catch (Exception e)
        {
          Log.Error(e);
        }
      }
    }

    [HarmonyPatch(typeof(ZNet), nameof(ZNet.Awake))]
    public static class PatchZNetAwake
    {
      [UsedImplicitly]
      [HarmonyPostfix]
      [HarmonyPriority(Priority.Normal)]
      // ReSharper disable once InconsistentNaming
      public static void Postfix([NotNull] ref ZNet __instance)
      {
        try
        {
          Log.Trace($"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
          if (!Common.Utils.IsZNetReady())
          {
            Log.Debug($"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] ZNet not ready - skipping");
            return;
          }

          Main.Instance.OnZNetAwake(ref __instance);
        }
        catch (Exception e)
        {
          Log.Error(e);
        }
      }
    }

    [HarmonyPatch(typeof(Game), nameof(Game.SpawnPlayer))]
    public static class PatchGame
    {
      [HarmonyPostfix]
      [HarmonyPriority(Priority.Normal)]
      [UsedImplicitly]
      // ReSharper disable once InconsistentNaming
      public static void PostfixLoad([NotNull] ref Game __instance, Vector3 spawnPoint)
      {
        try
        {
          Log.Trace($"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}({spawnPoint})");

          if (!Common.Utils.IsPlayerReady())
          {
            Log.Debug($"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] Player not ready - skipping");
            return;
          }

          Main.Instance.OnSpawnedPlayer(ref __instance, spawnPoint);
        }
        catch (Exception e)
        {
          Log.Error(e);
        }
      }
    }
  }
}
