using Digitalroot.Valheim.Common.Names;
using EpicLoot.Adventure;
using System.Collections.Generic;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public class RRRMonsterBounties : AbstractBounties
  {
    public RRRMonsterBounties()
    {
      IsDependenciesResolved = Common.Utils.DoesPluginExist(Main.RRRMonsters)
                               && Common.Utils.DoesPluginExist(Main.CustomRaids)
                               && Common.Utils.DoesPluginExist(Main.SpawnThat)
                               && Common.Utils.DoesPluginExist(Main.RRRCore)
                               && Common.Utils.DoesPluginExist(Main.RRRNpcs)
                               && Common.Utils.DoesPluginExist(Main.RRRBetterRaids)
                               && Common.Utils.DoesPluginExist(Main.Friendlies);
    }

    #region Overrides of AbstractBounties

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMeadowsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Meadows;

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.EikthyrBoar, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.wildbandit1, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.wildbandit2, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.wildbandit3, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.EikthyrWolf, Biome = biome, RewardCoins = GetCoins(biome, 20), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.EikthyrNeckT3R, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.EikthyrLox, Biome = biome, RewardCoins = GetCoins(biome, 70), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 3)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.EikthyrNeckT3M, Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 8), RewardGold = GetGold(biome, 5)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.EikthyrNeckT4, Biome = biome, RewardCoins = GetCoins(biome, 130), RewardIron = GetIron(biome, 10), RewardGold = GetGold(biome, 6)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.BlackForest;

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.BlackSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.ForestSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.GhostWarrior, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SkeletonWarrior, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SkeletonWarriorFire, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SkeletonWarriorIce, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.TanSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.GDTosser, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.GDThornweaver, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.wildbanditgiant, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.wildbandit3, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.TrollT2Elite, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.GDElderBrute, Biome = biome, RewardCoins = GetCoins(biome, 65), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.GDBurningTorch, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.TrollT3Elite, Biome = biome, RewardCoins = GetCoins(biome, 70), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.TrollT4Elite, Biome = biome, RewardCoins = GetCoins(biome, 90), RewardIron = GetIron(biome, 8), RewardGold = GetGold(biome, 2)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetSwampBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Swamp;

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.GreenSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.GhostVengeful, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.UndeadHrungnir, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.SkeletonT3Captain, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.SkeletonT4Captain, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.WraithT3, Biome = biome, RewardCoins = GetCoins(biome, 10), RewardIron = GetIron(biome, 4), RewardGold = GetGold(biome, 2)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMountainBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mountain;

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.StormWolf, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.FrigidSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.FrostSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.IceGolem, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.mountainbandit1, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.mountainbandit2, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.mountainbandit3, Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.IceGolem, Biome = biome, RewardCoins = GetCoins(biome, 300), RewardIron = GetIron(biome, 7), RewardGold = GetGold(biome, 3)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Plains;

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.BrownSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.plainsbandit1, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.plainsbandit2, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.plainsbandit3, Biome = biome, RewardCoins = GetCoins(biome, 150), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetOceanBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Ocean;

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.StormHatchling, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome, 1), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.DrownedSoul, Biome = biome, RewardCoins = GetCoins(biome, 5), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SmallPolarSerpent, Biome = biome, RewardCoins = GetCoins(biome, 30), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 1)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.Mistlands;

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.DarkProtector, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.DarkSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.PoisonDarkSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.BlackSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = 0
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.TreeSpider, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.Svartalfr, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SvartalfrArcher, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SvartalfrMage, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SvartalfrHeavy, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SvartalfrBrigade, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.Grig, Biome = biome, RewardCoins = GetCoins(biome, 40), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 1)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.MotherDarkSpider, Biome = biome, RewardCoins = GetCoins(biome, 50), RewardIron = GetIron(biome, 3), RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.SvartalfrQueen, Biome = biome, RewardCoins = GetCoins(biome, 250), RewardIron = GetIron(biome, 9), RewardGold = GetGold(biome, 5)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.AshLands;

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.ElderSurtling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.AshHatchling, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.AshNeck, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.BurnedBones, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SwollenBody, Biome = biome, RewardCoins = GetCoins(biome, 70), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.FireGolem, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.BlazingBones, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.DamnedOne, Biome = biome, RewardCoins = GetCoins(biome, 60), RewardIron = GetIron(biome, 6), RewardGold = GetGold(biome, 2)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.BlazingDamnedOne, Biome = biome, RewardCoins = GetCoins(biome, 70), RewardIron = GetIron(biome, 8), RewardGold = GetGold(biome, 2)
      };
    }

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties()
    {
      const Heightmap.Biome biome = Heightmap.Biome.DeepNorth;

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.AngryFrozenCorpse, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.FrozenCorpse, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.PolarFenring, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.PolarLox, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMonsterNames.SilverGolem, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.DevourerFenring, Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 6)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.StormFenring, Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 6)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.ForgottenOne, Biome = biome, RewardCoins = GetCoins(biome, 100), RewardIron = GetIron(biome, 2), RewardGold = GetGold(biome, 6)
      };

      yield return new BountyTargetConfig
      {
        TargetID = RRRMBossNames.Jotunn, Biome = biome, RewardCoins = GetCoins(biome, 200), RewardIron = GetIron(biome, 5), RewardGold = GetGold(biome, 10)
      };
    }

    #endregion
  }
}
