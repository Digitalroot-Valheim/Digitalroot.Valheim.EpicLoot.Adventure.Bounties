using EpicLoot.Adventure;
using System.Collections.Generic;
using System.Linq;

namespace Digitalroot.Valheim.Bounties.Providers
{
  public class MonsterLabZBounties : AbstractBounties
  {
    /// <inheritdoc />
    public override bool IsDependenciesResolved => Main.Instance.SoftDependencies.MonsterLabZ;

    public MonsterLabZBounties()
      : base(Common.Names.MonsterLabZMod.EnemyNames.AllNamesByBiome
        , Common.Names.MonsterLabZMod.BossNames.AllNamesByBiome)
    {
    }

    protected override IEnumerable<BountyTargetConfig> FilterResults(IEnumerable<BountyTargetConfig> bountyTargetConfigs)
    {
      return from target in bountyTargetConfigs
        where !target.TargetID.Equals(Common.Names.MonsterLabZMod.EnemyNames.RainbowButterfly)
        where !target.TargetID.Equals(Common.Names.MonsterLabZMod.EnemyNames.SilkwormButterfly)
        where !target.TargetID.Equals(Common.Names.MonsterLabZMod.EnemyNames.BlackSpider)
        where !target.TargetID.Equals(Common.Names.MonsterLabZMod.EnemyNames.GoblinBoat)
        where !target.TargetID.Equals(Common.Names.MonsterLabZMod.EnemyNames.GoblinShip2)
        select target;
    }
  }
}
