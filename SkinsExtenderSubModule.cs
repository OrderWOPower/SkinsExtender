using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace SkinsExtender
{
    // This mod allows modders to add individual nodes to skins.xml without copying and pasting an entire native skins.xml.
    public class SkinsExtenderSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad() => new Harmony("mod.bannerlord.skinsextender").PatchAll();
    }
}
