using EpicLoot.Adventure;
using System.Collections.Generic;

namespace Digitalroot.Valheim.Bounties
{
  public class BearsBounties : AbstractBounties
  {
    /// <inheritdoc />
    public override bool IsDependenciesResolved => Main.Instance.SoftDependencies.Bears;

    public BearsBounties()
      : base(Common.Names.BearsMod.EnemyNames.AllNamesByBiome)
    {
    }

    #region Overrides of AbstractBounties

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMountainBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mountain;

      for (var i = 0; i < 3; i++)
      {
        yield return new BountyTargetConfig
        {
          TargetID = Common.Names.BearsMod.EnemyNames.Bear
          , Biome = biome
          , RewardCoins = GetCoins(biome, 10)
          , RewardIron = GetIron(biome)
          , RewardGold = GetGold(biome)
        };
      }

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.BearsMod.EnemyNames.Bear
        , Biome = biome
        , RewardCoins = GetCoins(biome)
        , RewardIron = GetIron(biome, 1)
        , RewardGold = GetGold(biome)
        , Adds = new List<BountyTargetAddConfig>
        {
          new()
          {
            ID = Common.Names.BearsMod.EnemyNames.BearCub
            , Count = 2
          }
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.BearsMod.EnemyNames.Bear
        , Biome = biome
        , RewardCoins = GetCoins(biome)
        , RewardIron = GetIron(biome)
        , RewardGold = GetGold(biome, 1)
        , Adds = new List<BountyTargetAddConfig>
        {
          new()
          {
            ID = Common.Names.BearsMod.EnemyNames.Bear
            , Count = 1
          }
          , new()
          {
            ID = Common.Names.BearsMod.EnemyNames.BearCub
            , Count = 4
          }
        }
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.DeepNorth;

      for (var i = 0; i < 2; i++)
      {
        yield return new BountyTargetConfig
        {
          TargetID = Common.Names.BearsMod.EnemyNames.Bear
          , Biome = biome
          , RewardCoins = GetCoins(biome, 10)
          , RewardIron = GetIron(biome)
          , RewardGold = GetGold(biome)
        };
      }

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.BearsMod.EnemyNames.Bear
        , Biome = biome
        , RewardCoins = GetCoins(biome)
        , RewardIron = GetIron(biome, 1)
        , RewardGold = GetGold(biome)
        , Adds = new List<BountyTargetAddConfig>
        {
          new()
          {
            ID = Common.Names.BearsMod.EnemyNames.BearCub
            , Count = 2
          }
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = Common.Names.BearsMod.EnemyNames.Bear
        , Biome = biome
        , RewardCoins = GetCoins(biome)
        , RewardIron = GetIron(biome)
        , RewardGold = GetGold(biome, 1)
        , Adds = new List<BountyTargetAddConfig>
        {
          new()
          {
            ID = Common.Names.BearsMod.EnemyNames.Bear
            , Count = 1
          }
          , new()
          {
            ID = Common.Names.BearsMod.EnemyNames.BearCub
            , Count = 4
          }
        }
      };
    }

    #endregion
  }
}
