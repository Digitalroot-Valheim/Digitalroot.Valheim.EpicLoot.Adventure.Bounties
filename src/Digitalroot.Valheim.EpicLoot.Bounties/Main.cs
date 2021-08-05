using BepInEx;
using Digitalroot.Valheim.Common;
using EpicLoot.Adventure;
using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  [BepInPlugin(Guid, Name, Version)]
  [BepInDependency(global::EpicLoot.EpicLoot.PluginId, "0.8.4")]
  [BepInDependency(MonsterLabZ, BepInDependency.DependencyFlags.SoftDependency)]
  [BepInDependency(CustomRaids, BepInDependency.DependencyFlags.SoftDependency)]
  [BepInDependency(SpawnThat, BepInDependency.DependencyFlags.SoftDependency)]
  [BepInDependency(RRRCore, BepInDependency.DependencyFlags.SoftDependency)]
  [BepInDependency(RRRNpcs, BepInDependency.DependencyFlags.SoftDependency)]
  [BepInDependency(RRRMonsters, BepInDependency.DependencyFlags.SoftDependency)]
  [BepInDependency(RRRBetterRaids, BepInDependency.DependencyFlags.SoftDependency)]
  [BepInDependency(Friendlies, BepInDependency.DependencyFlags.SoftDependency)]
  [BepInDependency(Bears, BepInDependency.DependencyFlags.SoftDependency)]
  public class Main : BaseUnityPlugin, ITraceableLogging
  {
    public const string Version = "2.0.0";
    public const string Name = "Digitalroot EpicLoot Adventure Bounties";

    // ReSharper disable once MemberCanBePrivate.Global
    public const string Guid = "digitalroot.mods.epicloot.adventure.bounties";
    public const string Namespace = "Digitalroot.Valheim.EpicLoot." + nameof(Adventure.Bounties);
    private Harmony _harmony;
    public static Main Instance;
    private static List<BountyTargetConfig> Bounties => AdventureDataManager.Config.Bounties.Targets;
    private readonly List<AbstractBounties> _bountiesList = new();

    #region Soft Dependencies

    private SoftDependencies _softDependencies;

    // ReSharper disable InconsistentNaming
    public const string MonsterLabZ = "DYBAssets";
    public const string Bears = "som.Bears";
    public const string Friendlies = "som.Friendlies";
    public const string CustomRaids = "asharppen.valheim.custom_raids";
    public const string SpawnThat = "asharppen.valheim.spawn_that";
    public const string RRRCore = "com.alexanderstrada.rrrcore";
    public const string RRRNpcs = "com.alexanderstrada.rrrnpcs";
    public const string RRRMonsters = "com.alexanderstrada.rrrmonsters";

    public const string RRRBetterRaids = "com.alexanderstrada.rrrbetterraids";
    // ReSharper restore InconsistentNaming

    #endregion

    public Main()
    {
      Instance = this;
      EnableTrace = true;
      Log.RegisterSource(this);
    }

    [UsedImplicitly]
    private void Awake()
    {
      _softDependencies = new SoftDependencies();
      _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), Guid);
    }

    [UsedImplicitly]
    private void OnDestroy()
    {
      _harmony?.UnpatchSelf();
    }

    public void OnObjectDBCopyOtherDB(ref ObjectDB objectDB)
    {
      try
      {
        ClearBounties();
        Log.Debug(this, _softDependencies.ToString());
        AddToBountiesCollection(new VanillaBounties());
        AddToBountiesCollection(new BearsBounties());
        AddToBountiesCollection(new MonsterLabZBounties());
        AddToBountiesCollection(new RRRMonsterBounties());
        AddBounties();
        PrintBounties();
      }
      catch (Exception e)
      {
        Log.Error(this, e);
      }
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public void AddToBountiesCollection(AbstractBounties bounties)
    {
      _bountiesList.Add(bounties);
    }

    private void AddBounties()
    {
      if (!global::EpicLoot.EpicLoot.IsAdventureModeEnabled()) return;
      Log.Debug(this, "Adding Bounties to EpicLoot");

      // Log.Trace(this, $"_bountiesList == null : {_bountiesList == null}");
      // Log.Trace(this, $"_bountiesList.Count : {_bountiesList?.Count}");

      foreach (var bountiesCollection in _bountiesList)
      {
        // Log.Trace(this, $"bountiesCollection.IsDependenciesResolved : {bountiesCollection.IsDependenciesResolved}");
        if (!bountiesCollection.IsDependenciesResolved) continue;
        foreach (var biome in Enum.GetValues(typeof(Heightmap.Biome)).Cast<Heightmap.Biome>())
        {
          var bounties = bountiesCollection.GetBounties(biome)?.ToList();
          Log.Debug(Instance, $"Adding {bounties?.Count} bounties for {biome}");
          if (bounties == null) continue;
          Bounties.AddRange(bounties);
        }
      }
    }

    private static void ClearBounties()
    {
      Log.Debug(Instance, "Removing default bounties");
      Bounties.Clear();
    }

    #region Implementation of ITraceableLogging

    /// <inheritdoc />
    public string Source => Namespace;

    /// <inheritdoc />
    public bool EnableTrace { get; }

    #endregion

    [Conditional("DEBUG")]
    private static void PrintBounties()
    {
      Log.Trace(Instance, $"Loaded Bounties: {Bounties.Count}");
      // Used for populating the ReadMe Table.
      // Log.Trace(Instance, "*******************************");
      //
      // foreach (var biome in Enum.GetValues(typeof(Heightmap.Biome)).Cast<Heightmap.Biome>())
      // {
      //   Log.Trace(Instance, $"## {biome}");
      //   Log.Trace(Instance, "<table>");
      //   Log.Trace(Instance, "<tr><th>TargetID</th><th>Iron</th><th>Gold</th><th>Coins</th><th>Adds</th></tr>");
      //
      //   foreach (var bountyTargetConfig in Bounties.Where(b => b.Biome == biome))
      //   {
      //     Log.Trace(Instance, $"<tr><td>{bountyTargetConfig.TargetID}</td><td>{bountyTargetConfig.RewardIron}</td><td>{bountyTargetConfig.RewardGold}</td><td>{bountyTargetConfig.RewardCoins}</td><td>{(bountyTargetConfig.Adds.Count == 0 ? ":x:" : ":heavy_check_mark:")}</td></tr>");
      //   }
      //   Log.Trace(Instance, "</table>");
      // }

      Log.Trace(Instance, "*******************************");

      //foreach (var bountyTargetConfig in Bounties)
      //{
      //  Log.Trace(Instance, $"TargetID: {bountyTargetConfig.TargetID}");
      //  Log.Trace(Instance, $"Biome: {bountyTargetConfig.Biome}");
      //  Log.Trace(Instance, $"RewardCoins: {bountyTargetConfig.RewardCoins}");
      //  Log.Trace(Instance, $"RewardIron: {bountyTargetConfig.RewardIron}");
      //  Log.Trace(Instance, $"RewardGold: {bountyTargetConfig.RewardGold}");
      //  Log.Trace(Instance, "[Adds]");
      //  Log.Trace(Instance, $"Adds.Count: {bountyTargetConfig.Adds.Count}");

      //  foreach (var bountyTargetAddConfig in bountyTargetConfig.Adds)
      //  {
      //    Log.Trace(Instance, $"Add.ID: {bountyTargetAddConfig.ID}");
      //    Log.Trace(Instance, $"Add.Count: {bountyTargetAddConfig.Count}");
      //  }

      //  Log.Trace(Instance, "*******************************");
      //}
    }
  }
}
