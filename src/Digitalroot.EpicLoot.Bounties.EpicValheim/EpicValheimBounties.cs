using Digitalroot.Valheim.Common.Names;
using Digitalroot.Valheim.EpicLoot.Adventure.Bounties;
using EpicLoot.Adventure;
using System;
using System.Collections.Generic;

namespace Digitalroot.EpicLoot.Bounties.EpicValheim
{
  /// <summary>
  /// This project is an example of how to use the
  /// Digitalroot.Valheim.EpicLoot.Adventure.Bounties
  /// framework to add additional bounties.
  /// </summary>
  public sealed class EpicValheimBounties : AbstractBounties
  {
    /// <summary>
    /// ctor
    /// </summary>
    public EpicValheimBounties()
    {
      // Check if Dependent mods are loaded. If there are no dependencies then set IsDependenciesResolved to true;
      // IsDependenciesResolved = true; // Uncomment if there are no dependencies. e.g. Adding more vanilla mobs bounties.
      IsDependenciesResolved = IsDependenciesResolved = Valheim.Common.Utils.DoesPluginExist(Valheim.EpicLoot.Adventure.Bounties.Main.RRRMonsters)
                                                        && Valheim.Common.Utils.DoesPluginExist(Valheim.EpicLoot.Adventure.Bounties.Main.CustomRaids)
                                                        && Valheim.Common.Utils.DoesPluginExist(Valheim.EpicLoot.Adventure.Bounties.Main.SpawnThat)
                                                        && Valheim.Common.Utils.DoesPluginExist(Valheim.EpicLoot.Adventure.Bounties.Main.RRRCore)
                                                        && Valheim.Common.Utils.DoesPluginExist(Valheim.EpicLoot.Adventure.Bounties.Main.RRRNpcs)
                                                        && Valheim.Common.Utils.DoesPluginExist(Valheim.EpicLoot.Adventure.Bounties.Main.RRRBetterRaids)
                                                        && Valheim.Common.Utils.DoesPluginExist(Valheim.EpicLoot.Adventure.Bounties.Main.MonsterLabZ)
        ;
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
        , Heightmap.Biome.AshLands => 1500
        , Heightmap.Biome.DeepNorth => 1250
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
        , Heightmap.Biome.Swamp => 0
        , Heightmap.Biome.Mountain => 1
        , Heightmap.Biome.Plains => 2
        , Heightmap.Biome.Ocean => 3
        , Heightmap.Biome.Mistlands => 3
        , Heightmap.Biome.AshLands => 5
        , Heightmap.Biome.DeepNorth => 4
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
        , Heightmap.Biome.Swamp => 1
        , Heightmap.Biome.Mountain => 2
        , Heightmap.Biome.Plains => 3
        , Heightmap.Biome.Ocean => 4
        , Heightmap.Biome.Mistlands => 4
        , Heightmap.Biome.AshLands => 6
        , Heightmap.Biome.DeepNorth => 5
        , _ => 0
      };

      return Convert.ToInt16(add) + value;
    }

    #region Overrides of AbstractBounties

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMeadowsBounties() => GetEpicValheimBounties(Heightmap.Biome.Meadows);

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetBlackForestBounties() => GetEpicValheimBounties(Heightmap.Biome.BlackForest);

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetSwampBounties() => GetEpicValheimBounties(Heightmap.Biome.Swamp);

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMountainBounties() => GetEpicValheimBounties(Heightmap.Biome.Mountain);

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetPlainsBounties() => GetEpicValheimBounties(Heightmap.Biome.Plains);

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetOceanBounties() => GetEpicValheimBounties(Heightmap.Biome.Ocean);

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetMistlandsBounties() => GetEpicValheimBounties(Heightmap.Biome.Mistlands);

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetAshLandsBounties() => GetEpicValheimBounties(Heightmap.Biome.AshLands);

    /// <inheritdoc />
    protected override IEnumerable<BountyTargetConfig> GetDeepNorthBounties() => GetEpicValheimBounties(Heightmap.Biome.DeepNorth);

    #endregion
    
    private IEnumerable<BountyTargetConfig> GetEpicValheimBounties(Heightmap.Biome biome)
    {
      foreach (var target in EnemyNames.AllNamesByBiome(biome))
      {
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

      foreach (var target in MonsterLabZMonsterNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in MonsterLabZBossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in RRRMonsterNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }

      foreach (var target in RRRMBossNames.AllNamesByBiome(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target, Biome = biome, RewardCoins = GetCoins(biome), RewardIron = GetIron(biome), RewardGold = GetGold(biome)
        };
      }
    }
  }
}
