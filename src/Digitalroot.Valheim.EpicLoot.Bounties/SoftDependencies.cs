using System;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  public class SoftDependencies
  {
    public bool Bears { get; }
    public bool Friendlies { get; }
    public bool MonsterLabZ { get; }
    public bool Monsternomicon { get; }
    public bool RRRCore { get; }
    public bool RRRMonsters { get; }

    // ReSharper disable once IdentifierTypo
    public bool RRRNpcs { get; }
    public bool SpawnThat { get; }
    public bool SupplementalRaids { get; }

    public SoftDependencies()
    {
      Bears = Common.Utils.DoesPluginExist(Main.Bears);
      Friendlies = (ObjectDB.instance != null && ObjectDB.instance.m_items.Count != 0 && ObjectDB.instance.GetItemPrefab(Common.Names.FriendliesMod.PrefabNames.Ashe) != null);
      MonsterLabZ = Common.Utils.DoesPluginExist(Main.MonsterLabZ);
      Monsternomicon = (ObjectDB.instance != null && ObjectDB.instance.m_items.Count != 0 && ObjectDB.instance.GetItemPrefab(Common.Names.MonsternomiconMod.PrefabNames.AngryFrozenCorpse) != null);
      RRRCore = Common.Utils.DoesPluginExist(Main.RRRCore);
      RRRNpcs = Common.Utils.DoesPluginExist(Main.RRRNpcs);
      RRRMonsters = Common.Utils.DoesPluginExist(Main.RRRMonsters);
      SpawnThat = Common.Utils.DoesPluginExist(Main.SpawnThat);
      SupplementalRaids = (ObjectDB.instance != null && ObjectDB.instance.m_items.Count != 0 && ObjectDB.instance.GetItemPrefab(Common.Names.SupplementalRaidsMod.PrefabNames.EikthyrBoar) != null);
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
