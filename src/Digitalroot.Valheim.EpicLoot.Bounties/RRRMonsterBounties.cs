using Digitalroot.Valheim.Common.Names.RRRMod;
using EpicLoot.Adventure;
using System.Collections.Generic;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public class RRRMonsterBounties : AbstractBounties
  {
    public RRRMonsterBounties()
    {
      IsDependenciesResolved = Common.Utils.DoesPluginExist(Main.RRRMonsters)
                               && Common.Utils.DoesPluginExist(Main.RRRCore)
        ;
    }

    #region Overrides of AbstractBounties

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMeadowsBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.BlackForest;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GDThornweaver, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.TrollTosser, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetSwampBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Swamp;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.GhostVengeful, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMountainBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetOceanBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mistlands;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Grig, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties() => null;

    #endregion
  }
}
