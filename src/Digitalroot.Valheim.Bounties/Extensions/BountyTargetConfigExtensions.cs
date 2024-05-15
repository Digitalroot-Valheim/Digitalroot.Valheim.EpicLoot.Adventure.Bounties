using EpicLoot.Adventure;
using EpicLoot.Patching;
using System;
using System.Collections.Generic;

namespace Digitalroot.Valheim.Bounties.Extensions
{
  public static class BountyTargetConfigExtensions
  {
    public static DigitalrootPatch ToPatch(this BountyTargetConfig self, PatchAction patchAction)
    {
      return new DigitalrootPatch
      {
        Path = "$.Bounties.Targets"
        , Action = patchAction
        , Value = self
      };
    }

    [Serializable]
    public class DigitalrootPatch
    {
      // public int Priority = -1;
      // public string Author = "";
      // public string SourceFile = "";
      // public string TargetFile = "";
      public string Path = string.Empty;
      public PatchAction Action = PatchAction.None;
      // public bool Require;
      // public string PropertyName = "";
      public BountyTargetConfig Value = null;
    }

    [Serializable]
    public class DigitalrootPatchFile
    {
      public int Priority = 500;
      public string TargetFile = string.Empty;
      public string Author = string.Empty;
      public bool RequireAll = false;
      public List<DigitalrootPatch> Patches;

      public string ToJson()
      {
        return Common.Json.JsonSerializationProvider.Serialize(this);
      }
    }
  }
}
