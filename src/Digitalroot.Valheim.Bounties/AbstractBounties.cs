using Digitalroot.Valheim.Common;
using EpicLoot.Adventure;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Digitalroot.Valheim.Bounties
{
  public abstract class AbstractBounties
  {
    protected readonly Func<Heightmap.Biome, IEnumerable<string>> BossNames;
    protected readonly Func<Heightmap.Biome, IEnumerable<string>> EnemyNames;

    public virtual bool IsDependenciesResolved { get; protected set; }
    public bool IsLoaded { get; private set; }

    protected AbstractBounties()
    {
    }

    protected AbstractBounties(Func<Heightmap.Biome, IEnumerable<string>> enemyNames = null, Func<Heightmap.Biome, IEnumerable<string>> bossNames = null)
    {
      EnemyNames = enemyNames;
      BossNames = bossNames;
    }

    public void OnLoaded()
    {
      Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod()?.DeclaringType?.Name}.{MethodBase.GetCurrentMethod()?.Name}");
      IsLoaded = true;
    }

    protected virtual int GetCoins(Heightmap.Biome biome, uint add = 0)
    {
      var value = biome switch
      {
        Heightmap.Biome.Meadows => 10
        , Heightmap.Biome.BlackForest => 20
        , Heightmap.Biome.Swamp => 30
        , Heightmap.Biome.Mountain => 40
        , Heightmap.Biome.Plains => 50
        , Heightmap.Biome.Ocean => 30
        , Heightmap.Biome.Mistlands => 60
        , Heightmap.Biome.AshLands => 70
        , Heightmap.Biome.DeepNorth => 80
        , Heightmap.Biome.None => 1
        , Heightmap.Biome.BiomesMax => 1
        , _ => 1
      };

      return Convert.ToInt16(add) + value;
    }

    protected virtual int GetIron(Heightmap.Biome biome, uint add = 0)
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

    protected virtual int GetGold(Heightmap.Biome biome, uint add = 0)
    {
      var value = biome switch
      {
        Heightmap.Biome.Meadows => 0
        , Heightmap.Biome.BlackForest => 0
        , Heightmap.Biome.Swamp => 0
        , Heightmap.Biome.Mountain => 0
        , Heightmap.Biome.Plains => 1
        , Heightmap.Biome.Ocean => 0
        , Heightmap.Biome.Mistlands => 1
        , Heightmap.Biome.AshLands => 2
        , Heightmap.Biome.DeepNorth => 2
        , Heightmap.Biome.None => 0
        , Heightmap.Biome.BiomesMax => 0
        , _ => 0
      };

      return Convert.ToInt16(add) + value;
    }

    public IEnumerable<BountyTargetConfig> GetBounties(Heightmap.Biome biome)
    {
      return biome switch
      {
        Heightmap.Biome.Meadows => GetMeadowsBounties()
        , Heightmap.Biome.BlackForest => GetBlackForestBounties()
        , Heightmap.Biome.Swamp => GetSwampBounties()
        , Heightmap.Biome.Mountain => GetMountainBounties()
        , Heightmap.Biome.Plains => GetPlainsBounties()
        , Heightmap.Biome.Ocean => GetOceanBounties()
        , Heightmap.Biome.AshLands => GetAshLandsBounties()
        , Heightmap.Biome.DeepNorth => GetDeepNorthBounties()
        , Heightmap.Biome.Mistlands => GetMistlandsBounties()
        , Heightmap.Biome.None => null
        , Heightmap.Biome.BiomesMax => null
        , _ => null
      };
    }

    private IEnumerable<BountyTargetConfig> GetBountiesByBiome(Heightmap.Biome biome)
    {
      if (EnemyNames != null)
      {
        foreach (var target in EnemyNames(biome))
        {
          yield return new BountyTargetConfig
          {
            TargetID = target
            , Biome = biome
            , RewardCoins = GetCoins(biome)
            , RewardIron = GetIron(biome)
            , RewardGold = GetGold(biome)
          };
        }
      }

      if (BossNames == null) yield break;

      foreach (var target in BossNames(biome))
      {
        yield return new BountyTargetConfig
        {
          TargetID = target
          , Biome = biome
          , RewardCoins = GetCoins(biome)
          , RewardIron = GetIron(biome)
          , RewardGold = GetGold(biome)
        };
      }
    }

    /// <summary>
    /// Filter the bounty collection
    /// </summary>
    /// <param name="bountyTargetConfigs">Unfiltered bounty collection</param>
    /// <returns>Filtered bounty collection</returns>
    protected virtual IEnumerable<BountyTargetConfig> FilterResults(IEnumerable<BountyTargetConfig> bountyTargetConfigs) => bountyTargetConfigs;

    protected virtual IEnumerable<BountyTargetConfig> GetMeadowsBounties() => FilterResults(GetBountiesByBiome(Heightmap.Biome.Meadows));
    protected virtual IEnumerable<BountyTargetConfig> GetBlackForestBounties() => FilterResults(GetBountiesByBiome(Heightmap.Biome.BlackForest));
    protected virtual IEnumerable<BountyTargetConfig> GetSwampBounties() => FilterResults(GetBountiesByBiome(Heightmap.Biome.Swamp));
    protected virtual IEnumerable<BountyTargetConfig> GetMountainBounties() => FilterResults(GetBountiesByBiome(Heightmap.Biome.Mountain));
    protected virtual IEnumerable<BountyTargetConfig> GetPlainsBounties() => FilterResults(GetBountiesByBiome(Heightmap.Biome.Plains));
    protected virtual IEnumerable<BountyTargetConfig> GetOceanBounties() => FilterResults(GetBountiesByBiome(Heightmap.Biome.Ocean));
    protected virtual IEnumerable<BountyTargetConfig> GetMistlandsBounties() => FilterResults(GetBountiesByBiome(Heightmap.Biome.Mistlands));
    protected virtual IEnumerable<BountyTargetConfig> GetAshLandsBounties() => FilterResults(GetBountiesByBiome(Heightmap.Biome.AshLands));
    protected virtual IEnumerable<BountyTargetConfig> GetDeepNorthBounties() => FilterResults(GetBountiesByBiome(Heightmap.Biome.DeepNorth));
  }
}
