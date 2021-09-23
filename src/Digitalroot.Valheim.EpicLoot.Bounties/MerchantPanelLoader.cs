using Digitalroot.Valheim.Common;
using EpicLoot.Adventure;
using EpicLoot.Adventure.Feature;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Digitalroot.Valheim.EpicLoot.Adventure.Bounties
{
  /// <inheritdoc />
  [UsedImplicitly]
  public class MerchantPanelLoader : MonoBehaviour
  {
    // ReSharper disable once MemberCanBePrivate.Global
    public List<BountyTargetConfig> Bounties;

    // ReSharper disable once MemberCanBePrivate.Global
    public AdventureDataConfig AdventureDataManagerConfig;
    public MerchantPanel MerchantPanelCmb;

    public void Start()
    {
      try
      {
        Log.Trace(Main.Instance, $"{Main.Namespace}.{MethodBase.GetCurrentMethod().DeclaringType?.Name}.{MethodBase.GetCurrentMethod().Name}");
        Bounties = AdventureDataManager.Config.Bounties.Targets;
        AdventureDataManagerConfig = AdventureDataManager.Config;
        UpdateBounties();
        RefreshBounties();
      }
      catch (Exception e)
      {
        Log.Error(Main.Instance, e);
      }
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public static void UpdateBounties() => Main.Instance.ConfigureBounties();

    public void RefreshBounties()
    {
      try
      {
        var current = AdventureDataManager.Config.Bounties.RefreshInterval;
        AdventureDataManager.Config.Bounties.RefreshInterval = -1;
        var panel = MerchantPanelCmb.Panels.FirstOrDefault(p => p.GetType().Name == nameof(AvailableBountiesListPanel));
        panel?.RefreshItems(null);
        AdventureDataManager.Config.Bounties.RefreshInterval = current;
      }
      catch (Exception e)
      {
        Log.Error(Main.Instance, e);
      }
    }
  }
}
