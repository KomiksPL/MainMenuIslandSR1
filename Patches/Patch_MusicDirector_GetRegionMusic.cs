using System.Collections.Generic;
using HarmonyLib;
using MonomiPark.SlimeRancher.Regions;

namespace MainMenuIsland.Patches
{
    [HarmonyPatch(typeof(MusicDirector), "GetRegionMusic")]
    public class Patch_MusicDirector_GetRegionMusic
    {
        public static void Postfix(MusicDirector musicDirectorInstance, ref MusicDirector.Music result, RegionMember regionMember)
        {
            bool resultIsNull = result == null;

            if (resultIsNull)
            {
                HashSet<ZoneDirector.Zone> zonesHashSet = ZoneDirector.Zones(regionMember);
                bool isMainMenuZone = zonesHashSet.Contains(Enums.MAIN_MENU);

                if (isMainMenuZone)
                {
                    result = musicDirectorInstance.reefMusic;
                }
            }
            else
            {
                bool isSeaMusic = result.GetCurrentCue() == musicDirectorInstance.seaMusic.GetCurrentCue();

                if (isSeaMusic)
                {
                    HashSet<ZoneDirector.Zone> zonesHashSet = ZoneDirector.Zones(regionMember);
                    bool isMainMenuZone = zonesHashSet.Contains(Enums.MAIN_MENU);

                    if (isMainMenuZone)
                    {
                        musicDirectorInstance.queue.queue.RemoveAll((MusicDirector.Music x) => x.GetCurrentCue().name == musicDirectorInstance.seaMusic.GetCurrentCue().name);
                        result = musicDirectorInstance.reefMusic;
                    }
                }
            }
        }
    }
}