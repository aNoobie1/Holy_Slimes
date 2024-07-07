using HarmonyLib;
using SRML;

namespace HolySlimes
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
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.SPIRIT_PLORT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.SPIRIT_SLIME,
                    eats = ModdedIds.Ids.DEMON_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.resourceIds.ANGEL_ESSENCE,
                    eats = ModdedIds.Ids.DEMON_PLORT,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.largoIds.SPIRIT_ANGEL_LARGO,
                    eats = ModdedIds.Ids.SPIRIT_PLORT,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == ModdedIds.Ids.DEMON_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.ANGEL_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.ANGEL_PLORT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.SPIRIT_PLORT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.SPIRIT_SLIME,
                    eats = ModdedIds.Ids.ANGEL_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.resourceIds.DEMON_ESSENCE,
                    eats = ModdedIds.Ids.ANGEL_PLORT,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.largoIds.SPIRIT_DEMON_LARGO,
                    eats = ModdedIds.Ids.SPIRIT_PLORT,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == ModdedIds.Ids.SPIRIT_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.ANGEL_PLORT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.DEMON_PLORT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.resourceIds.SPIRIT_ESSENCE,
                    eats = ModdedIds.Ids.ANGEL_PLORT,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.resourceIds.SPIRIT_ESSENCE,
                    eats = ModdedIds.Ids.DEMON_PLORT,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == ModdedIds.Ids.BLESSED_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.CURSED_HEN);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.GHOSTLY_POGO_FRUIT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.CURSED_SLIME);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.largoIds.GHOSTLY_BLESSED_LARGO,
                    eats = ModdedIds.foodIds.GHOSTLY_POGO_FRUIT,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.resourceIds.BLESSED_ESSENCE,
                    eats = ModdedIds.foodIds.CURSED_HEN,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.GHOSTLY_SLIME,
                    eats = ModdedIds.Ids.CURSED_SLIME,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == ModdedIds.Ids.GHOSTLY_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.CURSED_HEN);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.BLESSED_CARROT_VEGGIE);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.resourceIds.GHOSTLY_ESSENCE,
                    eats = ModdedIds.foodIds.CURSED_HEN,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.resourceIds.GHOSTLY_ESSENCE,
                    eats = ModdedIds.foodIds.BLESSED_CARROT_VEGGIE,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == ModdedIds.Ids.CURSED_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.GHOSTLY_POGO_FRUIT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.BLESSED_CARROT_VEGGIE);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.BLESSED_SLIME);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.largoIds.GHOSTLY_CURSED_LARGO,
                    eats = ModdedIds.foodIds.GHOSTLY_POGO_FRUIT,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.resourceIds.CURSED_ESSENCE,
                    eats = ModdedIds.foodIds.BLESSED_CARROT_VEGGIE,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.GHOSTLY_SLIME,
                    eats = ModdedIds.Ids.BLESSED_SLIME,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId != ModdedIds.Ids.DEMON_SLIME && definition.IdentifiableId != ModdedIds.Ids.ANGEL_SLIME && definition.IdentifiableId != ModdedIds.Ids.SPIRIT_SLIME && definition.IdentifiableId != ModdedIds.largoIds.SPIRIT_ANGEL_LARGO && definition.IdentifiableId != ModdedIds.largoIds.SPIRIT_DEMON_LARGO && definition.IdentifiableId != ModdedIds.Ids.CURSED_SLIME && definition.IdentifiableId != ModdedIds.Ids.BLESSED_SLIME && definition.IdentifiableId != ModdedIds.Ids.GHOSTLY_SLIME && definition.IdentifiableId != ModdedIds.largoIds.GHOSTLY_CURSED_LARGO && definition.IdentifiableId != ModdedIds.largoIds.GHOSTLY_BLESSED_LARGO && definition.IdentifiableId != ModdedIds.Ids.ANGEMON_SLIME && definition.IdentifiableId != ModdedIds.Ids.BLURSED_SLIME && definition.IdentifiableId != ModdedIds.Ids.PURIFIED_ANGEMON_SLIME && definition.IdentifiableId != ModdedIds.Ids.PURIFIED_BLURSED_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.CURSED_HEN);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.BLESSED_CARROT_VEGGIE);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.GHOSTLY_POGO_FRUIT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.AMALGAMANGO_FRUIT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.BLURSED_PEAR_FRUIT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.CURSED_SLIME,
                    eats = ModdedIds.foodIds.CURSED_HEN,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.BLESSED_SLIME,
                    eats = ModdedIds.foodIds.BLESSED_CARROT_VEGGIE,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.GHOSTLY_SLIME,
                    eats = ModdedIds.foodIds.GHOSTLY_POGO_FRUIT,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.BLURSED_SLIME,
                    eats = ModdedIds.foodIds.AMALGAMANGO_FRUIT,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ModdedIds.Ids.PURIFIED_BLURSED_SLIME,
                    eats = ModdedIds.foodIds.BLURSED_PEAR_FRUIT,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == ModdedIds.largoIds.GHOSTLY_CURSED_LARGO || definition.IdentifiableId == ModdedIds.largoIds.GHOSTLY_BLESSED_LARGO)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.CURSED_HEN);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.BLESSED_CARROT_VEGGIE);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.GHOSTLY_POGO_FRUIT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.AMALGAMANGO_FRUIT);
            }
            if (definition.IdentifiableId == ModdedIds.Ids.ANGEMON_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.ANGEL_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.DEMON_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.SPIRIT_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.SPIRIT_PLORT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.BLESSED_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.CURSED_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.GHOSTLY_SLIME);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = ModdedIds.Ids.ANGEMON_SLIME,
                    eats = ModdedIds.Ids.ANGEL_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = ModdedIds.Ids.BLURSED_SLIME,
                    eats = ModdedIds.Ids.BLESSED_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = ModdedIds.Ids.ANGEMON_SLIME,
                    eats = ModdedIds.Ids.DEMON_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = ModdedIds.Ids.BLURSED_SLIME,
                    eats = ModdedIds.Ids.CURSED_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = Identifiable.Id.NONE,
                    eats = ModdedIds.Ids.SPIRIT_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = Identifiable.Id.NONE,
                    eats = ModdedIds.Ids.GHOSTLY_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = Identifiable.Id.NONE,
                    eats = ModdedIds.Ids.SPIRIT_PLORT,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == ModdedIds.Ids.BLURSED_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.ANGEL_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.DEMON_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.SPIRIT_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.BLESSED_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.CURSED_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.Ids.GHOSTLY_SLIME);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.GHOSTLY_POGO_FRUIT);
                __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.AMALGAMANGO_FRUIT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = ModdedIds.Ids.ANGEMON_SLIME,
                    eats = ModdedIds.Ids.ANGEL_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = ModdedIds.Ids.BLURSED_SLIME,
                    eats = ModdedIds.Ids.BLESSED_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = ModdedIds.Ids.ANGEMON_SLIME,
                    eats = ModdedIds.Ids.DEMON_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = ModdedIds.Ids.BLURSED_SLIME,
                    eats = ModdedIds.Ids.CURSED_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = Identifiable.Id.NONE,
                    eats = ModdedIds.Ids.SPIRIT_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = Identifiable.Id.NONE,
                    eats = ModdedIds.Ids.GHOSTLY_SLIME,
                    minDrive = 1
                });
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = Identifiable.Id.NONE,
                    eats = ModdedIds.foodIds.GHOSTLY_POGO_FRUIT,
                    minDrive = 1
                });
            }
        }
    }
}


