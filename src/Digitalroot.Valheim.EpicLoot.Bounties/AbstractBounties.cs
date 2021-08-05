using EpicLoot.Adventure;
using System;
using System.Collections.Generic;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public abstract class AbstractBounties
  {
    public bool IsDependenciesResolved { get; protected set; }

    protected virtual int GetCoins(Heightmap.Biome biome, uint add = 0)
    {
      int value = biome switch
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

      // ReSharper disable once RedundantAssignment
      return value += Convert.ToInt16(add);
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

      // ReSharper disable once RedundantAssignment
      return value += Convert.ToInt16(add);
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

      // ReSharper disable once RedundantAssignment
      return value += Convert.ToInt16(add);
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

    protected abstract IEnumerable<BountyTargetConfig> GetMeadowsBounties();
    protected abstract IEnumerable<BountyTargetConfig> GetBlackForestBounties();
    protected abstract IEnumerable<BountyTargetConfig> GetSwampBounties();
    protected abstract IEnumerable<BountyTargetConfig> GetMountainBounties();
    protected abstract IEnumerable<BountyTargetConfig> GetPlainsBounties();
    protected abstract IEnumerable<BountyTargetConfig> GetOceanBounties();
    protected abstract IEnumerable<BountyTargetConfig> GetMistlandsBounties();
    protected abstract IEnumerable<BountyTargetConfig> GetAshLandsBounties();
    protected abstract IEnumerable<BountyTargetConfig> GetDeepNorthBounties();
  }
}
