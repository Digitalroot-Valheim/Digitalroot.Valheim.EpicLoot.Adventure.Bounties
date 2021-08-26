using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JetBrains.Annotations;
using System;

namespace Digitalroot.EpicLoot.Bounties.EpicValheim
{
  [BepInPlugin(Guid, Name, Version)]
  [BepInDependency(Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Guid, "2.0.3")]
  [BepInDependency(Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.MonsterLabZ)]
  [BepInDependency(Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.CustomRaids)]
  [BepInDependency(Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.RRRBetterRaids)]
  [BepInDependency(Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.RRRMonsters)]
  public class Main : BaseUnityPlugin
  {
    public const string Version = "1.0.2";
    public const string Name = "Digitalroot Valheim EpicLoot Adventure Bounties for Epic Valheim";

    // ReSharper disable MemberCanBePrivate.Global
    public const string Guid = "digitalroot.mods.epicloot.adventure.bounties.epicvalheim";
    public const string Namespace = "Digitalroot.EpicLoot.Bounties.EpicValheim";
    // ReSharper restore MemberCanBePrivate.Global

    private Harmony _harmony;
    public static Main Instance;
    public readonly ManualLogSource Log = BepInEx.Logging.Logger.CreateLogSource(Namespace);

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
        Config.Bind("General", "NexusID", 1401, "Nexus mod ID for updates");
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
        Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.DisabledAllBuiltinBounties(); // Disable all builtin at once.
        Digitalroot.Valheim.EpicLoot.Adventure.Bounties.Main.Instance.AddToBountiesCollection(new EpicValheimBounties());
      }
      catch (Exception e)
      {
        Log.LogError(e);
      }
    }
  }
}
