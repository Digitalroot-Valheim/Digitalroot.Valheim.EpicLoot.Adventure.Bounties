﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JetBrains.Annotations;
using System;

namespace Digitalroot.EpicLoot.Bounties.Example
{
  [BepInPlugin(Guid, Name, Version)]
  [BepInDependency(Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Guid, "2.0.1")]
  [BepInDependency(DependencyName)]
  public class Main : BaseUnityPlugin
  {
    public const string Version = "1.0.0";
    public const string Name = "Digitalroot Valheim EpicLoot Adventure Bounties Sideload Example";

    // ReSharper disable MemberCanBePrivate.Global
    public const string Guid = "digitalroot.mods.epicloot.adventure.bounties.sideloadexample";

    public const string Namespace = "Digitalroot.EpicLoot.Bounties.Example";
    // ReSharper restore MemberCanBePrivate.Global

    private Harmony _harmony;
    public static Main Instance;
    public readonly ManualLogSource Log = BepInEx.Logging.Logger.CreateLogSource(Namespace);
    public const string DependencyName = "som.Bears";

    public Main()
    {
      try
      {
        Instance = this;
      }
      catch (Exception e)
      {
        Log.LogError(e);
      }
    }

    [UsedImplicitly]
    private void Awake()
    {
      try
      {
        _harmony = Harmony.CreateAndPatchAll(typeof(Main).Assembly, Guid);
      }
      catch (Exception e)
      {
        Log.LogError(e);
      }
    }

    [UsedImplicitly]
    private void OnDestroy()
    {
      try
      {
        _harmony?.UnpatchSelf();
      }
      catch (Exception e)
      {
        Log.LogError(e);
      }
    }

    public void OnObjectDBCopyOtherDB(ref ObjectDB objectDB)
    {
      try
      {
        Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.AddToBountiesCollection(new BearsBounties());
      }
      catch (Exception e)
      {
        Log.LogError(e);
      }
    }
  }
}
