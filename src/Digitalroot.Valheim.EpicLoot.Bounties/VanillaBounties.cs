﻿using Digitalroot.Valheim.Common.Names.Vanilla;
using EpicLoot.Adventure;
using System.Collections.Generic;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public class VanillaBounties : AbstractBounties
  {
    public VanillaBounties()
    {
      IsDependenciesResolved = true;
    }

    #region Biome Bounties

    #region Meadows Bounties

    protected override IEnumerable<BountyTargetConfig> GetMeadowsBounties()
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

    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties()
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

    protected override IEnumerable<BountyTargetConfig> GetSwampBounties()
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

    protected override IEnumerable<BountyTargetConfig> GetMountainBounties()
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

    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties()
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

    protected override IEnumerable<BountyTargetConfig> GetOceanBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Ocean;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Serpent, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1)
      };
    }

    #endregion

    #region Mistlands

    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties()
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

    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties()
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

    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties()
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
  }
}
