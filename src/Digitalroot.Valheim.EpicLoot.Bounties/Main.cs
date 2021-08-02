using BepInEx;
using Digitalroot.Valheim.Common;
using Digitalroot.Valheim.Common.Core.Enums;
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
  public class Main : BaseUnityPlugin, ITraceableLogging
  {
    public const string Version = "1.1.3";
    public const string Name = "Digitalroot EpicLoot Adventure Bounties";
    // ReSharper disable once MemberCanBePrivate.Global
    public const string Guid = "digitalroot.mods.epicloot.adventure.bounties";
    public const string Namespace = "Digitalroot.Valheim.EpicLoot." + nameof(Adventure.Bounties);
    private Harmony _harmony;
    public static Main Instance;
    private static List<BountyTargetConfig> Bounties => AdventureDataManager.Config.Bounties.Targets;

    public Main()
    {
#if DEBUG
      EnableTrace = true;
#else
      EnableTrace = false;
#endif
      Log.RegisterSource(this);
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

    public void OnObjectDBCopyOtherDB(ref ObjectDB objectDB)
    {
      try
      {
        Initialize();
        ClearBounties();
        AddBounties();
        PrintBounties();
      }
      catch (Exception e)
      {
        Log.Error(this, e);
      }
    }

    private static void Initialize()
    {
      GameObjectManager.Instance.Initialize();
    }

    private static void AddBounties()
    {
      if (global::EpicLoot.EpicLoot.IsAdventureModeEnabled())
      {
        Log.Debug(Instance, "Adding Bounties to EpicLoot");

        foreach (var biome in Enum.GetValues(typeof(Heightmap.Biome)).Cast<Heightmap.Biome>())
        {
          var bounties = GetBounties(biome);
          if (bounties != null)
          {
            Log.Debug(Instance,$"Adding {bounties.Count()} bounties for {biome}");
            Bounties.AddRange(GetBounties(biome));
          }
          else
          {
            Log.Debug(Instance,$"No bounties for {biome}");
          }
        }
      }
    }

    private static void ClearBounties()
    {
      Log.Debug(Instance, "Removing default bounties");
      Bounties.Clear();
    }

    private static IEnumerable<BountyTargetConfig> GetBounties(Heightmap.Biome biome)
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
        Heightmap.Biome.Ocean => 1
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
        TargetID = GameObjectManager.Get(Enemies.Deer), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Boar), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Boar), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Neck), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Neck), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Greyling), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Greyling), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Boar), Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Boar), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Neck), Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Neck), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GreydwarfShaman), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Greyling), Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GreydwarfElite), Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 9), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.GreydwarfShaman), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.Greydwarf), Count = 4}, new() {ID = GameObjectManager.Get(Enemies.Greyling), Count = 5},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = 0, RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.SkeletonPoison), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.SkeletonPoison), Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Troll), Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = 0, RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wraith), Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = 0, RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Lox), Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome)
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Eikthyr), Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Eikthyr), Biome = biome, RewardCoins = GetCoins(biome, 110), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Eikthyr), Biome = biome, RewardCoins = GetCoins(biome, 110), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Boar), Count = 5}, new() {ID = GameObjectManager.Get(Enemies.Neck), Count = 5},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Eikthyr), Biome = biome, RewardCoins = GetCoins(biome, 150), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 5), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Boar), Count = 5}, new() {ID = GameObjectManager.Get(Enemies.Neck), Count = 5}, new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 2},
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
        TargetID = GameObjectManager.Get(Enemies.Greydwarf), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Greydwarf), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GreydwarfShaman), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GreydwarfElite), Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Troll), Biome = biome, RewardCoins = GetCoins(biome, 35), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GreydwarfShaman), Biome = biome, RewardCoins = GetCoins(biome, 25), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Greydwarf), Count = 3},
        }
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.TheElder), Biome = biome, RewardCoins = GetCoins(biome, 165), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.TheElder), Biome = biome, RewardCoins = GetCoins(biome, 185), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.TheElder), Biome = biome, RewardCoins = GetCoins(biome, 205), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.TheElder), Biome = biome, RewardCoins = GetCoins(biome, 205), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.TheElder), Biome = biome, RewardCoins = GetCoins(biome, 235), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 1},
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
        TargetID = GameObjectManager.Get(Enemies.Blob), Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Blob), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Blob), Count = 1}, new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.SkeletonPoison), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Ghost), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Draugr), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.DraugrRanged), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.BlobElite), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Draugr), Count = 1}, new() {ID = GameObjectManager.Get(Enemies.DraugrRanged), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Leech), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = 0, RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Draugr), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Surtling), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Surtling), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Surtling), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wraith), Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wraith), Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Ghost), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.DraugrElite), Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.DraugrElite), Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Draugr), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.DraugrElite), Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.DraugrRanged), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.Draugr), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.DraugrElite), Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.DraugrRanged), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.DraugrElite), Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.DraugrRanged), Count = 1}, new() {ID = GameObjectManager.Get(Enemies.Draugr), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 5},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.SkeletonPoison), Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 5},
        }
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 160), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Eikthyr), Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.TheElder), Biome = biome, RewardCoins = GetCoins(biome, 120), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 180), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 190), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.DraugrElite), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 190), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 220), RewardIron = GetIron(biome, 8), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
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
        TargetID = GameObjectManager.Get(Enemies.Wolf), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wolf), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Drake), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Drake), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Surtling), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.DraugrRanged), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Fenring), Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = 0, RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Fenring), Biome = biome, RewardCoins = GetCoins(biome, 70), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Wolf), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wolf), Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Wolf), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.StoneGolem), Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = 0, RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.StoneGolem), Biome = biome, RewardCoins = GetCoins(biome, 130), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.StoneGolem), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wraith), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wraith), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Eikthyr), Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.TheElder), Biome = biome, RewardCoins = GetCoins(biome, 110), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 180), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Drake), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.StoneGolem), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 220), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Drake), Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 220), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.DraugrRanged), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 210), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 250), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
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
        TargetID = GameObjectManager.Get(Enemies.Goblin), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Goblin), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Goblin), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Drake), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Lox), Biome = biome, RewardCoins = GetCoins(biome, 45), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Surtling), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.DraugrRanged), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Skeleton), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Deathsquito), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Deathsquito), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Deathsquito), Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Deathsquito), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GoblinBrute), Biome = biome, RewardCoins = GetCoins(biome, 45), RewardIron = 0, RewardGold = GetGold(biome, 3)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GoblinBrute), Biome = biome, RewardCoins = GetCoins(biome, 85), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Goblin), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GoblinBrute), Biome = biome, RewardCoins = GetCoins(biome, 145), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Goblin), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GoblinShaman), Biome = biome, RewardCoins = GetCoins(biome, 165), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Goblin), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.GoblinShaman), Biome = biome, RewardCoins = GetCoins(biome, 215), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.GoblinBrute), Count = 1}, new() {ID = GameObjectManager.Get(Enemies.Goblin), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wraith), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wraith), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Eikthyr), Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.TheElder), Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.TheElder), Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 180), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Drake), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 250), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 350), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 6), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Bonemass), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 350), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 6), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Moder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 300), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 320), RewardIron = GetIron(biome, 15), RewardGold = GetGold(biome, 5), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Bonemass), Biome = biome, RewardCoins = GetCoins(biome, 500), RewardIron = GetIron(biome, 20), RewardGold = GetGold(biome, 6), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.Moder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 500), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 3),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 530), RewardIron = GetIron(biome, 12), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 600), RewardIron = GetIron(biome, 20), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 800), RewardIron = GetIron(biome, 30), RewardGold = GetGold(biome, 8), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Bonemass), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 800), RewardIron = GetIron(biome, 30), RewardGold = GetGold(biome, 8), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Moder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 1000), RewardIron = GetIron(biome, 40), RewardGold = GetGold(biome, 10), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Moder), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 1000), RewardIron = GetIron(biome, 40), RewardGold = GetGold(biome, 10), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Bonemass), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 1200), RewardIron = GetIron(biome, 50), RewardGold = GetGold(biome, 12), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Moder), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.Bonemass), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 1250), RewardIron = GetIron(biome, 60), RewardGold = GetGold(biome, 13), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Moder), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.Bonemass), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 1400), RewardIron = GetIron(biome, 70), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Moder), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.Bonemass), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Moder), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.Bonemass), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.TheElder), Count = 1}, new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 1},
        }
      };
    }

    #endregion

    #region Ocean Bounties

    private static IEnumerable<BountyTargetConfig> GetOceanBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Ocean;

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Serpent), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };
    }

    #endregion

    #region Mistlands

    private static IEnumerable<BountyTargetConfig> GetMistlandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mistlands;

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Wraith), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Ghost), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Wraith), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wraith), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Ghost), Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Wraith), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Ghost), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 2},
        }
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Eikthyr), Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Eikthyr), Count = 5},
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
        TargetID = GameObjectManager.Get(Enemies.Troll), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Troll), Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Troll), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Troll), Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Troll), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Troll), Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Troll), Count = 4},
        }
      };

      // Bosses

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Bosses.Moder), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Troll), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.StoneGolem), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Moder), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Drake), Count = 4},
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
        TargetID = GameObjectManager.Get(Enemies.Surtling), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Skeleton), Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Surtling), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Surtling), Count = 3},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Surtling), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Surtling), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.Wraith), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Enemies.Surtling), Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Surtling), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.Ghost), Count = 2},
        }
      };

      // Bosses

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.Surtling), Count = 6},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.GoblinBrute), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.GoblinArcher), Count = 1}, new() {ID = GameObjectManager.Get(Enemies.Goblin), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.GoblinShaman), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.GoblinArcher), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.Goblin), Count = 1}, new() {ID = GameObjectManager.Get(Enemies.GoblinShaman), Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.GoblinArcher), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.Goblin), Count = 2}, new() {ID = GameObjectManager.Get(Enemies.GoblinShaman), Count = 1},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = GameObjectManager.Get(Bosses.Yagluth), Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = GameObjectManager.Get(Enemies.GoblinBrute), Count = 3}, new() {ID = GameObjectManager.Get(Enemies.GoblinShaman), Count = 1},
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
  }
}
