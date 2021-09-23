using Digitalroot.Valheim.EpicLoot.Adventure.Bounties;
using EpicLoot.Adventure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Digitalroot.EpicLoot.Bounties.EpicValheim
{
  /// <summary>
  /// This project is an example of how to use the
  /// Digitalroot.Valheim.EpicLoot.Adventure.Bounties
  /// framework to add additional bounties.
  /// </summary>
  public sealed class EpicValheimBounties : AbstractBounties
  {
    /// <inheritdoc />
    /// Check if Dependent mods are loaded. If there are no dependencies then set IsDependenciesResolved to true;
    /// IsDependenciesResolved = true; // Uncomment if there are no dependencies. e.g. Adding more vanilla mobs bounties.
    public override bool IsDependenciesResolved => Valheim.EpicLoot.Adventure.Bounties.Main.Instance.SoftDependencies.Monsternomicon
                                                   && Valheim.EpicLoot.Adventure.Bounties.Main.Instance.SoftDependencies.MonsterLabZ
                                                   && Valheim.EpicLoot.Adventure.Bounties.Main.Instance.SoftDependencies.RRRCore
                                                   && Valheim.EpicLoot.Adventure.Bounties.Main.Instance.SoftDependencies.RRRMonsters
                                                   ;


    protected override IEnumerable<BountyTargetConfig> FilterResults(IEnumerable<BountyTargetConfig> bountyTargetConfigs)
    {
      return from target in bountyTargetConfigs
        where !target.TargetID.Equals(Valheim.Common.Names.MonsterLabZMod.EnemyNames.RainbowButterfly)
        where !target.TargetID.Equals(Valheim.Common.Names.MonsterLabZMod.EnemyNames.SilkwormButterfly)
        where !target.TargetID.Equals(Valheim.Common.Names.MonsterLabZMod.EnemyNames.BlackSpider)
        where !target.TargetID.Equals(Valheim.Common.Names.MonsterLabZMod.EnemyNames.GoblinBoat)
        where !target.TargetID.Equals(Valheim.Common.Names.MonsterLabZMod.EnemyNames.GoblinShip2)
        where !target.TargetID.Equals(Valheim.Common.Names.MonsternomiconMod.EnemyNames.AngrySpirit)
        where !target.TargetID.Equals(Valheim.Common.Names.MonsternomiconMod.EnemyNames.CalmSpirit)
             select target;
    }

    protected override int GetCoins(Heightmap.Biome biome, uint add = 0)
    {
      var value = biome switch
      {
        Heightmap.Biome.Meadows => 150
        , Heightmap.Biome.BlackForest => 300
        , Heightmap.Biome.Swamp => 450
        , Heightmap.Biome.Mountain => 600
        , Heightmap.Biome.Plains => 750
        , Heightmap.Biome.Ocean => 1000
        , Heightmap.Biome.Mistlands => 1000
        , Heightmap.Biome.DeepNorth => 1250
        , Heightmap.Biome.AshLands => 1500
        , _ => 0
      };

      return Convert.ToInt16(add) + value;
    }

    /// <summary>
    /// The values here are the same as the defaults.
    /// This example is here for an easy copy + paste
    /// of the full biome switch.
    /// </summary>
    /// <param name="biome"></param>
    /// <param name="add"></param>
    /// <returns></returns>
    protected override int GetIron(Heightmap.Biome biome, uint add = 0)
    {
      var value = biome switch
      {
        Heightmap.Biome.Meadows => 0
        , Heightmap.Biome.BlackForest => 0
        , Heightmap.Biome.Swamp => 1
        , Heightmap.Biome.Mountain => 2
        , Heightmap.Biome.Plains => 3
        , Heightmap.Biome.Ocean => 0
        , Heightmap.Biome.Mistlands => 0
        , Heightmap.Biome.DeepNorth => 0
        , Heightmap.Biome.AshLands => 0
        , _ => 0
      };

      return Convert.ToInt16(add) + value;
    }

    /// <summary>
    /// There are three methods, GetCoins, GetIron, and GetGold
    /// that can be used to get default values for each biome.
    /// This is helpful when working with a large quantity of
    /// bounties.
    ///
    /// If the default values of AbstractBounties do not work
    /// for the mods bounties. An override can be used to redefine
    /// the defaults at the mod level. 
    /// 
    /// </summary>
    /// <param name="biome">Biome to look up.</param>
    /// <param name="add">How much to add to the default value.</param>
    /// <returns></returns>
    protected override int GetGold(Heightmap.Biome biome, uint add = 0)
    {
      var value = biome switch
      {
        Heightmap.Biome.Meadows => 0
        , Heightmap.Biome.BlackForest => 0
        , Heightmap.Biome.Swamp => 0
        , Heightmap.Biome.Mountain => 0
        , Heightmap.Biome.Plains => 0
        , Heightmap.Biome.Ocean => 1
        , Heightmap.Biome.Mistlands => 1
        , Heightmap.Biome.DeepNorth => 2
        , Heightmap.Biome.AshLands => 3
        , _ => 0
      };

      return Convert.ToInt16(add) + value;
    }

    #region Overrides of AbstractBounties

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMeadowsBounties() => FilterResults(GetEpicValheimBounties(Heightmap.Biome.Meadows));

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties() => FilterResults(GetEpicValheimBounties(Heightmap.Biome.BlackForest));

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetSwampBounties() => FilterResults(GetEpicValheimBounties(Heightmap.Biome.Swamp));

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMountainBounties() => FilterResults(GetEpicValheimBounties(Heightmap.Biome.Mountain));

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties() => FilterResults(GetEpicValheimBounties(Heightmap.Biome.Plains));

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetOceanBounties() => FilterResults(GetEpicValheimBounties(Heightmap.Biome.Ocean));

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties() => FilterResults(GetEpicValheimBounties(Heightmap.Biome.Mistlands));

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties() => FilterResults(GetEpicValheimBounties(Heightmap.Biome.AshLands));

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties() => FilterResults(GetEpicValheimBounties(Heightmap.Biome.DeepNorth));

    #endregion

    private IEnumerable<BountyTargetConfig> GetEpicValheimBounties(Heightmap.Biome biome)
    {
      foreach (var target in Valheim.Common.Names.Vanilla.EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in Valheim.Common.Names.Vanilla.BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in Valheim.Common.Names.MonsterLabZMod.EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in Valheim.Common.Names.MonsterLabZMod.BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in Valheim.Common.Names.MonsternomiconMod.EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in Valheim.Common.Names.MonsternomiconMod.BossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in Valheim.Common.Names.RRRMod.EnemyNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }
    }
  }
}
