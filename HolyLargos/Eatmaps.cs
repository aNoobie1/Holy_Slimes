using HarmonyLib;
using SRML;
using static ShortcutLib.Shortcut;

namespace HolyLargos
{
    [HarmonyPatch(typeof(SlimeDiet), "RefreshEatMap")]
    class Eatmaps
    {
        static void Postfix(SlimeDiet __instance, SlimeDefinitions definitions, SlimeDefinition definition)
        {
            if (SRModLoader.IsModPresent("morelargos"))
            {
                if (definition.IdentifiableId != ModdedIds.Ids.DEMON_SLIME && definition.IdentifiableId != ModdedIds.Ids.ANGEL_SLIME && definition.IdentifiableId != ModdedIds.Ids.SPIRIT_SLIME && definition.IdentifiableId != ModdedIds.largoIds.SPIRIT_ANGEL_LARGO && definition.IdentifiableId != ModdedIds.largoIds.SPIRIT_DEMON_LARGO && definition.IdentifiableId != ModdedIds.Ids.CURSED_SLIME && definition.IdentifiableId != ModdedIds.Ids.BLESSED_SLIME && definition.IdentifiableId != ModdedIds.Ids.GHOSTLY_SLIME && definition.IdentifiableId != ModdedIds.largoIds.GHOSTLY_CURSED_LARGO && definition.IdentifiableId != ModdedIds.largoIds.GHOSTLY_BLESSED_LARGO && definition.IdentifiableId != ModdedIds.Ids.ANGEMON_SLIME&& definition.IdentifiableId != Ids.PINK_ANGEL_LARGO && definition.IdentifiableId != Ids.PINK_DEMON_LARGO && definition.IdentifiableId != Ids.PINK_SPIRIT_LARGO && definition.IdentifiableId != Ids.ROCK_ANGEL_LARGO && definition.IdentifiableId != Ids.ROCK_DEMON_LARGO && definition.IdentifiableId != Ids.ROCK_SPIRIT_LARGO && definition.IdentifiableId != Ids.TABBY_ANGEL_LARGO && definition.IdentifiableId != Ids.TABBY_DEMON_LARGO && definition.IdentifiableId != Ids.TABBY_SPIRIT_LARGO && definition.IdentifiableId != Ids.PHOSPHOR_ANGEL_LARGO && definition.IdentifiableId != Ids.PHOSPHOR_DEMON_LARGO && definition.IdentifiableId != Ids.PHOSPHOR_SPIRIT_LARGO && definition.IdentifiableId != Ids.RAD_ANGEL_LARGO && definition.IdentifiableId != Ids.RAD_DEMON_LARGO && definition.IdentifiableId != Ids.RAD_SPIRIT_LARGO && definition.IdentifiableId != Ids.BOOM_ANGEL_LARGO && definition.IdentifiableId != Ids.BOOM_DEMON_LARGO && definition.IdentifiableId != Ids.BOOM_SPIRIT_LARGO && definition.IdentifiableId != Ids.CRYSTAL_ANGEL_LARGO && definition.IdentifiableId != Ids.CRYSTAL_DEMON_LARGO && definition.IdentifiableId != Ids.CRYSTAL_SPIRIT_LARGO && definition.IdentifiableId != Ids.HONEY_ANGEL_LARGO && definition.IdentifiableId != Ids.HONEY_DEMON_LARGO && definition.IdentifiableId != Ids.HONEY_SPIRIT_LARGO && definition.IdentifiableId != Ids.HUNTER_ANGEL_LARGO && definition.IdentifiableId != Ids.HUNTER_DEMON_LARGO && definition.IdentifiableId != Ids.HUNTER_SPIRIT_LARGO && definition.IdentifiableId != EnumP.ParseID("PUDDLE_ANGEL_LARGO") && definition.IdentifiableId != EnumP.ParseID("PUDDLE_DEMON_LARGO") && definition.IdentifiableId != EnumP.ParseID("PUDDLE_SPIRIT_LARGO") && definition.IdentifiableId != EnumP.ParseID("FIRE_ANGEL_LARGO") && definition.IdentifiableId != EnumP.ParseID("FIRE_DEMON_LARGO") && definition.IdentifiableId != EnumP.ParseID("FIRE_SPIRIT_LARGO") && definition.IdentifiableId != EnumP.ParseID("GOLD_ANGEL_LARGO") && definition.IdentifiableId != EnumP.ParseID("GOLD_DEMON_LARGO") && definition.IdentifiableId != EnumP.ParseID("GOLD_SPIRIT_LARGO") && definition.IdentifiableId != EnumP.ParseID("LUCKY_ANGEL_LARGO") && definition.IdentifiableId != EnumP.ParseID("LUCKY_DEMON_LARGO") && definition.IdentifiableId != EnumP.ParseID("LUCKY_SPIRIT_LARGO") && definition.IdentifiableId != EnumP.ParseID("GLITCH_ANGEL_LARGO") && definition.IdentifiableId != EnumP.ParseID("GLITCH_DEMON_LARGO") && definition.IdentifiableId != EnumP.ParseID("GLITCH_SPIRIT_LARGO") && definition.IdentifiableId != EnumP.ParseID("QUICKSILVER_ANGEL_LARGO") && definition.IdentifiableId != EnumP.ParseID("QUICKSILVER_DEMON_LARGO") && definition.IdentifiableId != EnumP.ParseID("QUICKSILVER_SPIRIT_LARGO"))
                {
                    __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.CURSED_HEN);
                    __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.BLESSED_CARROT_VEGGIE);
                    __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.GHOSTLY_POGO_FRUIT);
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
                }
            }
            else
            {
                if (definition.IdentifiableId != ModdedIds.Ids.DEMON_SLIME && definition.IdentifiableId != ModdedIds.Ids.ANGEL_SLIME && definition.IdentifiableId != ModdedIds.Ids.SPIRIT_SLIME && definition.IdentifiableId != ModdedIds.largoIds.SPIRIT_ANGEL_LARGO && definition.IdentifiableId != ModdedIds.largoIds.SPIRIT_DEMON_LARGO && definition.IdentifiableId != ModdedIds.Ids.CURSED_SLIME && definition.IdentifiableId != ModdedIds.Ids.BLESSED_SLIME && definition.IdentifiableId != ModdedIds.Ids.GHOSTLY_SLIME && definition.IdentifiableId != ModdedIds.largoIds.GHOSTLY_CURSED_LARGO && definition.IdentifiableId != ModdedIds.largoIds.GHOSTLY_BLESSED_LARGO && definition.IdentifiableId != ModdedIds.Ids.ANGEMON_SLIME && definition.IdentifiableId != Ids.PINK_ANGEL_LARGO && definition.IdentifiableId != Ids.PINK_DEMON_LARGO && definition.IdentifiableId != Ids.PINK_SPIRIT_LARGO && definition.IdentifiableId != Ids.ROCK_ANGEL_LARGO && definition.IdentifiableId != Ids.ROCK_DEMON_LARGO && definition.IdentifiableId != Ids.ROCK_SPIRIT_LARGO && definition.IdentifiableId != Ids.TABBY_ANGEL_LARGO && definition.IdentifiableId != Ids.TABBY_DEMON_LARGO && definition.IdentifiableId != Ids.TABBY_SPIRIT_LARGO && definition.IdentifiableId != Ids.PHOSPHOR_ANGEL_LARGO && definition.IdentifiableId != Ids.PHOSPHOR_DEMON_LARGO && definition.IdentifiableId != Ids.PHOSPHOR_SPIRIT_LARGO && definition.IdentifiableId != Ids.RAD_ANGEL_LARGO && definition.IdentifiableId != Ids.RAD_DEMON_LARGO && definition.IdentifiableId != Ids.RAD_SPIRIT_LARGO && definition.IdentifiableId != Ids.BOOM_ANGEL_LARGO && definition.IdentifiableId != Ids.BOOM_DEMON_LARGO && definition.IdentifiableId != Ids.BOOM_SPIRIT_LARGO && definition.IdentifiableId != Ids.CRYSTAL_ANGEL_LARGO && definition.IdentifiableId != Ids.CRYSTAL_DEMON_LARGO && definition.IdentifiableId != Ids.CRYSTAL_SPIRIT_LARGO && definition.IdentifiableId != Ids.HONEY_ANGEL_LARGO && definition.IdentifiableId != Ids.HONEY_DEMON_LARGO && definition.IdentifiableId != Ids.HONEY_SPIRIT_LARGO && definition.IdentifiableId != Ids.HUNTER_ANGEL_LARGO && definition.IdentifiableId != Ids.HUNTER_DEMON_LARGO && definition.IdentifiableId != Ids.HUNTER_SPIRIT_LARGO)
                {
                    __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.CURSED_HEN);
                    __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.BLESSED_CARROT_VEGGIE);
                    __instance.EatMap.RemoveAll((x) => x.eats == ModdedIds.foodIds.GHOSTLY_POGO_FRUIT);
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
                }
            }
        }
    }
}
