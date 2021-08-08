using BepInEx.Bootstrap;
using Digitalroot.Valheim.EpicLoot.Adventure.Bounties;
using EpicLoot.Adventure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Digitalroot.EpicLoot.Bounties.Example
{
  /// <summary>
  /// This project is an example of how to use the
  /// Digitalroot.Valheim.EpicLoot.Adventure.Bounties
  /// framework to add additional bounties.
  /// </summary>
  public class BearsBounties : AbstractBounties
  {
    /// <summary>
    /// ctor
    /// </summary>
    public BearsBounties()
    {
      // Check if Dependent mods are loaded. If there are no dependencies then set IsDependenciesResolved to true;
      // IsDependenciesResolved = true; // Uncomment if there are no dependencies. e.g. Adding more vanilla mobs bounties.
      IsDependenciesResolved = Chainloader.PluginInfos.Any(keyValuePair => keyValuePair.Value.Metadata.GUID == Main.DependencyName);
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
        Heightmap.Biome.Mountain => 0
        , Heightmap.Biome.DeepNorth => 2
        // ReSharper disable once BaseMethodCallWithDefaultParameter
        , _ => base.GetGold(biome)
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
        Heightmap.Biome.Meadows => 1
        , Heightmap.Biome.BlackForest => 2
        , Heightmap.Biome.Swamp => 3
        , Heightmap.Biome.Mountain => 4
        , Heightmap.Biome.Plains => 5
        , Heightmap.Biome.Ocean => 4
        , Heightmap.Biome.Mistlands => 5
        , Heightmap.Biome.AshLands => 6
        , Heightmap.Biome.DeepNorth => 7
        , Heightmap.Biome.None => 0
        , Heightmap.Biome.BiomesMax => 0
        , _ => 0
      };

      return Convert.ToInt16(add) + value;
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
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = 50, RewardIron = 4, RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = 50, RewardIron = 4, RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = 50, RewardIron = 4, RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = 40, RewardIron = 5, RewardGold = GetGold(biome)
      };

      yield return new BountyTargetConfig
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = 40, RewardIron = 4, RewardGold = GetGold(biome, 1)
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

      yield return new BountyTargetConfig // Bounty w/ multiple adds types.
      {
        // We want this bounty's RewardGold to be lower then the default of 2, so we skip calling GetGold() and just set it to 1.
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = 90, RewardIron = 7, RewardGold = 1, Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Bear, Count = 1}
          , new() {ID = EnemyNames.BearCub, Count = 4}
        }
      };

      yield return new BountyTargetConfig // Bounty w/ a single add type.
      {
        TargetID = EnemyNames.Bear, Biome = biome, RewardCoins = 80, RewardIron = 7, RewardGold = GetGold(biome), Adds = new List<BountyTargetAddConfig>
        {
          new() {ID = EnemyNames.Bear, Count = 3},
        }
      };
    }

    #endregion
  }

  /// <summary>
  /// Normally this should be in it's own file EnemyNames.cs
  /// </summary>
  public static class EnemyNames
  {
    public static readonly string Bear = nameof(Bear);
    public static readonly string BearCub = "Bear_cub";
  }
}
