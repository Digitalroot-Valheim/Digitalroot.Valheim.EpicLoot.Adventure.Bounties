﻿using Digitalroot.Valheim.Common.Names.MonsterLabZMod;
using EpicLoot.Adventure;
using System.Collections.Generic;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public class MonsterLabZBounties : AbstractBounties
  {
    public MonsterLabZBounties()
    {
      IsDependenciesResolved = Common.Utils.DoesPluginExist(Main.MonsterLabZ);
    }

    #region Overrides of AbstractBounties

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMeadowsBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.BlackForest;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        if (target.Equals(EnemyNames.RainbowButterfly)) continue; // ToDo: DRY
        if (target.Equals(EnemyNames.SilkwormButterfly)) continue;
        if (target.Equals(EnemyNames.BlackSpider)) continue;
        
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetSwampBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Swamp;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        if (target.Equals(EnemyNames.RainbowButterfly)) continue;
        if (target.Equals(EnemyNames.SilkwormButterfly)) continue;
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMountainBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mountain;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        if (target.Equals(EnemyNames.RainbowButterfly)) continue;
        if (target.Equals(EnemyNames.SilkwormButterfly)) continue;
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Plains;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        if (target.Equals(EnemyNames.RainbowButterfly)) continue;
        if (target.Equals(EnemyNames.SilkwormButterfly)) continue;
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GoblinShamanNew, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = EnemyNames.GoblinBase, Count = 2 },
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GoblinShamanNew, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() { ID = EnemyNames.GoblinLoot, Count = 4 },
        }
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetOceanBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Ocean;

      yield return new BountyTargetConfig
      {
        TargetID = BossNames.Kraken, Biome = biome, RewardCoins = GetCoins(biome, 3000), RewardIron = GetIron(biome, 20), RewardGold = GetGold(biome, 25)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mistlands;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        if (target.Equals(EnemyNames.RainbowButterfly)) continue;
        if (target.Equals(EnemyNames.SilkwormButterfly)) continue;
        if (target.Equals(EnemyNames.BlackSpider)) continue;
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 5)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.AshLands;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        if (target.Equals(EnemyNames.RainbowButterfly)) continue;
        if (target.Equals(EnemyNames.SilkwormButterfly)) continue;
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.DeepNorth;

      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
        if (target.Equals(EnemyNames.RainbowButterfly)) continue;
        if (target.Equals(EnemyNames.SilkwormButterfly)) continue;
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }
    }

    #endregion
  }
}
