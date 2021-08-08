using Digitalroot.Valheim.Common.Names;
using EpicLoot.Adventure;
using System.Collections.Generic;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public class BearsBounties : AbstractBounties
  {
    public BearsBounties()
    {
      IsDependenciesResolved = Common.Utils.DoesPluginExist(Main.Bears);
    }

    #region Overrides of AbstractBounties

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMeadowsBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetSwampBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMountainBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mountain;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome, 1)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetOceanBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties() => null;

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.DeepNorth;

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };
    }

    #endregion
  }
}
