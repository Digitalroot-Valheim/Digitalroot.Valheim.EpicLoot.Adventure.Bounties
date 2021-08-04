using BepInEx;
using Digitalroot.Valheim.Common;
using Digitalroot.Valheim.Common.Names;
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
  [BepInDependency(DYBAssets, BepInDependency.DependencyFlags.SoftDependency)]
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

    #region Soft Dependencies

    private SoftDependencies _softDependencies;

    // ReSharper disable InconsistentNaming
    public const string DYBAssets = nameof(DYBAssets);
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
        AddBounties();
        PrintBounties();
      }
      catch (Exception e)
      {
        Log.Error(this, e);
      }
    }

    private void AddBounties()
    {
      if (global::EpicLoot.EpicLoot.IsAdventureModeEnabled())
      {
        Log.Debug(Instance, "Adding Bounties to EpicLoot");

        foreach (var biome in Enum.GetValues(typeof(Heightmap.Biome)).Cast<Heightmap.Biome>())
        {
          var bounties = GetBounties(biome);
          if (bounties != null)
          {
            Log.Debug(Instance, $"Adding {bounties.Count()} bounties for {biome}");
            Bounties.AddRange(GetBounties(biome));
          }
          else
          {
            Log.Debug(Instance, $"No bounties for {biome}");
          }
        }
      }
    }

    private static void ClearBounties()
    {
      Log.Debug(Instance, "Removing default bounties");
      Bounties.Clear();
    }

    private IEnumerable<BountyTargetConfig> GetBounties(Heightmap.Biome biome)
    {
      return biome switch
      {
        Heightmap.Biome.Meadows => GetMeadowsBounties()
        , Heightmap.Biome.BlackForest => GetBlackForestBounties()
        , Heightmap.Biome.Swamp => GetSwampBounties()
        , Heightmap.Biome.Mountain => GetMountainBounties()
        , Heightmap.Biome.Plains => GetPlainsBounties()
        , Heightmap.Biome.Ocean => GetOceanBounties()
        , Heightmap.Biome.AshLands => GetAshLandsBounties()
        , Heightmap.Biome.DeepNorth => GetDeepNorthBounties()
        , Heightmap.Biome.Mistlands => GetMistlandsBounties()
        , Heightmap.Biome.None => null
        , Heightmap.Biome.BiomesMax => null
        , _ => null
      };
    }

    private static int GetCoins(Heightmap.Biome biome, uint add = 0)
    {
      int value = biome switch
      {
        Heightmap.Biome.Meadows => 10
        , Heightmap.Biome.BlackForest => 15
        , Heightmap.Biome.Swamp => 20
        , Heightmap.Biome.Mountain => 30
        , Heightmap.Biome.Plains => 35
        , Heightmap.Biome.Ocean => 30
        , Heightmap.Biome.Mistlands => 40
        , Heightmap.Biome.DeepNorth => 50
        , Heightmap.Biome.AshLands => 60
        , Heightmap.Biome.None => 1
        , Heightmap.Biome.BiomesMax => 1
        , _ => 1
      };

      // ReSharper disable once RedundantAssignment
      return value += Convert.ToInt16(add);
    }

    private static int GetIron(Heightmap.Biome biome, uint add = 0)
    {
      var value = biome switch
      {
        Heightmap.Biome.Meadows => 1
        , Heightmap.Biome.BlackForest => 2
        , Heightmap.Biome.Swamp => 3
        , Heightmap.Biome.Mountain => 4
        , Heightmap.Biome.Plains => 5
        , Heightmap.Biome.Ocean => 4
        , Heightmap.Biome.Mistlands => 5
        , Heightmap.Biome.DeepNorth => 6
        , Heightmap.Biome.AshLands => 7
        , Heightmap.Biome.None => 0
        , Heightmap.Biome.BiomesMax => 0
        , _ => 0
      };

      // ReSharper disable once RedundantAssignment
      return value += Convert.ToInt16(add);
    }

    private static int GetGold(Heightmap.Biome biome, uint add = 0)
    {
      var value = biome switch
      {
        Heightmap.Biome.Ocean => 0
        , Heightmap.Biome.Meadows => 0
        , Heightmap.Biome.BlackForest => 0
        , Heightmap.Biome.Swamp => 0
        , Heightmap.Biome.Mountain => 0
        , Heightmap.Biome.Plains => 0
        , Heightmap.Biome.None => 0
        , Heightmap.Biome.AshLands => 0
        , Heightmap.Biome.DeepNorth => 0
        , Heightmap.Biome.Mistlands => 0
        , Heightmap.Biome.BiomesMax => 0
        , _ => 0
      };

      // ReSharper disable once RedundantAssignment
      return value += Convert.ToInt16(add);
    }

    #region Biome Bounties

    #region Meadows Bounties

    private static IEnumerable<BountyTargetConfig> GetMeadowsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Meadows;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Deer, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Boar, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Boar, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Neck, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Neck, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Greyling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Greyling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Boar, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Boar, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Neck, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Neck, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GreydwarfShaman, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Greyling, Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GreydwarfElite, Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 9), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.GreydwarfShaman, Count = 2}
          , new() {ID = EnemyNames.Greydwarf, Count = 4}
          , new() {ID = EnemyNames.Greyling, Count = 5},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = 0, RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.SkeletonPoison, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.SkeletonPoison, Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Skeleton, Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = 0, RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = 0, RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Lox, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome)
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 110), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 110), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Boar, Count = 5}, new() {ID = EnemyNames.Neck, Count = 5},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 150), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 5), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Boar, Count = 5}, new() {ID = EnemyNames.Neck, Count = 5}, new() {ID = BossNames.Eikthyr, Count = 2},
        }
      };
    }

    #endregion

    #region Black Forest Bounties

    private static IEnumerable<BountyTargetConfig> GetBlackForestBounties()
    {
      var biome = Heightmap.Biome.BlackForest;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Greydwarf, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Greydwarf, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GreydwarfShaman, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Skeleton, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GreydwarfElite, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 35), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GreydwarfShaman, Biome = biome, RewardCoins = GetCoins(biome, 25), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Greydwarf, Count = 3},
        }
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 165), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 185), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 205), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 205), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.TheElder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 235), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.TheElder, Count = 1}, new() {ID = BossNames.Eikthyr, Count = 1},
        }
      };
    }

    #endregion

    #region Swamp Bounties

    private static IEnumerable<BountyTargetConfig> GetSwampBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Swamp;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Blob, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Blob, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Blob, Count = 1}
          , new() {ID = EnemyNames.Skeleton, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Skeleton, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Skeleton, Count = 2}
          , new() {ID = EnemyNames.SkeletonPoison, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Ghost, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Draugr, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.DraugrRanged, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Draugr, Count = 1}
          , new() {ID = EnemyNames.DraugrRanged, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Leech, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = 0, RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Draugr, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Surtling, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Ghost, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Draugr, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.DraugrRanged, Count = 2}, new() {ID = EnemyNames.Draugr, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.DraugrRanged, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.DraugrRanged, Count = 1}, new() {ID = EnemyNames.Draugr, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Skeleton, Count = 5},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.SkeletonPoison, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Skeleton, Count = 5},
        }
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 160), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 120), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 180), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 190), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.DraugrElite, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 190), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.TheElder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 220), RewardIron = GetIron(biome, 8), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 1}
          , new() {ID = BossNames.TheElder, Count = 1},
        }
      };
    }

    #endregion

    #region Mountain

    private static IEnumerable<BountyTargetConfig> GetMountainBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mountain;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wolf, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wolf, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Drake, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Drake, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.DraugrRanged, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Skeleton, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Fenring, Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = 0, RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Fenring, Biome = biome, RewardCoins = GetCoins(biome, 70), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Wolf, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wolf, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Wolf, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.StoneGolem, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = 0, RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.StoneGolem, Biome = biome, RewardCoins = GetCoins(biome, 130), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.StoneGolem, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 110), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 180), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Drake, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.StoneGolem, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 220), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Drake, Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 220), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.DraugrRanged, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 210), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 250), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.TheElder, Count = 1},
        }
      };
    }

    #endregion

    #region Plains

    private static IEnumerable<BountyTargetConfig> GetPlainsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Plains;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Goblin, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Goblin, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Goblin, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Drake, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Lox, Biome = biome, RewardCoins = GetCoins(biome, 45), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.DraugrRanged, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Skeleton, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Deathsquito, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Deathsquito, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Deathsquito, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Deathsquito, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GoblinBrute, Biome = biome, RewardCoins = GetCoins(biome, 45), RewardIron = 0, RewardGold = GetGold(biome, 3)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GoblinBrute, Biome = biome, RewardCoins = GetCoins(biome, 85), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Goblin, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GoblinBrute, Biome = biome, RewardCoins = GetCoins(biome, 145), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Goblin, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GoblinShaman, Biome = biome, RewardCoins = GetCoins(biome, 165), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Goblin, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GoblinShaman, Biome = biome, RewardCoins = GetCoins(biome, 215), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.GoblinBrute, Count = 1}
          , new() {ID = EnemyNames.Goblin, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 180), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Drake, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 250), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.TheElder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 350), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 6), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Bonemass, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 350), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 6), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Moder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 300), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.TheElder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 320), RewardIron = GetIron(biome, 15), RewardGold = GetGold(biome, 5), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.TheElder, Count = 1}
          , new() {ID = BossNames.Eikthyr, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 500), RewardIron = GetIron(biome, 20), RewardGold = GetGold(biome, 6), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.TheElder, Count = 1}
          , new() {ID = BossNames.Moder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 500), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 3),
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 530), RewardIron = GetIron(biome, 12), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 600), RewardIron = GetIron(biome, 20), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.TheElder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 800), RewardIron = GetIron(biome, 30), RewardGold = GetGold(biome, 8), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Bonemass, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 800), RewardIron = GetIron(biome, 30), RewardGold = GetGold(biome, 8), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Moder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1000), RewardIron = GetIron(biome, 40), RewardGold = GetGold(biome, 10), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Moder, Count = 1}
          , new() {ID = BossNames.TheElder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1000), RewardIron = GetIron(biome, 40), RewardGold = GetGold(biome, 10), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Bonemass, Count = 1}
          , new() {ID = BossNames.TheElder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1200), RewardIron = GetIron(biome, 50), RewardGold = GetGold(biome, 12), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Moder, Count = 1}
          , new() {ID = BossNames.Bonemass, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1250), RewardIron = GetIron(biome, 60), RewardGold = GetGold(biome, 13), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Moder, Count = 1}
          , new() {ID = BossNames.Bonemass, Count = 1}
          , new() {ID = BossNames.Eikthyr, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1400), RewardIron = GetIron(biome, 70), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Moder, Count = 1}
          , new() {ID = BossNames.Bonemass, Count = 1}
          , new() {ID = BossNames.TheElder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Moder, Count = 1}
          , new() {ID = BossNames.Bonemass, Count = 1}
          , new() {ID = BossNames.TheElder, Count = 1}
          , new() {ID = BossNames.Eikthyr, Count = 1},
        }
      };
    }

    #endregion

    #region Ocean Bounties

    private IEnumerable<BountyTargetConfig> GetOceanBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Ocean;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Serpent, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1)
      };

      if (_softDependencies.MonsterLabZ)
      {
        yield return new BountyTargetConfig
        {
          TargetID = MonsterLabZBossNames.Kraken, Biome = biome, RewardCoins = GetCoins(biome, 3000), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 25)
        };
      }

      if (_softDependencies.RRRMonsters)
      {
        yield return new BountyTargetConfig
        {
          TargetID = RRRMonsterNames.StormHatchling, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1)
        };

        yield return new BountyTargetConfig
        {
          TargetID = RRRMonsterNames.DrownedSoul, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }
    }

    #endregion

    #region Mistlands

    private static IEnumerable<BountyTargetConfig> GetMistlandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mistlands;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Wraith, Count = 2}, new() {ID = EnemyNames.Skeleton, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Wraith, Count = 2}, new() {ID = EnemyNames.Skeleton, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Ghost, Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Ghost, Count = 2}, new() {ID = EnemyNames.Skeleton, Count = 2},
        }
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Eikthyr, Count = 5},
        }
      };
    }

    #endregion

    #region DeepNorth

    private static IEnumerable<BountyTargetConfig> GetDeepNorthBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.DeepNorth;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Troll, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Troll, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Troll, Count = 4},
        }
      };

      // Bosses

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = BossNames.Moder, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Troll, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.StoneGolem, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Drake, Count = 4},
        }
      };
    }

    #endregion

    #region AshLands

    private static IEnumerable<BountyTargetConfig> GetAshLandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.AshLands;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Skeleton, Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Surtling, Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Surtling, Count = 2}
          , new() {ID = EnemyNames.Wraith, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Surtling, Count = 2}
          , new() {ID = EnemyNames.Ghost, Count = 2},
        }
      };

      // Bosses

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Surtling, Count = 6},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.GoblinBrute, Count = 2}
          , new() {ID = EnemyNames.GoblinArcher, Count = 1}
          , new() {ID = EnemyNames.Goblin, Count = 2}
          , new() {ID = EnemyNames.GoblinShaman, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.GoblinArcher, Count = 2}
          , new() {ID = EnemyNames.Goblin, Count = 1}
          , new() {ID = EnemyNames.GoblinShaman, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.GoblinArcher, Count = 2}
          , new() {ID = EnemyNames.Goblin, Count = 2}
          , new() {ID = EnemyNames.GoblinShaman, Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.GoblinBrute, Count = 3}
          , new() {ID = EnemyNames.GoblinShaman, Count = 1},
        }
      };
    }

    #endregion

    #endregion

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
