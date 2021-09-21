using Digitalroot.Valheim.Common.Names.SupplementalRaidsMod;
using EpicLoot.Adventure;
using System.Collections.Generic;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public class SupplementalRaidsBounties : AbstractBounties
  {
    public SupplementalRaidsBounties()
    {
      IsDependenciesResolved = Main.Instance.SoftDependencies.SupplementalRaids;
    }

    #region Overrides of AbstractBounties

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMeadowsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Meadows;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.BlackForest;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetSwampBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Swamp;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMountainBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mountain;
      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Plains;
      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetOceanBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Ocean;
      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mistlands;
      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.AshLands;
      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.DeepNorth;
      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target,
          Biome = biome,
          RewardCoins = GetCoins(biome),
          RewardIron = GetIron(biome),
          RewardGold = GetGold(biome)
        };
      }
    }

    #endregion
  }
}
