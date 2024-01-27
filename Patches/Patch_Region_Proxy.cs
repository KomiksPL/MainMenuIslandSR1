using HarmonyLib;
using MonomiPark.SlimeRancher.Regions;

namespace MainMenuIsland.Patches
{
    [HarmonyPatch(typeof(Region), "Proxy")]
    public class Patch_Region_Proxy
    {
        internal static bool Prefix(Region regionInstance)
        {
            bool isMainMenuZone = regionInstance.GetZoneId() == Enums.MAIN_MENU;
            bool allowProxy = true;

            if (isMainMenuZone)
            {
                bool isNotCurrentRegionSet = !regionInstance.regionReg.IsCurrRegionSet(regionInstance.setId);

                if (isNotCurrentRegionSet)
                {
                    regionInstance.root.SetActive(false);
                    allowProxy = false;
                }
                else
                {
                    allowProxy = false;
                }
            }

            return allowProxy;
        }
    }
}