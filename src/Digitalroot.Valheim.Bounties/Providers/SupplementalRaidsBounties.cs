namespace Digitalroot.Valheim.Bounties.Providers
{
  public class SupplementalRaidsBounties : AbstractBounties
  {
    #region Overrides of AbstractBounties

    /// <inheritdoc />
    public override bool IsDependenciesResolved => Main.Instance.SoftDependencies.SupplementalRaids;

    #endregion

    public SupplementalRaidsBounties()
      : base(Common.Names.SupplementalRaidsMod.EnemyNames.AllNamesByBiome
        , Common.Names.SupplementalRaidsMod.BossNames.AllNamesByBiome)
    {
    }
  }
}
