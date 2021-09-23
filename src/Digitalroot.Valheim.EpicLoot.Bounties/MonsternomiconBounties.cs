using EpicLoot.Adventure;
using System.Collections.Generic;
using System.Linq;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public class MonsternomiconBounties : AbstractBounties
  {
    /// <inheritdoc />
    public override bool IsDependenciesResolved => Main.Instance.SoftDependencies.Monsternomicon;

    public MonsternomiconBounties()
      : base(Common.Names.MonsternomiconMod.EnemyNames.AllNamesByBiome
        , Common.Names.MonsternomiconMod.BossNames.AllNamesByBiome)
    {
    }

    protected override IEnumerable<BountyTargetConfig> FilterResults(IEnumerable<BountyTargetConfig> bountyTargetConfigs)
    {
      return from target in bountyTargetConfigs
        where !target.TargetID.Equals(Common.Names.MonsternomiconMod.EnemyNames.AngrySpirit)
        where !target.TargetID.Equals(Common.Names.MonsternomiconMod.EnemyNames.CalmSpirit)
        select target;
    }
  }
}
