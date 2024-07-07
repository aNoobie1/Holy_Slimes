using HolySlimes;
using HolySlimes.Behaviors;
using ShortcutLib;
using SRML;
using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static ShortcutLib.Shortcut;

namespace HolyLargos
{
    public class Main : ModEntryPoint
    {
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();

            if (SRModLoader.IsModPresent("morelargos"))
            {
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "PUDDLE_ANGEL_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "PUDDLE_DEMON_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "PUDDLE_SPIRIT_LARGO");

                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "FIRE_ANGEL_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "FIRE_DEMON_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "FIRE_SPIRIT_LARGO");

                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "GOLD_ANGEL_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "GOLD_DEMON_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "GOLD_SPIRIT_LARGO");

                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "LUCKY_ANGEL_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "LUCKY_DEMON_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "LUCKY_SPIRIT_LARGO");

                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "GLITCH_ANGEL_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "GLITCH_DEMON_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "GLITCH_SPIRIT_LARGO");

                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "QUICKSILVER_ANGEL_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "QUICKSILVER_DEMON_LARGO");
                IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue<Identifiable.Id>(), "QUICKSILVER_SPIRIT_LARGO");
            }
            else
            {
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "PUDDLE_ANGEL_LARGO")
                    {
                        x = "ANGEL_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "PUDDLE_DEMON_LARGO")
                    {
                        x = "DEMON_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "PUDDLE_SPIRIT_LARGO")
                    {
                        x = "SPIRIT_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "FIRE_ANGEL_LARGO")
                    {
                        x = "ANGEL_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "FIRE_DEMON_LARGO")
                    {
                        x = "DEMON_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "FIRE_SPIRIT_LARGO")
                    {
                        x = "SPIRIT_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "GOLD_ANGEL_LARGO")
                    {
                        x = "ANGEL_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "GOLD_DEMON_LARGO")
                    {
                        x = "DEMON_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "GOLD_SPIRIT_LARGO")
                    {
                        x = "SPIRIT_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "LUCKY_ANGEL_LARGO")
                    {
                        x = "ANGEL_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "LUCKY_DEMON_LARGO")
                    {
                        x = "DEMON_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "LUCKY_SPIRIT_LARGO")
                    {
                        x = "SPIRIT_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "GLITCH_ANGEL_LARGO")
                    {
                        x = "ANGEL_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "GLITCH_DEMON_LARGO")
                    {
                        x = "DEMON_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "GLITCH_SPIRIT_LARGO")
                    {
                        x = "SPIRIT_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "QUICKSILVER_ANGEL_LARGO")
                    {
                        x = "ANGEL_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "QUICKSILVER_DEMON_LARGO")
                    {
                        x = "DEMON_SLIME";
                        return true;
                    }
                    return false;
                });
                EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
                {
                    if (x == "QUICKSILVER_SPIRIT_LARGO")
                    {
                        x = "SPIRIT_SLIME";
                        return true;
                    }
                    return false;
                });
            }
        }

        public static GameObject CreatePinkLargo(Identifiable.Id newLargoId, Identifiable.Id firstSlime, Identifiable.Id secondSlime)
        {
            SlimeRegistry.LargoProps largoProps =
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME1 |
            SlimeRegistry.LargoProps.RECOLOR_SLIME2_ADDON_MATS |
            SlimeRegistry.LargoProps.GENERATE_SECRET_STYLES |
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME1 |
            SlimeRegistry.LargoProps.RECOLOR_SLIME2_ADDON_MATS |
            SlimeRegistry.LargoProps.GENERATE_NAME;
            SlimeRegistry.CraftLargo(newLargoId, firstSlime, secondSlime, largoProps, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);
            return largoObj;
        }
        public static GameObject CreateCrystalLargo(Identifiable.Id newLargoId, Identifiable.Id firstSlime, Identifiable.Id secondSlime)
        {
            SlimeRegistry.LargoProps largoProps =
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
            SlimeRegistry.LargoProps.GENERATE_SECRET_STYLES |
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
            SlimeRegistry.LargoProps.GENERATE_NAME;
            SlimeRegistry.CraftLargo(newLargoId, firstSlime, secondSlime, largoProps, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);
            return largoObj;
        }
        public static GameObject CreateHoneyLargo(Identifiable.Id newLargoId, Identifiable.Id firstSlime, Identifiable.Id secondSlime)
        {
            SlimeRegistry.LargoProps largoProps =
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
            SlimeRegistry.LargoProps.GENERATE_SECRET_STYLES |
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
            SlimeRegistry.LargoProps.GENERATE_NAME;
            SlimeRegistry.CraftLargo(newLargoId, firstSlime, secondSlime, largoProps, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);
            return largoObj;
        }
        public static GameObject CreateLargo(Identifiable.Id newLargoId, Identifiable.Id firstSlime, Identifiable.Id secondSlime)
        {
            SlimeRegistry.LargoProps largoProps =
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
            SlimeRegistry.LargoProps.RECOLOR_SLIME1_ADDON_MATS |
            SlimeRegistry.LargoProps.GENERATE_SECRET_STYLES |
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
            SlimeRegistry.LargoProps.RECOLOR_SLIME1_ADDON_MATS |
            SlimeRegistry.LargoProps.GENERATE_NAME;
            SlimeRegistry.CraftLargo(newLargoId, firstSlime, secondSlime, largoProps, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);
            return largoObj;
        }

        public override void Load()
        {
            SRML.Console.Console.RegisterCommand(new Debug.SpawnAllLargosOfHolyType());
            SRML.Console.Console.RegisterCommand(new Debug.SpawnAllLargosOfSlimeType());
        }

        public override void PostLoad()
        {
            HolySlimes.Commands.SpiritMode.valid1.Add(Ids.PINK_SPIRIT_LARGO);
            HolySlimes.Commands.SpiritRandom.valid1.Add(Ids.PINK_SPIRIT_LARGO);

            HolySlimes.Commands.SpiritMode.valid1.Add(Ids.ROCK_SPIRIT_LARGO);
            HolySlimes.Commands.SpiritRandom.valid1.Add(Ids.ROCK_SPIRIT_LARGO);

            HolySlimes.Commands.SpiritMode.valid1.Add(Ids.TABBY_SPIRIT_LARGO);
            HolySlimes.Commands.SpiritRandom.valid1.Add(Ids.TABBY_SPIRIT_LARGO);

            HolySlimes.Commands.SpiritMode.valid1.Add(Ids.PHOSPHOR_SPIRIT_LARGO);
            HolySlimes.Commands.SpiritRandom.valid1.Add(Ids.PHOSPHOR_SPIRIT_LARGO);

            HolySlimes.Commands.SpiritMode.valid1.Add(Ids.RAD_SPIRIT_LARGO);
            HolySlimes.Commands.SpiritRandom.valid1.Add(Ids.RAD_SPIRIT_LARGO);

            HolySlimes.Commands.SpiritMode.valid1.Add(Ids.BOOM_SPIRIT_LARGO);
            HolySlimes.Commands.SpiritRandom.valid1.Add(Ids.BOOM_SPIRIT_LARGO);

            HolySlimes.Commands.SpiritMode.valid1.Add(Ids.CRYSTAL_SPIRIT_LARGO);
            HolySlimes.Commands.SpiritRandom.valid1.Add(Ids.CRYSTAL_SPIRIT_LARGO);

            HolySlimes.Commands.SpiritMode.valid1.Add(Ids.HONEY_SPIRIT_LARGO);
            HolySlimes.Commands.SpiritRandom.valid1.Add(Ids.HONEY_SPIRIT_LARGO);

            HolySlimes.Commands.SpiritMode.valid1.Add(Ids.HUNTER_SPIRIT_LARGO);
            HolySlimes.Commands.SpiritRandom.valid1.Add(Ids.HUNTER_SPIRIT_LARGO);

            CreateLargo(Ids.QUANTUM_ANGEL_LARGO, Identifiable.Id.QUANTUM_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            var editedLargo_QuantumDemon = CreateLargo(Ids.QUANTUM_DEMON_LARGO, Identifiable.Id.QUANTUM_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreateLargo(Ids.QUANTUM_SPIRIT_LARGO, Identifiable.Id.QUANTUM_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

            CreatePinkLargo(Ids.PINK_ANGEL_LARGO, Identifiable.Id.PINK_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            CreatePinkLargo(Ids.PINK_DEMON_LARGO, Identifiable.Id.PINK_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreatePinkLargo(Ids.PINK_SPIRIT_LARGO, Identifiable.Id.PINK_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

            CreateLargo(Ids.ROCK_ANGEL_LARGO, Identifiable.Id.ROCK_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            CreateLargo(Ids.ROCK_DEMON_LARGO, Identifiable.Id.ROCK_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreateLargo(Ids.ROCK_SPIRIT_LARGO, Identifiable.Id.ROCK_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

            CreateLargo(Ids.TABBY_ANGEL_LARGO, Identifiable.Id.TABBY_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            var editedLargo_TabbyDemon = CreateLargo(Ids.TABBY_DEMON_LARGO, Identifiable.Id.TABBY_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreateLargo(Ids.TABBY_SPIRIT_LARGO, Identifiable.Id.TABBY_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

            var editedLargo_PhosphorAngel = CreateLargo(Ids.PHOSPHOR_ANGEL_LARGO, Identifiable.Id.PHOSPHOR_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            CreateLargo(Ids.PHOSPHOR_DEMON_LARGO, Identifiable.Id.PHOSPHOR_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreateLargo(Ids.PHOSPHOR_SPIRIT_LARGO, Identifiable.Id.PHOSPHOR_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

            var editedLargo_RadAngel = CreateLargo(Ids.RAD_ANGEL_LARGO, Identifiable.Id.RAD_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            CreateLargo(Ids.RAD_DEMON_LARGO, Identifiable.Id.RAD_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreateLargo(Ids.RAD_SPIRIT_LARGO, Identifiable.Id.RAD_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

            CreateLargo(Ids.BOOM_ANGEL_LARGO, Identifiable.Id.BOOM_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            CreateLargo(Ids.BOOM_DEMON_LARGO, Identifiable.Id.BOOM_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreateLargo(Ids.BOOM_SPIRIT_LARGO, Identifiable.Id.BOOM_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

            CreateCrystalLargo(Ids.CRYSTAL_ANGEL_LARGO, Identifiable.Id.CRYSTAL_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            CreateCrystalLargo(Ids.CRYSTAL_DEMON_LARGO, Identifiable.Id.CRYSTAL_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreateCrystalLargo(Ids.CRYSTAL_SPIRIT_LARGO, Identifiable.Id.CRYSTAL_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

            CreateHoneyLargo(Ids.HONEY_ANGEL_LARGO, Identifiable.Id.HONEY_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            CreateHoneyLargo(Ids.HONEY_DEMON_LARGO, Identifiable.Id.HONEY_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreateHoneyLargo(Ids.HONEY_SPIRIT_LARGO, Identifiable.Id.HONEY_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

            CreateLargo(Ids.HUNTER_ANGEL_LARGO, Identifiable.Id.HUNTER_SLIME, ModdedIds.Ids.ANGEL_SLIME);
            var editedLargo_HunterDemon = CreateLargo(Ids.HUNTER_DEMON_LARGO, Identifiable.Id.HUNTER_SLIME, ModdedIds.Ids.DEMON_SLIME);
            CreateLargo(Ids.HUNTER_SPIRIT_LARGO, Identifiable.Id.HUNTER_SLIME, ModdedIds.Ids.SPIRIT_SLIME);


            var quantumdemonstr = editedLargo_QuantumDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures;
            var quantumdemonnewstr = quantumdemonstr.ToList();
            quantumdemonnewstr.RemoveAt(2);
            quantumdemonnewstr.Insert(2, new SlimeAppearanceStructure(HolySlimes.Creation.Slimes.slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]));
            editedLargo_QuantumDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures = quantumdemonnewstr.ToArray();

            var tabbydemonstr = editedLargo_TabbyDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures;
            var tabbydemonnewstr = tabbydemonstr.ToList();
            tabbydemonnewstr.RemoveAt(3);
            editedLargo_TabbyDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures = tabbydemonnewstr.ToArray();

            var phosphorangelstr = editedLargo_PhosphorAngel.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures;
            var phosphorangelnewstr = phosphorangelstr.ToList();
            phosphorangelnewstr.RemoveAt(4);
            editedLargo_PhosphorAngel.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures = phosphorangelnewstr.ToArray();

            var radangelstr = editedLargo_RadAngel.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures;
            var radangelnewstr = radangelstr.ToList();
            radangelnewstr.RemoveAt(3);
            editedLargo_RadAngel.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures = radangelnewstr.ToArray();

            var hunterdemonstr = editedLargo_HunterDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures;
            var hunterdemonnewstr = hunterdemonstr.ToList();
            hunterdemonnewstr.RemoveAt(3);
            editedLargo_HunterDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures = hunterdemonnewstr.ToArray();


            if (SRModLoader.IsModPresent("morelargos"))
            {
                SRML.Console.Console.Instance.Log("Detected more largos mod! Loading extra largos.");


                HolySlimes.Commands.SpiritMode.valid1.Add(EnumP.ParseID("PUDDLE_SPIRIT_LARGO"));
                HolySlimes.Commands.SpiritRandom.valid1.Add(EnumP.ParseID("PUDDLE_SPIRIT_LARGO"));

                HolySlimes.Commands.SpiritMode.valid1.Add(EnumP.ParseID("FIRE_SPIRIT_LARGO"));
                HolySlimes.Commands.SpiritRandom.valid1.Add(EnumP.ParseID("FIRE_SPIRIT_LARGO"));

                HolySlimes.Commands.SpiritMode.valid1.Add(EnumP.ParseID("GOLD_SPIRIT_LARGO"));
                HolySlimes.Commands.SpiritRandom.valid1.Add(EnumP.ParseID("GOLD_SPIRIT_LARGO"));

                HolySlimes.Commands.SpiritMode.valid1.Add(EnumP.ParseID("LUCKY_SPIRIT_LARGO"));
                HolySlimes.Commands.SpiritRandom.valid1.Add(EnumP.ParseID("LUCKY_SPIRIT_LARGO"));

                HolySlimes.Commands.SpiritMode.valid1.Add(EnumP.ParseID("GLITCH_SPIRIT_LARGO"));
                HolySlimes.Commands.SpiritRandom.valid1.Add(EnumP.ParseID("GLITCH_SPIRIT_LARGO"));

                HolySlimes.Commands.SpiritMode.valid1.Add(EnumP.ParseID("QUICKSILVER_SPIRIT_LARGO"));
                HolySlimes.Commands.SpiritRandom.valid1.Add(EnumP.ParseID("QUICKSILVER_SPIRIT_LARGO"));


                CreateLargo(EnumP.ParseID("PUDDLE_ANGEL_LARGO"), Identifiable.Id.PUDDLE_SLIME, ModdedIds.Ids.ANGEL_SLIME);
                CreateLargo(EnumP.ParseID("PUDDLE_DEMON_LARGO"), Identifiable.Id.PUDDLE_SLIME, ModdedIds.Ids.DEMON_SLIME);
                CreateLargo(EnumP.ParseID("PUDDLE_SPIRIT_LARGO"), Identifiable.Id.PUDDLE_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

                CreateLargo(EnumP.ParseID("FIRE_ANGEL_LARGO"), Identifiable.Id.FIRE_SLIME, ModdedIds.Ids.ANGEL_SLIME);
                CreateLargo(EnumP.ParseID("FIRE_DEMON_LARGO"), Identifiable.Id.FIRE_SLIME, ModdedIds.Ids.DEMON_SLIME);
                CreateLargo(EnumP.ParseID("FIRE_SPIRIT_LARGO"), Identifiable.Id.FIRE_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

                var editedLargo_GoldAngel = CreateLargo(EnumP.ParseID("GOLD_ANGEL_LARGO"), Identifiable.Id.GOLD_SLIME, ModdedIds.Ids.ANGEL_SLIME);
                var editedLargo_GoldDemon = CreateLargo(EnumP.ParseID("GOLD_DEMON_LARGO"), Identifiable.Id.GOLD_SLIME, ModdedIds.Ids.DEMON_SLIME);
                var editedLargo_GoldSpirit = CreateLargo(EnumP.ParseID("GOLD_SPIRIT_LARGO"), Identifiable.Id.GOLD_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

                CreateLargo(EnumP.ParseID("LUCKY_ANGEL_LARGO"), Identifiable.Id.LUCKY_SLIME, ModdedIds.Ids.ANGEL_SLIME);
                var editedLargo_LuckyDemon = CreateLargo(EnumP.ParseID("LUCKY_DEMON_LARGO"), Identifiable.Id.LUCKY_SLIME, ModdedIds.Ids.DEMON_SLIME);
                CreateLargo(EnumP.ParseID("LUCKY_SPIRIT_LARGO"), Identifiable.Id.LUCKY_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

                var editedLargo_GlitchAngel = CreateLargo(EnumP.ParseID("GLITCH_ANGEL_LARGO"), Identifiable.Id.GLITCH_SLIME, ModdedIds.Ids.ANGEL_SLIME);
                var editedLargo_GlitchDemon = CreateLargo(EnumP.ParseID("GLITCH_DEMON_LARGO"), Identifiable.Id.GLITCH_SLIME, ModdedIds.Ids.DEMON_SLIME);
                var editedLargo_GlitchSpirit = CreateLargo(EnumP.ParseID("GLITCH_SPIRIT_LARGO"), Identifiable.Id.GLITCH_SLIME, ModdedIds.Ids.SPIRIT_SLIME);

                var editedLargo_QuicksilverAngel = CreateLargo(EnumP.ParseID("QUICKSILVER_ANGEL_LARGO"), Identifiable.Id.QUICKSILVER_SLIME, ModdedIds.Ids.ANGEL_SLIME);
                var editedLargo_QuicksilverDemon = CreateLargo(EnumP.ParseID("QUICKSILVER_DEMON_LARGO"), Identifiable.Id.QUICKSILVER_SLIME, ModdedIds.Ids.DEMON_SLIME);
                var editedLargo_QuicksilverSpirit = CreateLargo(EnumP.ParseID("QUICKSILVER_SPIRIT_LARGO"), Identifiable.Id.QUICKSILVER_SLIME, ModdedIds.Ids.SPIRIT_SLIME);


                Material materialGlAn = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                materialGlAn.SetColor("_BottomColor", new Color32(218, 200, 140, 255));
                Material materialGlAn2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                materialGlAn2.SetColor("_BottomColor", new Color32(218, 200, 140, 255));
                editedLargo_GlitchAngel.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures[0].DefaultMaterials[0] = materialGlAn;
                editedLargo_GlitchAngel.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures[1].DefaultMaterials[0] = materialGlAn2;
                editedLargo_GlitchAngel.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures[3].DefaultMaterials[0] = materialGlAn;
                editedLargo_GlitchAngel.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures[4].DefaultMaterials[0] = materialGlAn;

                Material materialGlDe = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                materialGlDe.SetColor("_BottomColor", new Color32(125, 25, 25, 255));
                Material materialGlDe2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                materialGlDe2.SetColor("_BottomColor", new Color32(125, 25, 25, 255));
                editedLargo_GlitchDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures[0].DefaultMaterials[0] = materialGlDe;
                editedLargo_GlitchDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures[1].DefaultMaterials[0] = materialGlDe2;
                editedLargo_GlitchDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures[3].DefaultMaterials[0] = materialGlDe;
                editedLargo_GlitchDemon.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition.AppearancesDefault[0].Structures[4].DefaultMaterials[0] = materialGlDe;
            }
        }
    }
}