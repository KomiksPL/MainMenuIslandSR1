using HarmonyLib;
using MonomiPark.SlimeRancher.Regions;

namespace MainMenuIsland.Patches
{
    [HarmonyPatch(typeof(ZoneDirector), "GetRegionSetId")]
    public class Patch_ZoneDirector_GetRegionSetId
    {
        internal static bool Prefix(ZoneDirector.Zone currentZone, ref RegionRegistry.RegionSetId result)
        {
            if (currentZone == Enums.MAIN_MENU)
            {
                result = RegionRegistry.RegionSetId.HOME;
                return false;
            }

            return true;
        }
    }
}