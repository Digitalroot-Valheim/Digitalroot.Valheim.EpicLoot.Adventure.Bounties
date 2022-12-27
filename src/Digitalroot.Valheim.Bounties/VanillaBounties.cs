using EpicLoot.Adventure;
using System.Collections.Generic;
using System.Linq;

namespace Digitalroot.Valheim.Bounties
{
  public class VanillaBounties : AbstractBounties
  {
    /// <inheritdoc />
    public override bool IsDependenciesResolved => true;

    public VanillaBounties()
      : base(Common.Names.Vanilla.EnemyNames.AllNamesByBiome
        , Common.Names.Vanilla.BossNames.AllNamesByBiome)
    {
    }

    #region Biome Bounties

    #region Meadows Bounties

    protected override IEnumerable<BountyTargetConfig> GetMeadowsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Meadows;

      foreach (var bountyTargetConfig in base.GetMeadowsBounties())
      {
        yield return bountyTargetConfig;
      }

      // Custom
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Deer, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Boar, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Boar, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Neck, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Neck, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Greyling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Greyling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Boar, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Boar, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Neck, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Neck, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GreydwarfShaman, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Greyling, Count = 4 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GreydwarfElite, Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 9), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.GreydwarfShaman, Count = 2 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.Greydwarf, Count = 4 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.Greyling, Count = 5 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = 0, RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.SkeletonPoison, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.SkeletonPoison, Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 4 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = 0, RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = 0, RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Lox, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome)
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 110), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 110), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Boar, Count = 5 }, new() { ID = Common.Names.Vanilla.EnemyNames.Neck, Count = 5 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 150), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 5), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Boar, Count = 5 }, new() { ID = Common.Names.Vanilla.EnemyNames.Neck, Count = 5 }, new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 2 },
        }
      };
    }

    #endregion

    #region Black Forest Bounties

    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties()
    {
      var biome = Heightmap.Biome.BlackForest;

      foreach (var bountyTargetConfig in base.GetBlackForestBounties())
      {
        yield return bountyTargetConfig;
      }

      // Custom
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Greydwarf, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Greydwarf, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GreydwarfShaman, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GreydwarfElite, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 35), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GreydwarfShaman, Biome = biome, RewardCoins = GetCoins(biome, 25), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Greydwarf, Count = 3 },
        }
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 165), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 185), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 205), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 205), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 235), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 }, new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 1 },
        }
      };
    }

    #endregion

    #region Swamp Bounties

    protected override IEnumerable<BountyTargetConfig> GetSwampBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Swamp;

      foreach (var bountyTargetConfig in base.GetSwampBounties())
      {
        yield return bountyTargetConfig;
      }

      // Custom
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Blob, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Blob, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Blob, Count = 1 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 2 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.SkeletonPoison, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Ghost, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Draugr, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.DraugrRanged, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.BlobElite, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Draugr, Count = 1 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.DraugrRanged, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Leech, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = 0, RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Draugr, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Surtling, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Ghost, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = 0, RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Draugr, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.DraugrRanged, Count = 2 }, new() { ID = Common.Names.Vanilla.EnemyNames.Draugr, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.DraugrRanged, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.DraugrElite, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.DraugrRanged, Count = 1 }, new() { ID = Common.Names.Vanilla.EnemyNames.Draugr, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 5 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.SkeletonPoison, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 5 },
        }
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 160), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 120), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 180), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 190), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.DraugrElite, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 190), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 220), RewardIron = GetIron(biome, 8), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };
    }

    #endregion

    #region Mountain

    protected override IEnumerable<BountyTargetConfig> GetMountainBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mountain;

      foreach (var bountyTargetConfig in base.GetMountainBounties())
      {
        yield return bountyTargetConfig;
      }

      // Custom
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wolf, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wolf, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Drake, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Drake, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.DraugrRanged, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Fenring, Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = 0, RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Fenring, Biome = biome, RewardCoins = GetCoins(biome, 70), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Wolf, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wolf, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Wolf, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.StoneGolem, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = 0, RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.StoneGolem, Biome = biome, RewardCoins = GetCoins(biome, 130), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.StoneGolem, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 110), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 180), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Drake, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.StoneGolem, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 220), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Drake, Count = 4 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 220), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.DraugrRanged, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 210), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 250), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };
    }

    #endregion

    #region Plains

    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Plains;

      foreach (var bountyTargetConfig in base.GetPlainsBounties())
      {
        yield return bountyTargetConfig;
      }

      // Custom
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Goblin, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Goblin, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Goblin, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Drake, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Lox, Biome = biome, RewardCoins = GetCoins(biome, 45), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.DraugrRanged, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Skeleton, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Deathsquito, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Deathsquito, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Deathsquito, Biome = biome, RewardCoins = GetCoins(biome, 15), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Deathsquito, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GoblinBrute, Biome = biome, RewardCoins = GetCoins(biome, 45), RewardIron = 0, RewardGold = GetGold(biome, 3)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GoblinBrute, Biome = biome, RewardCoins = GetCoins(biome, 85), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Goblin, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GoblinBrute, Biome = biome, RewardCoins = GetCoins(biome, 145), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Goblin, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GoblinShaman, Biome = biome, RewardCoins = GetCoins(biome, 165), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Goblin, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.GoblinShaman, Biome = biome, RewardCoins = GetCoins(biome, 215), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.GoblinBrute, Count = 1 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.Goblin, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 1),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.TheElder, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 180), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Drake, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 250), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 350), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 6), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Bonemass, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 350), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 6), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Moder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 300), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 320), RewardIron = GetIron(biome, 15), RewardGold = GetGold(biome, 5), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Bonemass, Biome = biome, RewardCoins = GetCoins(biome, 500), RewardIron = GetIron(biome, 20), RewardGold = GetGold(biome, 6), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.Moder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 500), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 3),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 530), RewardIron = GetIron(biome, 12), RewardGold = GetGold(biome, 3), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 600), RewardIron = GetIron(biome, 20), RewardGold = GetGold(biome, 4), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 800), RewardIron = GetIron(biome, 30), RewardGold = GetGold(biome, 8), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Bonemass, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 800), RewardIron = GetIron(biome, 30), RewardGold = GetGold(biome, 8), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Moder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1000), RewardIron = GetIron(biome, 40), RewardGold = GetGold(biome, 10), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Moder, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1000), RewardIron = GetIron(biome, 40), RewardGold = GetGold(biome, 10), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Bonemass, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1200), RewardIron = GetIron(biome, 50), RewardGold = GetGold(biome, 12), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Moder, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.Bonemass, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1250), RewardIron = GetIron(biome, 60), RewardGold = GetGold(biome, 13), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Moder, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.Bonemass, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 1400), RewardIron = GetIron(biome, 70), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Moder, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.Bonemass, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Moder, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.Bonemass, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.TheElder, Count = 1 }
          , new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 1 },
        }
      };
    }

    #endregion

    #region Ocean Bounties

    protected override IEnumerable<BountyTargetConfig> GetOceanBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Ocean;

      foreach (var bountyTargetConfig in base.GetOceanBounties())
      {
        yield return bountyTargetConfig;
      }

      // Custom
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Serpent, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1)
      };
    }

    #endregion

    #region Mistlands

    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mistlands;

      foreach (var bountyTargetConfig in base.GetMistlandsBounties())
      {
        yield return bountyTargetConfig;
      }

      // Custom
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Wraith, Count = 2 }, new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Ghost, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Wraith, Count = 2 }, new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Ghost, Count = 4 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Wraith, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Ghost, Count = 2 }, new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 2 },
        }
      };

      // Bosses
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Eikthyr, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Eikthyr, Count = 5 },
        }
      };
    }

    #endregion

    #region DeepNorth

    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.DeepNorth;

      foreach (var bountyTargetConfig in base.GetDeepNorthBounties())
      {
        yield return bountyTargetConfig;
      }

      // Custom
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome),
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Troll, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 1), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Troll, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Troll, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Troll, Count = 4 },
        }
      };

      // Bosses

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.BossNames.Moder, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Troll, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.StoneGolem, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Moder, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Drake, Count = 4 },
        }
      };
    }

    #endregion

    #region AshLands

    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.AshLands;

      foreach (var bountyTargetConfig in base.GetAshLandsBounties())
      {
        yield return bountyTargetConfig;
      }

      // Custom
      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Skeleton, Count = 4 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Surtling, Count = 3 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Surtling, Count = 2 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.Wraith, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.EnemyNames.Surtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Surtling, Count = 2 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.Ghost, Count = 2 },
        }
      };

      // Bosses

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.Surtling, Count = 6 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.GoblinBrute, Count = 2 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.GoblinArcher, Count = 1 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.Goblin, Count = 2 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.GoblinShaman, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.GoblinArcher, Count = 2 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.Goblin, Count = 1 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.GoblinShaman, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.GoblinArcher, Count = 2 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.Goblin, Count = 2 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.GoblinShaman, Count = 1 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.Vanilla.BossNames.Yagluth, Biome = biome, RewardCoins = GetCoins(biome, 2000), RewardIron = GetIron(biome, 75), RewardGold = GetGold(biome, 15), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = Common.Names.Vanilla.EnemyNames.GoblinBrute, Count = 3 }
          , new() { ID = Common.Names.Vanilla.EnemyNames.GoblinShaman, Count = 1 },
        }
      };
    }

    #endregion

    #endregion

    protected override IEnumerable<BountyTargetConfig> FilterResults(IEnumerable<BountyTargetConfig> bountyTargetConfigs)
    {
      return from target in bountyTargetConfigs
             where !target.TargetID.Equals(Common.Names.Vanilla.EnemyNames.BoarPiggy)
             where !target.TargetID.Equals(Common.Names.Vanilla.EnemyNames.Crow)
             where !target.TargetID.Equals(Common.Names.Vanilla.EnemyNames.Hare)
             where !target.TargetID.Equals(Common.Names.Vanilla.EnemyNames.LoxCalf)
             where !target.TargetID.Equals(Common.Names.Vanilla.EnemyNames.WolfCub)
             where !target.TargetID.Equals(Common.Names.Vanilla.EnemyNames.Hen)
             where !target.TargetID.Equals(Common.Names.Vanilla.EnemyNames.Seagal)
             select target;
    }

  }
}
