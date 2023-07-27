using EpicLoot.Adventure;
using System.Collections.Generic;

namespace Digitalroot.Valheim.Bounties.Providers
{
  public class RRRMonsterBounties : AbstractBounties
  {
    /// <inheritdoc />
    public override bool IsDependenciesResolved => Main.Instance.SoftDependencies.RRRCore
                                                   && Main.Instance.SoftDependencies.RRRMonsters;

    public RRRMonsterBounties()
      : base(Common.Names.RRRMod.EnemyNames.AllNamesByBiome)
    {
    }

    #region Overrides of AbstractBounties

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.BlackForest;

      foreach (var bountyTargetConfig in base.GetBlackForestBounties())
      {
        bountyTargetConfig.RewardCoins = GetCoins(biome, 10);
        bountyTargetConfig.RewardIron = GetIron(biome, 1);
        yield return bountyTargetConfig;
      }
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mistlands;

      foreach (var bountyTargetConfig in base.GetMistlandsBounties())
      {
        bountyTargetConfig.RewardCoins = GetCoins(biome, 40);
        bountyTargetConfig.RewardIron = GetIron(biome, 2);
        bountyTargetConfig.RewardGold = GetGold(biome, 1);
        yield return bountyTargetConfig;
      }
    }

    #endregion
  }
}
