using Digitalroot.Valheim.Common.Names.FriendliesMod;
using System;

namespace Digitalroot.Valheim.Bounties
{
  public class SoftDependencies
  {
    public bool Bears { get; }
    public bool Friendlies => ZNetScene.instance != null && ZNetScene.instance.GetPrefab(PrefabNames.Ashe) != null;
    public bool MonsterLabZ { get; }
    public bool Monsternomicon => ZNetScene.instance.GetPrefab(Common.Names.MonsternomiconMod.PrefabNames.AngryFrozenCorpse) != null;
    public bool RRRCore { get; }
    public bool RRRMonsters { get; }

    // ReSharper disable once IdentifierTypo
    public bool RRRNpcs { get; }
    public bool SpawnThat { get; }
    public bool SupplementalRaids => ZNetScene.instance != null && ZNetScene.instance.GetPrefab(Common.Names.SupplementalRaidsMod.PrefabNames.EikthyrBoar) != null;

    public SoftDependencies()
    {
      Bears = Common.Utils.DoesPluginExist(Main.Bears);
      MonsterLabZ = Common.Utils.DoesPluginExist(Main.MonsterLabZ);
      RRRCore = Common.Utils.DoesPluginExist(Main.RRRCore);
      RRRNpcs = Common.Utils.DoesPluginExist(Main.RRRNpcs);
      RRRMonsters = Common.Utils.DoesPluginExist(Main.RRRMonsters);
      SpawnThat = Common.Utils.DoesPluginExist(Main.SpawnThat);
    }

    #region Overrides of Object

    /// <inheritdoc />
    public override string ToString() =>
      $"Soft Dependencies {Environment.NewLine}"
      + $"{nameof(Bears)} : {Bears}{Environment.NewLine}"
      + $"{nameof(Friendlies)} : {Friendlies}{Environment.NewLine}"
      + $"{nameof(MonsterLabZ)} : {MonsterLabZ}{Environment.NewLine}"
      + $"{nameof(Monsternomicon)} : {Monsternomicon}{Environment.NewLine}"
      + $"{nameof(RRRCore)} : {RRRCore}{Environment.NewLine}"
      + $"{nameof(RRRNpcs)} : {RRRNpcs}{Environment.NewLine}"
      + $"{nameof(RRRMonsters)} : {RRRMonsters}{Environment.NewLine}"
      + $"{nameof(SpawnThat)} : {SpawnThat}{Environment.NewLine}"
      + $"{nameof(SupplementalRaids)} : {SupplementalRaids}{Environment.NewLine}";

    #endregion
  }
}
