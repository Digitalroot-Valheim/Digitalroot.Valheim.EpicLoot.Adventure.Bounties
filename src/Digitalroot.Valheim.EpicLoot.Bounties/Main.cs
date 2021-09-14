using BepInEx;
using Common;
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
  [BepInDependency(Bears, BepInDependency.DependencyFlags.SoftDependency)]
  public class Main : BaseUnityPlugin, ITraceableLogging
  {
    public const string Version = "2.0.7";
    public const string Name = "Digitalroot EpicLoot Adventure Bounties";

    // ReSharper disable once MemberCanBePrivate.Global
    public const string Guid = "digitalroot.mods.epicloot.adventure.bounties";
    public const string Namespace = "Digitalroot.Valheim.EpicLoot." + nameof(Adventure.Bounties);
    private Harmony _harmony;
    public static Main Instance;
    private static List<BountyTargetConfig> Bounties => AdventureDataManager.Config.Bounties.Targets;
    // private static List<BountyTargetConfig> Bounties2 => global::EpicLoot.Adventure.MerchantPanel..Adventure.AdventureDataManager.Config.Bounties.Targets;

    private int _bountiesCount;
    private readonly List<AbstractBounties> _bountiesList = new();

    #region Soft Dependencies

    private SoftDependencies _softDependencies;

    // ReSharper disable InconsistentNaming
    public const string MonsterLabZ = "DYBAssets";
    public const string Bears = "som.Bears";
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
#if DEBUG
      EnableTrace = true;
      Log.RegisterSource(Instance);
#else
      EnableTrace = false;
#endif
      Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
    }

    [UsedImplicitly]
    private void Awake()
    {
      Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
      Config.Bind("General", "NexusID", 1401, "Nexus mod ID for updates");
      _softDependencies = new SoftDependencies();
      _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), Guid);
    }

    private void AddBounties()
    {
      Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
      if (!global::EpicLoot.EpicLoot.IsAdventureModeEnabled()) return;
      Log.Debug(Instance, "Adding Bounties to EpicLoot");
      Log.Trace(Instance, $"_bountiesList == null : {_bountiesList == null}");
      if (_bountiesList == null) return;
      Log.Trace(Instance, $"_bountiesList.Count : {_bountiesList.Count}");
      
      foreach (AbstractBounties bountiesCollection in _bountiesList)
      {
        Log.Trace(Instance, $"bountiesCollection.GetType().FullName : {bountiesCollection.GetType().FullName}");
        Log.Trace(Instance, $"bountiesCollection.IsDependenciesResolved : {bountiesCollection.IsDependenciesResolved}");
        // Log.Trace(Instance, bountiesCollection);
        if (!bountiesCollection.IsDependenciesResolved) continue;
        foreach (var biome in Enum.GetValues(typeof(Heightmap.Biome)).Cast<Heightmap.Biome>())
        {
          var bounties = bountiesCollection.GetBounties(biome)?.ToList();
          if (bounties == null) continue;
          Log.Debug(Instance, $"Adding {bounties?.Count} bounties for {biome}");
          Bounties.AddRange(bounties);
        }
      }

      _bountiesCount = Bounties.Count;
      Log.Debug(Instance, $"Loaded Bounties: {_bountiesCount}");
    }

    public void AddToBountiesCollection(AbstractBounties bounties)
    {
      Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
      if (_bountiesList.Any(bountiesItem => bountiesItem.GetType().Name == bounties.GetType().Name)) return;
      _bountiesList.Add(bounties);
    }

    private static void ClearBounties()
    {
      Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
      Log.Debug(Instance, $"Removing default bounties: {Bounties.Count}");
      Bounties.Clear();
      Log.Debug(Instance, $"Bounties should be cleared: {Bounties.Count}");
    }

    public void ConfigureBounties()
    {
      try
      {
        Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
        if (IsBountyListCurrent()) return;
        Log.Trace(Main.Instance, $"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] IsBountyListCurrent() : {IsBountyListCurrent()}");
        lock (Main.Instance)
        {
          if (IsBountyListCurrent()) return;
          Log.Trace(Main.Instance, $"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] IsBountyListCurrent() : {IsBountyListCurrent()}");
          ClearBounties();
          Log.Debug(Instance, _softDependencies.ToString());
          if (_isVanillaBountiesEnabled) AddToBountiesCollection(new VanillaBounties());
          Log.Trace(Instance, $"_isVanillaBountiesEnabled : {_isVanillaBountiesEnabled}");
          if (_isBearsBountiesEnabled) AddToBountiesCollection(new BearsBounties());
          Log.Trace(Instance, $"_isBearsBountiesEnabled : {_isBearsBountiesEnabled}");
          if (_isMonsterLabZBountiesEnabled) AddToBountiesCollection(new MonsterLabZBounties());
          Log.Trace(Instance, $"_isMonsterLabZBountiesEnabled : {_isMonsterLabZBountiesEnabled}");
          if (_isRRRMonsterBountiesEnabled) AddToBountiesCollection(new RRRMonsterBounties());
          Log.Trace(Instance, $"_isRRRMonsterBountiesEnabled : {_isRRRMonsterBountiesEnabled}");
          AddBounties();
          // PrintBounties();
        }
      }
      catch (Exception e)
      {
        Log.Error(Instance, e.Message);
        Log.Error(Instance, e);
      }
    }

    private bool IsBountyListCurrent()
    {
      Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
      Log.Trace(Main.Instance, $"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] _bountiesCount == 0 : {_bountiesCount == 0}");
      Log.Trace(Main.Instance, $"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] _bountiesCount != Bounties.Count : {_bountiesCount != Bounties.Count}");
      Log.Trace(Main.Instance, $"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] _bountiesCount : {_bountiesCount}");
      Log.Trace(Main.Instance, $"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] Bounties.Count : {Bounties.Count}");
      return _bountiesCount != 0 && _bountiesCount == Bounties.Count;
    }

    [UsedImplicitly]
    private void OnDestroy()
    {
      Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
      _harmony?.UnpatchSelf();
    }

    // ReSharper disable once UnusedParameter.Global
    public void OnObjectDBAwake(ref ObjectDB objectDB)
    {
      try
      {
        Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
        ConfigureBounties();
      }
      catch (Exception e)
      {
        Log.Error(Instance, e);
      }
    }

    public void OnObjectDBCopyOtherDB(ref ObjectDB objectDB)
    {
      try
      {
        Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
        ConfigureBounties();
      }
      catch (Exception e)
      {
        Log.Error(Instance, e);
      }
    }

    public void OnStoreGuiShow(ref StoreGui storeGui)
    {
      var merchantPanel = storeGui.transform.Find("MerchantPanel");
      if (merchantPanel == null)
      {
        Log.Debug(Main.Instance, $"[{MethodBase.GetCurrentMethod().DeclaringType?.Name}] MerchantPanel not ready - skipping");
        return;
      }
      var merchantPanelLoader = merchantPanel.gameObject.RequireComponent<MerchantPanelLoader>();
      merchantPanelLoader.MerchantPanelCmb = merchantPanel.GetComponent<MerchantPanel>();
    }

    #region Implementation of ITraceableLogging

    /// <inheritdoc />
    public string Source => Namespace;

    /// <inheritdoc />
    public bool EnableTrace { get; }

    #endregion

    #region Bounty Enablement

    private bool _isVanillaBountiesEnabled = true;
    private bool _isBearsBountiesEnabled = true;
    private bool _isMonsterLabZBountiesEnabled = true;
    private bool _isRRRMonsterBountiesEnabled = true;

    /// <summary>
    /// Disable the builtin Vanilla Bounties
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public void DisableVanillaBounties() => _isVanillaBountiesEnabled = false;

    /// <summary>
    /// Disable the builtin Bears bounties
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public void DisableBearsBounties() => _isBearsBountiesEnabled = false;

    /// <summary>
    /// Disable the builtin MonsterLabZ bounties
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public void DisableMonsterLabZBounties() => _isMonsterLabZBountiesEnabled = false;

    /// <summary>
    /// Disable the builtin RRRMonster bounties
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public void DisableRRRMonsterBounties() => _isRRRMonsterBountiesEnabled = false;

    /// <summary>
    /// Disable all the builtin bounties
    /// </summary>
    [UsedImplicitly]
    public void DisabledAllBuiltinBounties()
    {
      Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
      DisableBearsBounties();
      DisableMonsterLabZBounties();
      DisableVanillaBounties();
      DisableRRRMonsterBounties();
    }

    #endregion

    [Conditional("DEBUG")]
    private static void PrintBounties()
    {
       Log.Trace(Instance, $"Loaded Bounties: {Bounties.Count}");
      // Used for populating the ReadMe Table.
      Log.Trace(Instance, "*******************************");
      
      foreach (var biome in Enum.GetValues(typeof(Heightmap.Biome)).Cast<Heightmap.Biome>())
      {
        Log.Trace(Instance, $"## {biome}");
        Log.Trace(Instance, "<table>");
        Log.Trace(Instance, "<tr><th>TargetID</th><th>Iron</th><th>Gold</th><th>Coins</th><th>Adds</th></tr>");
      
        foreach (var bountyTargetConfig in Bounties.Where(b => b.Biome == biome))
        {
          Log.Trace(Instance, $"<tr><td>{bountyTargetConfig.TargetID}</td><td>{bountyTargetConfig.RewardIron}</td><td>{bountyTargetConfig.RewardGold}</td><td>{bountyTargetConfig.RewardCoins}</td><td>{(bountyTargetConfig.Adds.Count == 0 ? ":x:" : ":heavy_check_mark:")}</td></tr>");
        }
        Log.Trace(Instance, "</table>");
        Log.Trace(Instance, Environment.NewLine);
      }

      Log.Trace(Instance, "*******************************");

      foreach (var bountyTargetConfig in Bounties)
      {
        Log.Trace(Instance, $"TargetID: {bountyTargetConfig.TargetID}");
        Log.Trace(Instance, $"Biome: {bountyTargetConfig.Biome}");
        Log.Trace(Instance, $"RewardCoins: {bountyTargetConfig.RewardCoins}");
        Log.Trace(Instance, $"RewardIron: {bountyTargetConfig.RewardIron}");
        Log.Trace(Instance, $"RewardGold: {bountyTargetConfig.RewardGold}");
        Log.Trace(Instance, "[Adds]");
        Log.Trace(Instance, $"Adds.Count: {bountyTargetConfig.Adds.Count}");

        foreach (var bountyTargetAddConfig in bountyTargetConfig.Adds)
        {
          Log.Trace(Instance, $"Add.ID: {bountyTargetAddConfig.ID}");
          Log.Trace(Instance, $"Add.Count: {bountyTargetAddConfig.Count}");
        }

        Log.Trace(Instance, "*******************************");
      }
    }
  }
}
