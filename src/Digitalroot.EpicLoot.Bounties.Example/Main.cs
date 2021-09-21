using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JetBrains.Annotations;
using System;

namespace Digitalroot.EpicLoot.Bounties.Example
{
  [BepInPlugin(Guid, Name, Version)]
  [BepInDependency(Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Guid, "2.1.0")]
  [BepInDependency(DependencyName)]
  public class Main : BaseUnityPlugin
  {
    public const string Version = "1.1.0";
    public const string Name = "Digitalroot Valheim EpicLoot Adventure Bounties Sideload Example";

    // ReSharper disable MemberCanBePrivate.Global
    public const string Guid = "digitalroot.mods.epicloot.adventure.bounties.sideloadexample";

    public const string Namespace = "Digitalroot.EpicLoot.Bounties.Example";
    // ReSharper restore MemberCanBePrivate.Global

    private Harmony _harmony;
    public static Main Instance;
    public readonly ManualLogSource Log = BepInEx.Logging.Logger.CreateLogSource(Namespace);
    public const string DependencyName = "som.Bears";

    public Main()
    {
      try
      {
        Instance = this;
      }
      catch (Exception e)
      {
        Log.LogError(e);
      }
    }

    [UsedImplicitly]
    private void Awake()
    {
      try
      {
        _harmony = Harmony.CreateAndPatchAll(typeof(Main).Assembly, Guid);
      }
      catch (Exception e)
      {
        Log.LogError(e);
      }
    }

    [UsedImplicitly]
    private void OnDestroy()
    {
      try
      {
        _harmony?.UnpatchSelf();
      }
      catch (Exception e)
      {
        Log.LogError(e);
      }
    }

    public void OnObjectDBCopyOtherDB(ref ObjectDB objectDB)
    {
      try
      {
        // If disabling the builtin bounties is desired. e.g. Your mod redefines them. Use the following to disabled them.
        // Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.DisabledAllBuiltinBounties(); // Disable all built in Bounties at once.
        Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.DisableBearsBounties(); // Disable built in Bears Bounties
        // Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.DisableFriendliesBounties(); // Disable built in Friendlies Bounties
        // Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.DisableMonsterLabZBounties(); // Disable built in MonsterLabZ Bounties
        // Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.DisableMonsternomiconBounties(); // Disable built in Monsternomicon Bounties
        // Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.DisableRRRMonsterBounties(); // Disable built in RRRMonster Bounties
        // Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.DisableSupplementalRaidsBounties(); // Disable built in SupplementalRaids Bounties
        // Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.DisableVanillaBounties(); // Disable built in Vanilla Bounties

        Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.AddToBountiesCollection(new BearsBounties());
      }
      catch (Exception e)
      {
        Log.LogError(e);
      }
    }
  }
}
