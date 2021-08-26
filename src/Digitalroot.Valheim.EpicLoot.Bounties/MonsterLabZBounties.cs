using Digitalroot.Valheim.Common.Names;
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

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.GhostWarrior, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.SkeletonWarrior, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.SkeletonWarriorFire, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.SkeletonWarriorIce, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.TanSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.ForestSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.GreydwarfPurpleShroom, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.GreydwarfPurple, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.Molluscan, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetSwampBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Swamp;

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.GreenSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.GreenSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMountainBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mountain;

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.IceGolem, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.SkeletonWarriorIce, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.FrostSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.FrigidSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.ObsidianGolem, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Plains;

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.GoblinBase, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.GoblinShamanNew, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.GoblinShamanNew, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = MonsterLabZMonsterNames.GoblinBase, Count = 2},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.GoblinShamanNew, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = MonsterLabZMonsterNames.GoblinLoot, Count = 4},
        }
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.BrownSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetOceanBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Ocean;

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZBossNames.Kraken, Biome = biome, RewardCoins = GetCoins(biome, 3000), RewardIron = GetIron(biome, 20), RewardGold = GetGold(biome, 25)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mistlands;

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.TreeSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.TreeSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZBossNames.SpiderBoss, Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 5)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.AshLands;

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.FireGolem, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.SkeletonWarriorFire, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.DeepNorth;

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.SkeletonWarriorIce, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = MonsterLabZMonsterNames.IceGolem, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };
    }

    #endregion
  }
}
