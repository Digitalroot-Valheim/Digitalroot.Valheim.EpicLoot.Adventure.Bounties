using EpicLoot.Adventure;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Digitalroot.Valheim.Bounties.Providers
{
  public class DebugBounties : AbstractBounties
  {
    public override bool IsDependenciesResolved => true;

    protected override IEnumerable<BountyTargetConfig> FilterResults(IEnumerable<BountyTargetConfig> bountyTargetConfigs)
    {
      return null;
      // return new List<BountyTargetConfig>
      // {
      //   CreateBountyTargetConfig(Heightmap.Biome.Meadows, Common.Names.MonsterLabZMod.EnemyNames.GhostWarrior)
      //   , CreateBountyTargetConfig(Heightmap.Biome.BlackForest, Common.Names.MonsterLabZMod.EnemyNames.GhostWarrior)
      //   , CreateBountyTargetConfig(Heightmap.Biome.Swamp, Common.Names.MonsterLabZMod.EnemyNames.GhostWarrior)
      //   , CreateBountyTargetConfig(Heightmap.Biome.Mountain, Common.Names.MonsterLabZMod.EnemyNames.GhostWarrior)
      //   , CreateBountyTargetConfig(Heightmap.Biome.Plains, Common.Names.MonsterLabZMod.EnemyNames.GhostWarrior)
      //   , CreateBountyTargetConfig(Heightmap.Biome.Mistlands, Common.Names.MonsterLabZMod.EnemyNames.GhostWarrior)
      //   , CreateBountyTargetConfig(Heightmap.Biome.AshLands, Common.Names.MonsterLabZMod.EnemyNames.GhostWarrior)
      //   , CreateBountyTargetConfig(Heightmap.Biome.DeepNorth, Common.Names.MonsterLabZMod.EnemyNames.GhostWarrior)
      // };
    }

    [UsedImplicitly]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Xplit")]
    private BountyTargetConfig CreateBountyTargetConfig(Heightmap.Biome biome, string name)
    {
      return new BountyTargetConfig
      {
        Biome = biome
        , RewardCoins = 0
        , RewardGold = 0
        , RewardIron = 0
        , TargetID = name
      };
    }
  }
}
