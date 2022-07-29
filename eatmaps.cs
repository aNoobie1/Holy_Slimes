using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace Holy_Slimes
{
    [HarmonyPatch(typeof(SlimeDiet), "RefreshEatMap")]
    class EatMapPatch
    {
        static void Postfix(SlimeDiet __instance, SlimeDefinitions definitions, SlimeDefinition definition)
        {
            if (definition.IdentifiableId == ModdedIds.Ids.ANGEL_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.DEMON_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.DEMON_PLORT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.SPIRIT_SLIME,
                    eats = ModdedIds.Ids.DEMON_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = Identifiable.Id.SILKY_SAND_CRAFT,
                    eats = ModdedIds.Ids.DEMON_PLORT,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == ModdedIds.Ids.DEMON_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.ANGEL_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.ANGEL_PLORT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.SPIRIT_SLIME,
                    eats = ModdedIds.Ids.ANGEL_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = Identifiable.Id.LAVA_DUST_CRAFT,
                    eats = ModdedIds.Ids.ANGEL_PLORT,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == ModdedIds.Ids.SPIRIT_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.ANGEL_PLORT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.DEMON_PLORT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = Identifiable.Id.SPIRAL_STEAM_CRAFT,
                    eats = ModdedIds.Ids.ANGEL_PLORT,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = Identifiable.Id.SPIRAL_STEAM_CRAFT,
                    eats = ModdedIds.Ids.DEMON_PLORT,
                    minDrive = 1
                });
            }
        }
    }
}


