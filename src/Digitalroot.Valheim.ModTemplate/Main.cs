using BepInEx;
using Digitalroot.Valheim.Common;
using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Reflection;
using UnityEngine;

namespace Digitalroot.Valheim.PluginTemplate
{
  [BepInPlugin(Guid, Name, Version)]
  public class Main : BaseUnityPlugin
  {
    public const string Version = "1.0.0";
    public const string Name = "Digitalroot Plug-in Template";
    public const string Guid = "digitalroot.mods.PluginTemplate";
    public const string Namespace = nameof(PluginTemplate);
    private Harmony _harmony;
    public static Main Instance;

    public Main()
    {
      Instance = this;
    }

    [UsedImplicitly]
    private void Awake()
    {
      _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), Guid);
    }

    [UsedImplicitly]
    private void OnDestroy()
    {
      _harmony?.UnpatchSelf();
    }

    public void OnSpawnedPlayer(ref Game game, Vector3 spawnPoint)
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        Log.Error(e);
      }
    }

    public void OnZNetAwake(ref ZNet zNet)
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        Log.Error(e);
      }
    }

    public void OnZNetSceneAwake(ref ZNetScene zNetScene)
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        Log.Error(e);
      }
    }

    public void OnObjectDBCopyOtherDB(ref ObjectDB objectDB)
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        Log.Error(e);
      }
    }

    public void OnObjectDBAwake(ref ObjectDB objectDB)
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        Log.Error(e);
      }
    }
  }
}
