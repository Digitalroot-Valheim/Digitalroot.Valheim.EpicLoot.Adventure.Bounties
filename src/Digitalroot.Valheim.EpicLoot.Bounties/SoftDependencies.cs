using System;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public class SoftDependencies
  {

    public SoftDependencies()
    {
      MonsterLabZ = Common.Utils.DoesPluginExist(Main.MonsterLabZ);
      Bears = Common.Utils.DoesPluginExist(Main.Bears);
      CustomRaids = Common.Utils.DoesPluginExist(Main.CustomRaids);
      SpawnThat = Common.Utils.DoesPluginExist(Main.SpawnThat);
      RRRCore = Common.Utils.DoesPluginExist(Main.RRRCore);
      RRRNpcs = Common.Utils.DoesPluginExist(Main.RRRNpcs);
      RRRMonsters = Common.Utils.DoesPluginExist(Main.RRRMonsters);
      RRRBetterRaids = Common.Utils.DoesPluginExist(Main.RRRBetterRaids);
    }

    public bool MonsterLabZ { get; }
    public bool CustomRaids { get; }
    public bool SpawnThat { get; }
    public bool RRRCore { get; }
    public bool RRRNpcs { get; }
    public bool RRRMonsters { get; }
    public bool RRRBetterRaids { get; }
    // public bool Friendlies { get; }
    public bool Bears { get; }

    #region Overrides of Object

    /// <inheritdoc />
    public override string ToString()
    {
      return $"Soft Dependencies {Environment.NewLine}" +
             $"{nameof(MonsterLabZ)} : {MonsterLabZ}{Environment.NewLine}" +
             $"{nameof(CustomRaids)} : {CustomRaids}{Environment.NewLine}" +
             $"{nameof(SpawnThat)} : {SpawnThat}{Environment.NewLine}" +
             $"{nameof(RRRCore)} : {RRRCore}{Environment.NewLine}" +
             $"{nameof(RRRNpcs)} : {RRRNpcs}{Environment.NewLine}" +
             $"{nameof(RRRMonsters)} : {RRRMonsters}{Environment.NewLine}" +
             $"{nameof(RRRBetterRaids)} : {RRRBetterRaids}{Environment.NewLine}" +
//             $"{nameof(Friendlies)} : {Friendlies}{Environment.NewLine}" +
             $"{nameof(Bears)} : {Bears}{Environment.NewLine}";
    }

    #endregion
  }
}
