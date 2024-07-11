using SRML;
using SRML.SR;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MonomiPark.SlimeRancher.Regions;
using HolySlimes.Creation;
using HolySlimes.Creation.Slime;
//using HolySlimes.Creation.Gordo;
using SRML.SR.Translation;
using SRML.Utils;
using ModdedIds;
using SimpleSRmodLibrary.Creation;
using ShortcutLib;
using static ShortcutLib.Shortcut;
using HolySlimes.Commands;
using AssetsLib;
using HolySlimes.Behaviors;
using HolySlimes.Utility;

namespace HolySlimes
{
    public class Main : ModEntryPoint
    {
        public static Color32 Aeyes = new Color32(135, 206, 235, 255);
        public static Color32 Amouth = new Color32(102, 0, 0, 255);
        public static Color32 Beyes = new Color32(118, 103, 117, 255);
        public static Color32 Bmouth = new Color32(118, 103, 117, 255);
        public static Color32 IAeyes = new Color32(118, 103, 117, 255);
        public static Color32 IAmouth = new Color32(118, 103, 117, 255);

        public static AssetBundle slimeData = Util.LoadCustomData("slimedata");

        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();

            EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
            {
                if (x == "CURSED_GHOSTLY_LARGO")
                {
                    x = "GHOSTLY_CURSED_LARGO";
                    return true;
                }
                return false;
            });
            EnumTranslator.RegisterFallbackHandler<Identifiable.Id>((ref string x) =>
            {
                if (x == "BLESSED_CURSED_LARGO")
                {
                    x = "BLURSED_SLIME";
                    return true;
                }
                return false;
            });

            

            TranslationPatcher.AddActorTranslation("l." + (Ids.ANGEL_PLORT.ToString().ToLower()), "Angel Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.ANGEL_PLORT);
            Identifiable.PLORT_CLASS.Add(Ids.ANGEL_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.ANGEL_PLORT);

            TranslationPatcher.AddActorTranslation("l." + (Ids.DEMON_PLORT.ToString().ToLower()), "Demon Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.DEMON_PLORT);
            Identifiable.PLORT_CLASS.Add(Ids.DEMON_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.DEMON_PLORT);

            TranslationPatcher.AddActorTranslation("l." + (Ids.SPIRIT_PLORT.ToString().ToLower()), "Spirit Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.SPIRIT_PLORT);
            Identifiable.PLORT_CLASS.Add(Ids.SPIRIT_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.SPIRIT_PLORT);

            SRCallbacks.PreSaveGameLoad += Zones.Init;

            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.MOSS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.ANGEL_SLIME),
                                weight = 0.25f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });

            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.DESERT;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.DEMON_SLIME),
                                weight = 0.25f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });

            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.DESERT;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.CURSED_SLIME),
                                weight = 0.0025f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });

            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.MOSS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.BLESSED_SLIME),
                                weight = 0.0025f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            

            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.ANGEL_PLORT);
            PediaRegistry.RegisterIdentifiableMapping(Ids.ANGEL_ENTRY, Ids.ANGEL_SLIME);
            PediaRegistry.SetPediaCategory(Ids.ANGEL_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.ANGEL_ENTRY)
                .SetTitleTranslation("Angel Slime")
                .SetIntroTranslation("Slimes from Heaven")
                .SetDietTranslation("Veggies")
                .SetFavoriteTranslation("Blessed Carrots")
                .SetSlimeologyTranslation("Angel Slimes are slimes that have descended from heaven to join the other slimes on the Far, Far Range. Their main purpose in life is to destroy the Demon Slimes.")
                .SetRisksTranslation("Angel Slimes will sacrifice themselves to destroy any traces of Demon Slimes. Make sure never to let an Angel Slime near a Demon Plort. While within an Angel Slime's aura, it will actively heal you, so it may be beneficial to keep around.")
                .SetPlortonomicsTranslation("Angel Plorts are used on Earth to work miracles for the population. They can cure many diseases, bring water to deserts, and even revive extinct species. In these acts, the plort is consumed, so they are in constant demand.");

            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.DEMON_PLORT);
            PediaRegistry.RegisterIdentifiableMapping(Ids.DEMON_ENTRY, Ids.DEMON_SLIME);
            PediaRegistry.SetPediaCategory(Ids.DEMON_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.DEMON_ENTRY)
                .SetTitleTranslation("Demon Slime")
                .SetIntroTranslation("Slimes from Hades")
                .SetDietTranslation("Meat")
                .SetFavoriteTranslation("Cursed Hens")
                .SetSlimeologyTranslation("Demon Slimes are slimes that have risen from hades to join the other slimes on the Far, Far Range. Their main purpose in life is to destroy the Angel Slimes.")
                .SetRisksTranslation("Demon Slimes will sacrifice themselves to destroy any traces of Angel Slimes. Make sure never to let a Demon Slime near an Angel Plort. The Demon Slime's fire has been proven to drain the vitality of anyone who touches it. What's more, you will not naturally heal from this, so be careful around them.")
                .SetPlortonomicsTranslation("Demon Plorts are capable of producing mass catastrophies. In the wrong hands, these plorts can terrorize nations with natural disasters, plagues, and bankruptcy. In scientific hands however, they can be used to study these things. In these acts, the plort is consumed, so they are in constant demand.");

            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.SPIRIT_PLORT);
            PediaRegistry.RegisterIdentifiableMapping(Ids.SPIRIT_ENTRY, Ids.SPIRIT_SLIME);
            PediaRegistry.SetPediaCategory(Ids.SPIRIT_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.SPIRIT_ENTRY)
                .SetTitleTranslation("Spirit Slime")
                .SetIntroTranslation("Former slimes of war")
                .SetDietTranslation("Fruit")
                .SetFavoriteTranslation("Ghostly Pogofruit")
                .SetSlimeologyTranslation("Spirit Slimes are the result of a war as old as time. When Angel and Demon Slimes see each other, they will instantly attack each other, ultimately forming this slime.")
                .SetRisksTranslation("In an attempt to revert to their normal states, Spirit Slimes will seek out Angel and Demon Plorts to eat. This, however, always fails and, instead, causes the spirit slime to lose sentience entirely. The odd effect around their bodies is not just for show; upon contact with a spirit slime, it will either heal you, drain your vitality, or do nothing at all.")
                .SetPlortonomicsTranslation("Spirit plorts are often used in situations of dire emergency, when you need a miracle and are willing to deal with anything to get it. These plorts will work a miracle, but will also work a corresponding disaster alongside it. Desperate people will buy these plorts for extra newbucks.");

            PediaRegistry.RegisterIdentifiableMapping(Ids.CURSED_ENTRY, Ids.CURSED_SLIME);
            PediaRegistry.SetPediaCategory(Ids.CURSED_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.CURSED_ENTRY)
                .SetTitleTranslation("Cursed Slime")
                .SetIntroTranslation("Cursed to a dull existence")
                .SetDietTranslation("Fruit, Veggies")
                .SetFavoriteTranslation("None")
                .SetSlimeologyTranslation("Cursed Slimes are doomed to the fate of creating Cursed Hens for Demon Slimes to feast on. They are servants and cannot be freed from their torturous existence.")
                .SetRisksTranslation("Cursed Slimes produce Cursed Hens which, when eaten by any slime other than a Demon Slime, will transform it into another Cursed Slime. Only Angel and Spirit Slimes can resist these urges. If left unchecked, they can easily overtake an entire area.")
                .SetPlortonomicsTranslation("Cursed Slimes produce no plorts, only Cursed Hens.");

            PediaRegistry.RegisterIdentifiableMapping(Ids.BLESSED_ENTRY, Ids.BLESSED_SLIME);
            PediaRegistry.SetPediaCategory(Ids.BLESSED_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.BLESSED_ENTRY)
                .SetTitleTranslation("Blessed Slime")
                .SetIntroTranslation("Blessed with a holy purpose")
                .SetDietTranslation("Fruit, Meat")
                .SetFavoriteTranslation("None")
                .SetSlimeologyTranslation("Blessed Slimes have been granted a holy job of creating Blessed Carrots for Angel Slimes to eat. They are well-treated and unwilling to be removed from their life of luxury.")
                .SetRisksTranslation("Blessed Slimes produce Blessed Carrots which, when eaten by any slime other than an Angel Slime, will transform it into another Blessed Slime. Demon and Spirit Slimes are forbidden to eat this item. If left unchecked, they can easily overtake an entire area.")
                .SetPlortonomicsTranslation("Blessed Slimes produce no plorts, only Blessed Carrots.");

            PediaRegistry.RegisterIdentifiableMapping(Ids.GHOSTLY_ENTRY, Ids.GHOSTLY_SLIME);
            PediaRegistry.SetPediaCategory(Ids.GHOSTLY_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.GHOSTLY_ENTRY)
                .SetTitleTranslation("Ghostly Slime")
                .SetIntroTranslation("Sort of a ghost, but also, not?")
                .SetDietTranslation("Veggies, Meat")
                .SetFavoriteTranslation("None")
                .SetSlimeologyTranslation("It is unknown whether Ghostly Slimes enjoy their life or not, as they show no emotion whatsoever. What is known is they are stuck producing Ghostly Pogofruit for Spirit Slimes, and they cannot be saved.")
                .SetRisksTranslation("Ghostly Slimes produce Ghostly Pogofruit which, when eaten by any slime other than a Spirit Slime, will transform it into another Ghostly Slime. Angel and Demon Slimes avoid this food at all costs. If left unchecked, they can easily overtake an entire area.")
                .SetPlortonomicsTranslation("Ghostly Slimes produce no plorts, only Ghostly Pogofruit.");

            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.ANGEMON_PLORT);
            PediaRegistry.RegisterIdentifiableMapping(Ids.ANGEMON_ENTRY, Ids.ANGEMON_SLIME);
            PediaRegistry.SetPediaCategory(Ids.ANGEMON_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.ANGEMON_ENTRY)
                .SetTitleTranslation("Angemon Slime")
                .SetIntroTranslation("...what did you do?")
                .SetDietTranslation("Veggies, Meat, Supernatural")
                .SetFavoriteTranslation("Spirit Slimes")
                .SetSlimeologyTranslation("This slime was not supposed to exist. The result of a horible experiment conducted by mad Slime Scientists who have since been fired, it is the amalgamation of the Angel and Demon slimes. The most famous Slime Scientist, Viktor Humphries, commented on it, \"It is intriguing that such a thing is even possible, but I would like you to remove it from my lab.\"")
                .SetRisksTranslation("This slime, as it should not exist, is extremely unstable. If it eats the plort of either Angel or Demon slimes, it will transform them into the Angemon Plort. Additionally, it will eat the Angel and Demon Slimes and transform them into more Angemon Slimes, and transform Spirit Slimes into energy for itself.")
                .SetPlortonomicsTranslation("The plorts of this amalgamation are worthless, and so they are not worth much. As such, they are not worth selling.");
            
            PediaRegistry.RegisterIdentifiableMapping(Ids.BLURSED_ENTRY, Ids.BLURSED_SLIME);
            PediaRegistry.SetPediaCategory(Ids.BLURSED_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.BLURSED_ENTRY)
                .SetTitleTranslation("Blursed Slime")
                .SetIntroTranslation("...poor thing...")
                .SetDietTranslation("Fruit, Veggies, Meat, Supernatural")
                .SetFavoriteTranslation("Ghostly Slimes")
                .SetSlimeologyTranslation("This slime was not supposed to exist. The result of a horible encounter with an Angemon Slime, this was once a Blessed or Cursed Slime before being formed into this amalgamation.")
                .SetRisksTranslation("This slime, as it should not exist, is extremely unstable. If it eats the plort of either Angel or Demon slimes, it will dematerialize them. Additionally, it will eat the Angel, Demon, Blessed, and Cursed Slimes and transform them into more Angemon and Blursed Slimes, and transform Spirit and Ghostly Slimes into energy for itself. As if this were not enough, this slime will also produce a horrid fruit called the Amalgamango. It is the favorite food of Angemon Slimes, and also acts as a means of spreading via consumption by other slimes. Angel, Demon, and Spirit Slimes will avoid this food like the plague, which it effectively is.")
                .SetPlortonomicsTranslation("This amalgamation has no plorts; it only produces Amalgamangos.");

            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.PURIFIED_ANGEMON_PLORT);
            PediaRegistry.RegisterIdentifiableMapping(Ids.PURIFIED_ANGEMON_ENTRY, Ids.PURIFIED_ANGEMON_SLIME);
            PediaRegistry.SetPediaCategory(Ids.PURIFIED_ANGEMON_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.PURIFIED_ANGEMON_ENTRY)
                .SetTitleTranslation("Purified Angemon Slime")
                .SetIntroTranslation("...well, this is unexpected.")
                .SetDietTranslation("Veggies, Meat")
                .SetFavoriteTranslation("Blursed Pear")
                .SetSlimeologyTranslation("This slime seems to be the result of an odd energy coming into contact with an Angemon Slime. Key word, seems; we are still unsure of how exactly the process works. Research is being actively conducted on this slime to uncover more information about it.")
                .SetRisksTranslation("This slime seems to have no risks other than having regained the supernatural healing and draining effects of the Angel and Demon Slimes. It does not seem to attack either Angel or Demon Slimes, hinting at a possible desire for peace which its previous habit of corrupting either slime may have ben an attempt to accomplish.")
                .SetPlortonomicsTranslation("Due to the recent discovery of this slime, the effects of its plorts are still being researched. It is theorized that they can produce stronger miracles and disasters that Angel or Demon plorts alone, but this is yet to be tested.");

            PediaRegistry.RegisterIdentifiableMapping(Ids.PURIFIED_BLURSED_ENTRY, Ids.PURIFIED_BLURSED_SLIME);
            PediaRegistry.SetPediaCategory(Ids.PURIFIED_BLURSED_ENTRY, PediaRegistry.PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Ids.PURIFIED_BLURSED_ENTRY)
                .SetTitleTranslation("Purified Blursed Slime")
                .SetIntroTranslation("...interesting...")
                .SetDietTranslation("Fruit, Veggies, Meat")
                .SetFavoriteTranslation("None")
                .SetSlimeologyTranslation("Similar to the Purified Angemon Slime, the cause of this slime's sudden stabilization is unknown, but the two are theorized to stabilize through identical methods. Research is being actively conducted on this slime to uncover more information about it.")
                .SetRisksTranslation("This slime, due to its stabilization, has begun producing a much more appetizing fruit known as the Blursed Pear. It is similar to the other foods of supernatural origin in that it will transform any slime who eats it into another Purified Blursed Slime.")
                .SetPlortonomicsTranslation("Purified Blursed Slimes produce no plorts, only Blursed Pears.");

            PediaRegistry.RegisterIdentifiableMapping(foodIds.BLESSED_CARROT_ENTRY, foodIds.BLESSED_CARROT_VEGGIE);
            PediaRegistry.SetPediaCategory(foodIds.BLESSED_CARROT_ENTRY, PediaRegistry.PediaCategory.RESOURCES);
            SlimePediaCreation.CreateSlimePediaForItemWithName(foodIds.BLESSED_CARROT_ENTRY, foodIds.BLESSED_CARROT_VEGGIE,
                "Blessed Carrot",
                "A supernatural carrot only for the holiest of slimes.",
                "Veggie",
                "Angel Slime",
                "This is a special carrot formed through a process of transmutation that can only be done by the Blessed Slime. It carries all the nutrients needed for a supernatural slime to survive, but leaves something to be desired in terms of taste.",
                "A garden's receptor will not accept Blessed Carrots, as it is not accustomed to growing such things. This food can only be obtained from a Blessed Slime.");
            PediaRegistry.RegisterIdEntry(foodIds.BLESSED_CARROT_ENTRY, Util.CreateSprite(Util.LoadImage("BsBlessedCarrotIcon.png")));

            PediaRegistry.RegisterIdentifiableMapping(foodIds.CURSED_HEN_ENTRY, foodIds.CURSED_HEN);
            PediaRegistry.SetPediaCategory(foodIds.CURSED_HEN_ENTRY, PediaRegistry.PediaCategory.RESOURCES);
            SlimePediaCreation.CreateSlimePediaForItemWithName(foodIds.CURSED_HEN_ENTRY, foodIds.CURSED_HEN,
                "Cursed Hen",
                "A supernatural hen only safe for the unholiest slimes to consume.",
                "Meat",
                "Demon Slime",
                "This is a special hen formed through a process of transmutation that can only be done by the Cursed Slime. It is filled to the brim with unhealthy nutrients, creating an item so tasty that others can't help but to indulge in gluttony.",
                "No matter how many Roostros you place with a Cursed Hen, the former will refuse to interact with the latter. This food can only be obtained from a Cursed Slime.");
            PediaRegistry.RegisterIdEntry(foodIds.CURSED_HEN_ENTRY, Util.CreateSprite(Util.LoadImage("BsCursedHenIcon.png")));

            PediaRegistry.RegisterIdentifiableMapping(foodIds.GHOSTLY_POGO_ENTRY, foodIds.GHOSTLY_POGO_FRUIT);
            PediaRegistry.SetPediaCategory(foodIds.GHOSTLY_POGO_ENTRY, PediaRegistry.PediaCategory.RESOURCES);
            SlimePediaCreation.CreateSlimePediaForItemWithName(foodIds.GHOSTLY_POGO_ENTRY, foodIds.GHOSTLY_POGO_FRUIT,
                "Ghostly Pogofruit",
                "A supernatural pogofruit designed specifically for slimes in limbo.",
                "Fruit",
                "Spirit Slime",
                "This is a special pogofruit formed through a process of transmutation that can only be done by the Ghostly Slime. Its nutritional contents are unknown and seemingly ever-changing, but Spirit Slimes seem to love them.",
                "A garden's receptor will not accept Ghostly Pogofruits, as it is not accustomed to growing such things. This food can only be obtained from a Ghostly Slime.");
            PediaRegistry.RegisterIdEntry(foodIds.GHOSTLY_POGO_ENTRY, Util.CreateSprite(Util.LoadImage("BsGhostlyPogoIcon.png")));

            PediaRegistry.RegisterIdentifiableMapping(foodIds.AMALGAMANGO_ENTRY, foodIds.AMALGAMANGO_FRUIT);
            PediaRegistry.SetPediaCategory(foodIds.AMALGAMANGO_ENTRY, PediaRegistry.PediaCategory.RESOURCES);
            SlimePediaCreation.CreateSlimePediaForItemWithName(foodIds.AMALGAMANGO_ENTRY, foodIds.AMALGAMANGO_FRUIT,
                "Amalgamango",
                "An unappetizing abomination only fit for equally disgusting amalgamations.",
                "Fruit",
                "Angemon Slime",
                "This is a horrifying type of mango formed through a process of transmutation that can only be done by the Blursed Slime. It is gooey and disgusting, though it gives off a deceptive aroma that tempts other slimes to eat it.",
                "A garden's receptor will not accept Amalgamangoes, as well it shouldn't. This food can only be obtained from a Blursed Slime, but why would you want to?");
            PediaRegistry.RegisterIdEntry(foodIds.AMALGAMANGO_ENTRY, Util.CreateSprite(Util.LoadImage("BsAmalgamangoIcon.png")));

            PediaRegistry.RegisterIdentifiableMapping(foodIds.BLURSED_PEAR_ENTRY, foodIds.BLURSED_PEAR_FRUIT);
            PediaRegistry.SetPediaCategory(foodIds.BLURSED_PEAR_ENTRY, PediaRegistry.PediaCategory.RESOURCES);
            SlimePediaCreation.CreateSlimePediaForItemWithName(foodIds.BLURSED_PEAR_ENTRY, foodIds.BLURSED_PEAR_FRUIT,
                "Blursed Pear",
                "A supernatural pear that can only be eaten by a certain purified hybrid.",
                "Fruit",
                "Purified Angemon Slime",
                "This is a special pear formed through a process of transmutation that can only be done by the Purified Blursed Slime. It combines the nutritional value of the Blessed Carrot with the tastiness of the Cursed Hen, creating what many Slime Scientists believe to be the ultimate food item.",
                "A garden's receptor will not accept Blursed Pears, as it is not accustomed to growing such things. This food can only be obtained from a Purified Blursed Slime.");
            PediaRegistry.RegisterIdEntry(foodIds.BLURSED_PEAR_ENTRY, Util.CreateSprite(Util.LoadImage("BsAmalgamangoIcon.png")));

            PediaRegistry.SetPediaCategory(zoneIds.INBETWEEN_ENTRY, PediaRegistry.PediaCategory.WORLD);
            SlimePediaCreation.CreateZoneSlimePedia(zoneIds.INBETWEEN_ENTRY, zoneIds.INBETWEEN,
                "In-Between",
                "In-Between",
                "In-Between",
                "The grounds of a war as old as time.",
                "The In-Between is an area within a sort of pocket dimension, serving as the battleground in a war between the Angel and Demon Slimes. Oddly enough, Quantum Slimes can also be found here, seeming to get here via their teleportation abilities. The Slime Sea is absent here, replaced by a sea made entirely of souls. Such souls can be seen moving along the surface of the ocean, as well as floating throughout the air. Any object entering the Soul Sea causes a few souls to fly into the air before splashing back down again. Similarly to the Slime Sea, slimes do not actually die when falling into the Soul Sea; in fact, the Quantum Slimes seem to go back to the Ancient Ruins, while the Angel and Demon Slimes go back to Heaven and Hades, respectively. Spirit Slimes are transformed back into either Angel or Demon Slimes and sent back to the respective dimension.");
            PediaRegistry.RegisterIdEntry(zoneIds.INBETWEEN_ENTRY, Util.CreateSprite(Util.LoadImage("PinksInBetweenIcon.png")));
            ZoneDirector.zonePediaIdLookup.Add(zoneIds.INBETWEEN, zoneIds.INBETWEEN_ENTRY);
            TranslationPatcher.AddGlobalTranslation("l.presence.In-Between", "Running through the In-Between!");
        }
        public static GameObject CreateLargo(Identifiable.Id newLargoID, Identifiable.Id firstSlime, Identifiable.Id secondSlime)
        {
            SlimeRegistry.LargoProps largoProperties =
            SlimeRegistry.LargoProps.SWAP_EYES |
            SlimeRegistry.LargoProps.SWAP_MOUTH |
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
            SlimeRegistry.LargoProps.RECOLOR_SLIME1_ADDON_MATS |
            SlimeRegistry.LargoProps.REPLACE_BASE_MAT_AS_SLIME1 |
            SlimeRegistry.LargoProps.GENERATE_SECRET_STYLES |
            SlimeRegistry.LargoProps.SWAP_EYES |
            SlimeRegistry.LargoProps.SWAP_MOUTH |
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
            SlimeRegistry.LargoProps.RECOLOR_SLIME1_ADDON_MATS |
            SlimeRegistry.LargoProps.REPLACE_BASE_MAT_AS_SLIME1 |
            SlimeRegistry.LargoProps.GENERATE_NAME |
            SlimeRegistry.LargoProps.PREVENT_SLIME1_EATMAP_TRANSFORM;
            SlimeRegistry.CraftLargo(newLargoID, firstSlime, secondSlime, largoProperties, out SlimeDefinition largoDefinition, out SlimeAppearance largoAppearance, out GameObject largoObject);
            return largoObject;
        }
        public static GameObject CreateLargo2(Identifiable.Id newLargoID, Identifiable.Id firstSlime, Identifiable.Id secondSlime)
        {
            SlimeRegistry.LargoProps largoProperties =
            SlimeRegistry.LargoProps.RECOLOR_BASE_MAT_AS_SLIME2 |
            SlimeRegistry.LargoProps.RECOLOR_SLIME1_ADDON_MATS |
            SlimeRegistry.LargoProps.REPLACE_BASE_MAT_AS_SLIME1 |
            SlimeRegistry.LargoProps.GENERATE_NAME |
            SlimeRegistry.LargoProps.GENERATE_SECRET_STYLES;
            SlimeRegistry.CraftLargo(newLargoID, firstSlime, secondSlime, largoProperties, out SlimeDefinition largoDefinition, out SlimeAppearance largoAppearance, out GameObject largoObject);
            return largoObject;
        }

        internal static AssetBundle customTail = Util.LoadCustomStructure("fallangtail");
        internal static AssetBundle customHalo = Util.LoadCustomStructure("forgdemhalo");
        internal static AssetBundle customOrbs = Util.LoadCustomStructure("wandspirorbs");

        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {

            (SlimeDefinition, GameObject) ASlimeTuple = Heaven.AngelSlime();

            SlimeDefinition Angel_Slime_Definition = ASlimeTuple.Item1;
            GameObject Angel_Slime_Object = ASlimeTuple.Item2;

            LookupRegistry.RegisterIdentifiablePrefab(Angel_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Angel_Slime_Definition);

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Angel_Slime_Object);
            Sprite Aicon = Util.CreateSprite(Util.LoadImage("BsAngelIcon.png"));
            Color AngelWhite = new Color32(225, 225, 225, byte.MaxValue);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.ANGEL_SLIME, AngelWhite, Aicon));
            Angel_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.angel_slime", "Angel Slime");


            (SlimeDefinition, GameObject) DSlimeTuple = Hades.DemonSlime();

            SlimeDefinition Demon_Slime_Definition = DSlimeTuple.Item1;
            GameObject Demon_Slime_Object = DSlimeTuple.Item2;

            LookupRegistry.RegisterIdentifiablePrefab(Demon_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Demon_Slime_Definition);

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Demon_Slime_Object);
            Sprite Dicon = Util.CreateSprite(Util.LoadImage("BsDemonIcon.png"));
            Color DemonBlack = new Color32(25, 25, 25, byte.MaxValue);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.DEMON_SLIME, DemonBlack, Dicon));
            Demon_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.demon_slime", "Demon Slime");


            (SlimeDefinition, GameObject) SSlimeTuple = InBetween.SpiritSlime();

            SlimeDefinition Spirit_Slime_Definition = SSlimeTuple.Item1;
            GameObject Spirit_Slime_Object = SSlimeTuple.Item2;

            LookupRegistry.RegisterIdentifiablePrefab(Spirit_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Spirit_Slime_Definition);

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Spirit_Slime_Object);
            Sprite Sicon = Util.CreateSprite(Util.LoadImage("BsSpiritIcon.png"));
            Color SpiritGrey = new Color32(125, 125, 125, byte.MaxValue);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.SPIRIT_SLIME, SpiritGrey, Sicon));
            Spirit_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.spirit_slime", "Spirit Slime");


            (SlimeDefinition, GameObject) CSlimeTuple = Hades.CursedSlime();

            SlimeDefinition Cursed_Slime_Definition = CSlimeTuple.Item1;
            GameObject Cursed_Slime_Object = CSlimeTuple.Item2;

            LookupRegistry.RegisterIdentifiablePrefab(Cursed_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Cursed_Slime_Definition);

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Cursed_Slime_Object);
            Sprite Cicon = Util.CreateSprite(Util.LoadImage("BsCursedIcon.png"));
            Color CursedRed = new Color32(225, 25, 25, byte.MaxValue);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.CURSED_SLIME, CursedRed, Cicon));
            Demon_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.cursed_slime", "Cursed Slime");


            (SlimeDefinition, GameObject) BSlimeTuple = Heaven.BlessedSlime();

            SlimeDefinition Blessed_Slime_Definition = BSlimeTuple.Item1;
            GameObject Blessed_Slime_Object = BSlimeTuple.Item2;

            LookupRegistry.RegisterIdentifiablePrefab(Blessed_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Blessed_Slime_Definition);

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Blessed_Slime_Object);
            Sprite Bicon = Util.CreateSprite(Util.LoadImage("BsBlessedIcon.png"));
            Color BlessedYellow = new Color32(212, 175, 55, byte.MaxValue);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.BLESSED_SLIME, BlessedYellow, Bicon));
            Blessed_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.blessed_slime", "Blessed Slime");


            (SlimeDefinition, GameObject) GSlimeTuple = InBetween.GhostlySlime();

            SlimeDefinition Ghostly_Slime_Definition = GSlimeTuple.Item1;
            GameObject Ghostly_Slime_Object = GSlimeTuple.Item2;

            LookupRegistry.RegisterIdentifiablePrefab(Ghostly_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Ghostly_Slime_Definition);

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Ghostly_Slime_Object);
            Sprite Gicon = Util.CreateSprite(Util.LoadImage("BsGhostlyIcon.png"));
            Color GhostlyGrey = new Color32(125, 125, 125, byte.MaxValue);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.GHOSTLY_SLIME, GhostlyGrey, Gicon));
            Ghostly_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.ghostly_slime", "Ghostly Slime");

            Amalgamation.AngemonSlime();
            Amalgamation.BlursedSlime();
            Purified.PAngemonSlime();
            Purified.PBlursedSlime();


            var SpiritAngel = CreateLargo(largoIds.SPIRIT_ANGEL_LARGO, Ids.SPIRIT_SLIME, Ids.ANGEL_SLIME);
            SpiritAngel.RemoveComponent<SpiritHealOrDrain>();
            SpiritAngel.transform.Find("AngelHealSource(Clone)").gameObject.AddComponent<SpiritHealOrDrainAura>().health = 1;

            var SpiritDemon = CreateLargo(largoIds.SPIRIT_DEMON_LARGO, Ids.SPIRIT_SLIME, Ids.DEMON_SLIME);

            var GhostlyBlessed = CreateLargo2(largoIds.GHOSTLY_BLESSED_LARGO, Ids.GHOSTLY_SLIME, Ids.BLESSED_SLIME);

            var GhostlyCursed = CreateLargo2(largoIds.GHOSTLY_CURSED_LARGO, Ids.GHOSTLY_SLIME, Ids.CURSED_SLIME);

            
            GameObject AngelPlortTuple = Plorts.AngelPlort();
            GameObject AngelPlortObject = AngelPlortTuple;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, AngelPlortObject);
            Sprite APlortIcon = Util.CreateSprite(Util.LoadImage("BsAngelPlortIcon.png"));   
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.ANGEL_PLORT, AngelWhite, APlortIcon));
            AmmoRegistry.RegisterSiloAmmo((System.Predicate<SiloStorage.StorageType>)(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT), Ids.ANGEL_PLORT);

            float Aprice = 95f; //Starting price for plort   
            float Asaturation = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(Ids.ANGEL_PLORT, Aprice, Asaturation); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(Ids.ANGEL_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(Ids.ANGEL_PLORT);
            AmmoRegistry.RegisterRefineryResource(Ids.ANGEL_PLORT); //For if you want to make a gadget that uses it  


            GameObject DemonPlortTuple = Plorts.DemonPlort();
            GameObject DemonPlortObject = DemonPlortTuple;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, DemonPlortObject);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite DPlortIcon = Util.CreateSprite(Util.LoadImage("BsDemonPlortIcon.png"));   
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.DEMON_PLORT, DemonBlack, DPlortIcon));
            AmmoRegistry.RegisterSiloAmmo((System.Predicate<SiloStorage.StorageType>)(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT), Ids.DEMON_PLORT);

            float Dprice = 95f; //Starting price for plort   
            float Dsaturation = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(Ids.DEMON_PLORT, Dprice, Dsaturation); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(Ids.DEMON_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(Ids.DEMON_PLORT);
            AmmoRegistry.RegisterRefineryResource(Ids.DEMON_PLORT); //For if you want to make a gadget that uses it


            GameObject SpiritPlortTuple = Plorts.SpiritPlort();
            GameObject SpiritPlortObject = SpiritPlortTuple;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, SpiritPlortObject);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite SPlortIcon = Util.CreateSprite(Util.LoadImage("BsSpiritPlortIcon.png"));
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.SPIRIT_PLORT, SpiritGrey, SPlortIcon));
            AmmoRegistry.RegisterSiloAmmo((System.Predicate<SiloStorage.StorageType>)(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT), Ids.SPIRIT_PLORT);

            float Sprice = 142f; //Starting price for plort   
            float Ssaturation = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(Ids.SPIRIT_PLORT, Sprice, Ssaturation); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(Ids.SPIRIT_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(Ids.SPIRIT_PLORT);
            AmmoRegistry.RegisterRefineryResource(Ids.SPIRIT_PLORT); //For if you want to make a gadget that uses it

            GameObject HenHenPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.HEN));
            HenHenPrefab.name = "Cursed Hen";
            SkinnedMeshRenderer mRender = HenHenPrefab.transform.Find("Hen Hen/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>();
            Material HenMat = UnityEngine.Object.Instantiate<Material>(mRender.sharedMaterial);
            HenMat.SetTexture("_RampGreen", Util.LoadRamp("ramp_cursedhen_red.png"));
            HenMat.SetTexture("_RampRed", Util.LoadRamp("ramp_cursedhen_beak.png"));
            HenMat.SetTexture("_RampBlue", Util.LoadRamp("ramp_cursedhen_whitey.png"));
            HenMat.SetTexture("_RampBlack", Util.LoadRamp("ramp_cursedhen_whitey.png"));
            mRender.sharedMaterial = HenMat;
            HenHenPrefab.GetComponent<Identifiable>().id = foodIds.CURSED_HEN;
            HenHenPrefab.transform.Find("Hen Hen/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = HenMat;
            LookupRegistry.RegisterIdentifiablePrefab(HenHenPrefab);
            CropCreation.LoadCrop(foodIds.CURSED_HEN, HenHenPrefab, false, false, false, true);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, HenHenPrefab, foodIds.CURSED_HEN, "Cursed Hen", Util.CreateSprite(Util.LoadImage("BsCursedHenIcon.png")), new Color32(125, 125, 125, 255));
            TranslationPatcher.AddActorTranslation("l.cursed_hen", "Cursed Hen");
            DroneRegistry.RegisterBasicTarget(foodIds.CURSED_HEN);

            var blessedCarrotVeggie = CropCreation.CreateCropNoFModel(foodIds.BLESSED_CARROT_VEGGIE, "Blessed Carrot", Identifiable.Id.CARROT_VEGGIE, CropCreation.CreateCropMaterial(Identifiable.Id.CARROT_VEGGIE, Util.LoadRamp("veggieBlessedCarrot_ramp_dirt.png"), Util.LoadRamp("veggieBlessedCarrot_ramp_orange.png"), Util.LoadRamp("veggieBlessedCarrot_ramp_green.png"), Util.LoadRamp("veggieBlessedCarrot_ramp_orange.png")), new Vector3(1.75f, 1.75f, 1.75f), new Vector3(1.5f, 1.5f, 1.5f));
            var ghostlyPogoFruit = CropCreation.CreateCropNoFModel(foodIds.GHOSTLY_POGO_FRUIT, "Ghostly Pogofruit", Identifiable.Id.POGO_FRUIT, CropCreation.CreateCropMaterial(Identifiable.Id.POGO_FRUIT, Util.LoadRamp("fruitGhostlyPogo_ramp_red.png"), Util.LoadRamp("fruitGhostlyPogo_ramp_green.png"), Util.LoadRamp("fruitGhostlyPogo_ramp_red.png"), Util.LoadRamp("fruitGhostlyPogo_ramp_orange.png")), new Vector3(0.25f, 0.25f, 0.25f), new Vector3(1.5f, 1.5f, 1.5f));
            var amalgaMangoFruit = CropCreation.CreateCropNoFModel(foodIds.AMALGAMANGO_FRUIT, "Amalgamango", Identifiable.Id.MANGO_FRUIT, CropCreation.CreateCropMaterial(Identifiable.Id.MANGO_FRUIT, Util.LoadRamp("fruitAmalgamango_ramp_white.png"), Util.LoadRamp("fruitAmalgamango_ramp_white.png"), Util.LoadRamp("fruitAmalgamango_ramp_dgreen.png"), Util.LoadRamp("fruitAmalgamango_ramp_lgreen.png")), new Vector3(0.25f, 0.25f, 0.25f), new Vector3(1.5f, 1.5f, 1.5f));
            var blursedPearFruit = CropCreation.CreateCropNoFModel(foodIds.BLURSED_PEAR_FRUIT, "Blursed Pear", Identifiable.Id.PEAR_FRUIT, CropCreation.CreateCropMaterial(Identifiable.Id.PEAR_FRUIT, Util.LoadRamp("fruitBlursedPear_ramp_purple.png"), Util.LoadRamp("fruitBlursedPear_ramp_green.png"), Util.LoadRamp("fruitBlursedPear_ramp_green.png"), Util.LoadRamp("fruitBlursedPear_ramp_purple.png")), new Vector3(0.25f, 0.25f, 0.25f), new Vector3(1.5f, 1.5f, 1.5f));
            CropCreation.LoadCrop(foodIds.BLESSED_CARROT_VEGGIE, blessedCarrotVeggie, false, true, false);
            CropCreation.LoadCrop(foodIds.GHOSTLY_POGO_FRUIT, ghostlyPogoFruit, false, false, true);
            CropCreation.LoadCrop(foodIds.AMALGAMANGO_FRUIT, amalgaMangoFruit, false, false, true);
            CropCreation.LoadCrop(foodIds.BLURSED_PEAR_FRUIT, blursedPearFruit, false, false, true);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, blessedCarrotVeggie, foodIds.BLESSED_CARROT_VEGGIE, "Blessed Carrot", Util.CreateSprite(Util.LoadImage("BsBlessedCarrotIcon.png")), Color.yellow);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, ghostlyPogoFruit, foodIds.GHOSTLY_POGO_FRUIT, "Ghostly Pogofruit", Util.CreateSprite(Util.LoadImage("BsGhostlyPogoIcon.png")), Color.cyan);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, amalgaMangoFruit, foodIds.AMALGAMANGO_FRUIT, "Amalgamango", Util.CreateSprite(Util.LoadImage("BsAmalgamangoIcon.png")), Color.gray);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, blursedPearFruit, foodIds.BLURSED_PEAR_FRUIT, "Blursed Pear", Util.CreateSprite(Util.LoadImage("BsAmalgamangoIcon.png")), new Color32(125, 0, 255, 255));
            DroneRegistry.RegisterBasicTarget(foodIds.BLESSED_CARROT_VEGGIE);
            DroneRegistry.RegisterBasicTarget(foodIds.GHOSTLY_POGO_FRUIT);
            DroneRegistry.RegisterBasicTarget(foodIds.AMALGAMANGO_FRUIT);
            DroneRegistry.RegisterBasicTarget(foodIds.BLURSED_PEAR_FRUIT);

            //angelSS
            SlimeDefinition angelSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.ANGEL_SLIME);
            GameObject fallenSlimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.ANGEL_SLIME));
            SlimeDefinition faSlimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME);
            SlimeDefinition faSlimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.QUICKSILVER_SLIME);
            SlimeAppearance fallenAngel = Style.CreateStyleAppearance(Ids.ANGEL_SLIME, Slime.GetSlimeDef(Ids.ANGEL_SLIME), "Fallen Angel");
            fallenAngel.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(fallenAngel.Structures[0]),
                new SlimeAppearanceStructure(faSlimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(faSlimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
            };
            SlimeAppearanceStructure[] fallenStructures = fallenAngel.Structures;
            SlimeAppearance.SlimeBone[] tailAttachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };
            (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) tailStructure = Structure.CreateBasicStructure(customTail, "tailangel", "slime_tail", SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, tailAttachedBones, RubberBoneEffect.RubberType.Slime);
            AssetsLib.MeshUtils.GenerateBoneData(fallenSlimeObject.GetComponent<SlimeAppearanceApplicator>(), tailStructure.Item2, 0.25f);
            Structure.SetStructureElement("slimeTail", fallenAngel, new SlimeAppearanceObject[] { tailStructure.Item2 }, 3, true, false);
            Material faMaterial = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            faMaterial.SetColor("_TopColor", new Color32(64, 0, 130, 255));
            faMaterial.SetColor("_MiddleColor", new Color32(70, 13, 53, 255));
            faMaterial.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            faMaterial.SetFloat("_Shininess", 1f);
            faMaterial.SetFloat("_Gloss", 1f);
            fallenStructures[0].DefaultMaterials[0] = faMaterial;
            Material faMaterial2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            faMaterial2.SetColor("_MiddleColor", new Color32(64, 0, 130, 255));
            faMaterial2.SetColor("_EdgeColor", new Color32(3, 3, 3, 255));
            fallenStructures[1].DefaultMaterials[0] = faMaterial2;
            Material faMaterial3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            faMaterial3.SetColor("_TopColor", new Color32(64, 0, 130, 255));
            faMaterial3.SetColor("_MiddleColor", new Color32(70, 13, 53, 255));
            faMaterial3.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            fallenStructures[2].DefaultMaterials[0] = faMaterial3;
            fallenAngel.Structures[3].DefaultMaterials[0] = faMaterial3;
            SlimeExpressionFace[] angelSSExpressionFaces = fallenAngel.Face.ExpressionFaces;
            for (int k = 0; k < angelSSExpressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = angelSSExpressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(152, 0, 0, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(152, 0, 0, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(152, 0, 0, 255));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(152, 0, 0, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(152, 0, 0, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(152, 0, 0, 255));
                }
            }
            fallenAngel.Face.OnEnable();
            fallenAngel.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(25, 25, 25, 255),
                Middle = new Color32(25, 25, 25, 255),
                Bottom = new Color32(25, 25, 25, 255),
                Ammo = new Color32(25, 25, 25, 255)
            };
            fallenAngel.Icon = Util.CreateSprite(Util.LoadImage("BsAngelIconSS.png"));
            fallenSlimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = fallenAngel;
            Style.CreateCosmetic("fallenangelPod", "zoneREEF/cellReef_GordoIsland/Sector/Loot/treasurePodCosmetic", "zoneMOSS/cellMoss_GreenPillars/Sector/Loot", new Vector3(-75.8f, 22.6f, 415.7f), fallenAngel, Slime.GetSlimeDef(Ids.ANGEL_SLIME));

            //demonSS
            SlimeDefinition demonSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.DEMON_SLIME);
            GameObject forgivenSlimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.DEMON_SLIME));
            SlimeDefinition forgivenSlimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(demonSlimeDefinition);
            SlimeDefinition foSlimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.FIRE_SLIME);
            SlimeDefinition foSlimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME);
            SlimeAppearance forgivenDemon = Style.CreateStyleAppearance(Ids.DEMON_SLIME, Slime.GetSlimeDef(Ids.DEMON_SLIME), "Forgiven Demon");
            forgivenDemon.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(forgivenDemon.Structures[0]),
                new SlimeAppearanceStructure(foSlimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(foSlimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
            };
            SlimeAppearanceElement foSlimeElem = ScriptableObject.CreateInstance<SlimeAppearanceElement>();
            foSlimeElem.name = "ForgivenFlames";
            foSlimeElem.Name = "ForgivenFlames";
            List<SlimeAppearanceObject> foSlimeAppObjList = new List<SlimeAppearanceObject>();
            GameObject foSlimeFireObj = PrefabUtils.CopyPrefab(foSlimeByIdentifiableId.AppearancesDefault[0].Structures[1].Element.Prefabs[0].gameObject);
            foSlimeFireObj.name = "forgiven_flames";
            forgivenSlimeDefinition.AppearancesDefault[0] = forgivenDemon;
            SlimeAppearanceStructure[] forgivenStructures = forgivenDemon.Structures;
            SlimeAppearance.SlimeBone[] haloAttachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };
            (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) haloStructure = Structure.CreateBasicStructure(customHalo, "bhalodemon", "slime_bhalo", SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, haloAttachedBones, RubberBoneEffect.RubberType.Slime);
            AssetsLib.MeshUtils.GenerateBoneData(forgivenSlimeObject.GetComponent<SlimeAppearanceApplicator>(), haloStructure.Item2, 0.5f);
            Structure.SetStructureElement("slimebHalo", forgivenDemon, new SlimeAppearanceObject[] { haloStructure.Item2 }, 3, true, false);
            Material foMaterial = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            foMaterial.SetColor("_TopColor", new Color32(255, 20, 147, 255));
            foMaterial.SetColor("_MiddleColor", new Color32(240, 123, 186, 255));
            foMaterial.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            foMaterial.SetFloat("_Shininess", 1f);
            foMaterial.SetFloat("_Gloss", 1f);
            forgivenStructures[0].DefaultMaterials[0] = foMaterial;
            Material foMaterial2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            foMaterial2.SetColor("_TopColor", new Color32(255, 20, 147, 255));
            foMaterial2.SetColor("_MiddleColor", new Color32(240, 123, 186, 255));
            foMaterial2.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            forgivenStructures[2].DefaultMaterials[0] = foMaterial2;
            forgivenDemon.Structures[3].DefaultMaterials[0] = foMaterial2;
            Material foMaterial3 = foSlimeFireObj.GetComponentInChildren<MeshRenderer>().sharedMaterial.Instantiate(false);//UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.ROCK_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            foMaterial3.SetColor("_ColorOutside", new Color32(255, 20, 147, 255));
            foMaterial3.SetColor("_ColorInside", new Color32(225, 225, 225, 255));
            foSlimeFireObj.GetComponentInChildren<MeshRenderer>().sharedMaterial = foMaterial3;
            foSlimeAppObjList.Add(foSlimeFireObj.GetComponent<SlimeAppearanceObject>());
            foSlimeElem.Prefabs = foSlimeAppObjList.ToArray();
            forgivenStructures[1].Element = foSlimeElem;
            //forgivenStructures[1].DefaultMaterials[0] = foMaterial3;
            SlimeExpressionFace[] demonSSExpressionFaces = forgivenDemon.Face.ExpressionFaces;
            for (int k = 0; k < demonSSExpressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = demonSSExpressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(135, 206, 235, 255));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(135, 206, 235, 255));
                }
            }
            forgivenDemon.Face.OnEnable();
            forgivenDemon.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(225, 225, 225, 255),
                Middle = new Color32(225, 225, 225, 255),
                Bottom = new Color32(225, 225, 225, 255),
                Ammo = new Color32(225, 225, 225, 255)
            };
            forgivenDemon.Icon = Util.CreateSprite(Util.LoadImage("BsDemonIconSS.png"));
            forgivenSlimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = forgivenDemon;
            Style.CreateCosmetic("forgivenDemonPod", "zoneREEF/cellReef_GordoIsland/Sector/Loot/treasurePodCosmetic", "zoneDESERT/cellDesert_WaystationTempleEndOutside/Sector/Loot", new Vector3(112.3f, 1057.3f, 770.7f), forgivenDemon, Slime.GetSlimeDef(Ids.DEMON_SLIME));

            //spiritSS
            SlimeDefinition spiritSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.SPIRIT_SLIME);
            GameObject wanderingSlimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.SPIRIT_SLIME));
            SlimeDefinition waSlimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.MOSAIC_SLIME);
            SlimeDefinition waSlimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TANGLE_SLIME);
            SlimeAppearance wanderingSpirit = Style.CreateStyleAppearance(Ids.SPIRIT_SLIME, Slime.GetSlimeDef(Ids.SPIRIT_SLIME), "Wandering Spirit");
            wanderingSpirit.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(wanderingSpirit.Structures[0]),
                new SlimeAppearanceStructure(waSlimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(waSlimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
            };
            SlimeAppearanceStructure[] wanderingStructures = wanderingSpirit.Structures;
            SlimeAppearance.SlimeBone[] orbAttachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };
            (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) fallAngOrbStructure = Structure.CreateBasicStructure(customOrbs, "falangorbspirit", "slime_falangorb", SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, orbAttachedBones, RubberBoneEffect.RubberType.Slime, true, true);
            fallAngOrbStructure.Item1.AddComponent<vp_Spin>();
            Structure.SetStructureElement("slimeOrbFalAng", wanderingSpirit, new SlimeAppearanceObject[] { fallAngOrbStructure.Item2 }, 3, true, false);
            (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) forgDemOrbStructure = Structure.CreateBasicStructure(customOrbs, "forgdemorbspirit1", "slime_forgdemorb", SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, orbAttachedBones, RubberBoneEffect.RubberType.Slime, true, true);
            forgDemOrbStructure.Item1.AddComponent<vp_Spin>();
            Structure.SetStructureElement("slimeOrbForgDem", wanderingSpirit, new SlimeAppearanceObject[] { forgDemOrbStructure.Item2 }, 4, true, false);
            Material waMaterial = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.QUANTUM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            waMaterial.SetColor("_TopColor", new Color32(62, 180, 137, 255));//0, 174, 239
            waMaterial.SetColor("_MiddleColor", new Color32(31, 177, 188, 255));
            waMaterial.SetColor("_BottomColor", new Color32(0, 174, 239, 255));//62, 180, 137
            waMaterial.SetFloat("_Shininess", 1f);
            waMaterial.SetFloat("_Gloss", 1f);
            wanderingStructures[0].DefaultMaterials[0] = waMaterial;
            Material waMaterial2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            waMaterial2.SetColor("_MiddleColor", new Color32(31, 177, 188, 255));
            waMaterial2.SetColor("_EdgeColor", new Color32(3, 18, 20, 255));
            wanderingStructures[1].DefaultMaterials[0] = waMaterial2;
            Material waMaterial3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.QUANTUM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            waMaterial3.SetColor("_TopColor", new Color32(62, 180, 137, 255));
            waMaterial3.SetColor("_MiddleColor", new Color32(31, 177, 188, 255));
            waMaterial3.SetColor("_BottomColor", new Color32(0, 174, 239, 255));
            wanderingStructures[2].DefaultMaterials[0] = waMaterial3;
            Material waMaterial4 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            waMaterial4.SetColor("_TopColor", new Color32(64, 0, 130, 255));
            waMaterial4.SetColor("_MiddleColor", new Color32(70, 13, 53, 255));
            waMaterial4.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            wanderingSpirit.Structures[3].DefaultMaterials[0] = waMaterial4;
            Material waMaterial5 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            waMaterial5.SetColor("_TopColor", new Color32(255, 20, 147, 255));
            waMaterial5.SetColor("_MiddleColor", new Color32(240, 123, 186, 255));
            waMaterial5.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            wanderingSpirit.Structures[4].DefaultMaterials[0] = waMaterial5;
            SlimeExpressionFace[] spiritSSExpressionFaces = wanderingSpirit.Face.ExpressionFaces;
            for (int k = 0; k < spiritSSExpressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = spiritSSExpressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(102, 0, 0, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(102, 0, 0, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(102, 0, 0, 255));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(135, 206, 235, 255));
                }
            }
            wanderingSpirit.Face.OnEnable();
            wanderingSpirit.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(125, 125, 125, 255),
                Middle = new Color32(125, 125, 125, 255),
                Bottom = new Color32(125, 125, 125, 255),
                Ammo = new Color32(125, 125, 125, 255)
            };
            wanderingSpirit.Icon = Util.CreateSprite(Util.LoadImage("BsSpiritIconSS.png"));
            wanderingSlimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = wanderingSpirit;
            Style.CreateCosmetic("wanderingSpiritPod", "zoneREEF/cellReef_GordoIsland/Sector/Loot/treasurePodCosmetic", "zoneRUINS/cellRuins_WaystationTemple/Sector/Loot", new Vector3(43.5f, -4.6f, 1051f), wanderingSpirit, Slime.GetSlimeDef(Ids.SPIRIT_SLIME));


            Color[] angelDark = new Color[]
            {
                Shortcut.Other.LoadHex("#E1E1E1"),
                Shortcut.Other.LoadHex("#87CEEB"),
                Shortcut.Other.LoadHex("#D4AF37"),
                Shortcut.Other.LoadHex("#D4AF37"),
                Shortcut.Other.LoadHex("#E1E1E1"),
                Shortcut.Other.LoadHex("#87CEEB"),
                Shortcut.Other.LoadHex("#D4AF37"),
                Shortcut.Other.LoadHex("#D4AF37")
            };
            Color[] angelLight = new Color[]
            {
                Shortcut.Other.LoadHex("#E1E1E1"),
                Shortcut.Other.LoadHex("#87CEEB"),
                Shortcut.Other.LoadHex("#D4AF37"),
                Shortcut.Other.LoadHex("#D4AF37"),
                Shortcut.Other.LoadHex("#E1E1E1"),
                Shortcut.Other.LoadHex("#87CEEB"),
                Shortcut.Other.LoadHex("#D4AF37"),
                Shortcut.Other.LoadHex("#D4AF37")
            };
            Shortcut.Other.CreateChroma(Util.CreateSprite(Util.LoadImage("BsAngelIcon.png")), chromaIds.ANGEL_CHROMA, "Heavenly Ranch", angelDark, angelLight);

            Color[] demonDark = new Color[]
            {
                Shortcut.Other.LoadHex("#191919"),
                Shortcut.Other.LoadHex("#660000"),
                Shortcut.Other.LoadHex("#E11919"),
                Shortcut.Other.LoadHex("#E11919"),
                Shortcut.Other.LoadHex("#191919"),
                Shortcut.Other.LoadHex("#660000"),
                Shortcut.Other.LoadHex("#E11919"),
                Shortcut.Other.LoadHex("#E11919")
            };
            Color[] demonLight = new Color[]
            {
                Shortcut.Other.LoadHex("#191919"),
                Shortcut.Other.LoadHex("#660000"),
                Shortcut.Other.LoadHex("#E11919"),
                Shortcut.Other.LoadHex("#E11919"),
                Shortcut.Other.LoadHex("#191919"),
                Shortcut.Other.LoadHex("#660000"),
                Shortcut.Other.LoadHex("#E11919"),
                Shortcut.Other.LoadHex("#E11919")
            };
            Shortcut.Other.CreateChroma(Util.CreateSprite(Util.LoadImage("BsDemonIcon.png")), chromaIds.DEMON_CHROMA, "Hades' Ranch", demonDark, demonLight);

            //angemonSS
            SlimeDefinition angemonSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.ANGEMON_SLIME);
            GameObject taSlimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.ANGEMON_SLIME));
            SlimeAppearance trueAngemon = Style.CreateStyleAppearance(Ids.ANGEMON_SLIME, Slime.GetSlimeDef(Ids.ANGEMON_SLIME), "True Angemon");
            SlimeAppearanceStructure[] taStructures = trueAngemon.Structures;
            Material taMaterial = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TARR_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            taStructures[0].DefaultMaterials[0] = taMaterial;
            taStructures[1].DefaultMaterials[0] = taMaterial;
            taStructures[2].DefaultMaterials[0] = taMaterial;
            taStructures[3].DefaultMaterials[0] = taMaterial;
            taStructures[4].DefaultMaterials[0] = taMaterial;
            SlimeExpressionFace[] angemonSSExpressionFaces = trueAngemon.Face.ExpressionFaces;
            for (int k = 0; k < angemonSSExpressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = angemonSSExpressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(225, 225, 225, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(225, 225, 225, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(225, 225, 225, 255));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(225, 225, 225, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(225, 225, 225, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(225, 225, 225, 255));
                }
            }
            trueAngemon.Face.OnEnable();
            trueAngemon.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(25, 25, 25, 255),
                Middle = new Color32(25, 25, 25, 255),
                Bottom = new Color32(25, 25, 25, 255),
                Ammo = new Color32(25, 25, 25, 255)
            };
            trueAngemon.Icon = Util.CreateSprite(Util.LoadImage("BsAngemonIcon.png")); 
            //Ask B to make a new icon
            taSlimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = trueAngemon;
            Style.CreateCosmetic("trueAngemonPod", "zoneREEF/cellReef_GordoIsland/Sector/Loot/treasurePodCosmetic", "zoneRANCH/cellRanch_Lab/Sector/Loot", new Vector3(167.7f, 28.0f, -340.1f), trueAngemon, Slime.GetSlimeDef(Ids.ANGEMON_SLIME));

            
            Material AEI = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            AEI.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            AEI.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
            AEI.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            Material AEO = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            AEO.SetColor("_TopColor", new Color32(135, 206, 235, 255));
            AEO.SetColor("_MiddleColor", new Color32(135, 206, 235, 255));
            AEO.SetColor("_BottomColor", new Color32(135, 206, 235, 255));
            Shortcut.Resource.CreateBottledResource(Identifiable.Id.DEEP_BRINE_CRAFT, resourceIds.ANGEL_ESSENCE, "Angel Essence", Util.CreateSprite(Util.LoadImage("BsAngelEssenceIcon.png")), AEO, AEI, new Color32(135, 206, 235, 255));

            Material DEI = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            DEI.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            DEI.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            DEI.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            Material DEO = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            DEO.SetColor("_TopColor", new Color32(102, 0, 0, 255));
            DEO.SetColor("_MiddleColor", new Color32(102, 0, 0, 255));
            DEO.SetColor("_BottomColor", new Color32(102, 0, 0, 255));
            Shortcut.Resource.CreateBottledResource(Identifiable.Id.DEEP_BRINE_CRAFT, resourceIds.DEMON_ESSENCE, "Demon Essence", Util.CreateSprite(Util.LoadImage("BsDemonEssenceIcon.png")), DEO, DEI, new Color32(102, 0, 0, 255));

            Material SEI = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.QUANTUM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            SEI.SetColor("_TopColor", new Color32(25, 25, 25, 255));
            SEI.SetColor("_MiddleColor", new Color32(125, 125, 125, 255));
            SEI.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            Material SEO = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            SEO.SetColor("_TopColor", new Color32(118, 103, 118, 255));
            SEO.SetColor("_MiddleColor", new Color32(102, 0, 0, 255));
            SEO.SetColor("_BottomColor", new Color32(135, 206, 235, 255));
            Shortcut.Resource.CreateBottledResource(Identifiable.Id.DEEP_BRINE_CRAFT, resourceIds.SPIRIT_ESSENCE, "Spirit Essence", Util.CreateSprite(Util.LoadImage("BsSpiritEssenceIcon.png")), SEO, SEI, new Color32(118, 103, 118, 255));
            
            Material BEI = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            BEI.SetColor("_TopColor", new Color32(159, 212, 127, 255));
            BEI.SetColor("_MiddleColor", new Color32(255, 172, 75, 255));
            BEI.SetColor("_BottomColor", new Color32(148, 101, 74, 255));
            Material BEO = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            BEO.SetColor("_TopColor", new Color32(218, 200, 140, 255));
            BEO.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
            BEO.SetColor("_BottomColor", new Color32(218, 200, 140, 255));
            Shortcut.Resource.CreateBottledResource(Identifiable.Id.DEEP_BRINE_CRAFT, resourceIds.BLESSED_ESSENCE, "Blessed Essence", Util.CreateSprite(Util.LoadImage("BsBlessedEssenceIcon.png")), BEO, BEI, new Color32(135, 206, 235, 255));

            Material CEI = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            CEI.SetColor("_TopColor", new Color32(150, 50, 50, 255));
            CEI.SetColor("_MiddleColor", new Color32(110, 106, 99, 255));
            CEI.SetColor("_BottomColor", new Color32(185, 135, 62, 255));
            Material CEO = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            CEO.SetColor("_TopColor", new Color32(125, 25, 25, 255));
            CEO.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            CEO.SetColor("_BottomColor", new Color32(125, 25, 25, 255));
            Shortcut.Resource.CreateBottledResource(Identifiable.Id.DEEP_BRINE_CRAFT, resourceIds.CURSED_ESSENCE, "Cursed Essence", Util.CreateSprite(Util.LoadImage("BsCursedEssenceIcon.png")), CEO, CEI, new Color32(102, 0, 0, 255));

            Material GEI = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            GEI.SetColor("_TopColor", new Color32(239, 160, 156, 255));
            GEI.SetColor("_MiddleColor", new Color32(41, 221, 245, 255));
            GEI.SetColor("_BottomColor", new Color32(24, 141, 210, 255));
            Material GEO = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.QUANTUM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            GEO.SetColor("_TopColor", new Color32(125, 125, 125, 255));
            GEO.SetColor("_MiddleColor", new Color32(125, 125, 125, 255));
            GEO.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            Shortcut.Resource.CreateBottledResource(Identifiable.Id.DEEP_BRINE_CRAFT, resourceIds.GHOSTLY_ESSENCE, "Ghostly Essence", Util.CreateSprite(Util.LoadImage("BsGhostlyEssenceIcon.png")), GEO, GEI, new Color32(118, 103, 118, 255));


            GadgetDefinition.CraftCost[] ADCCC = new GadgetDefinition.CraftCost[]
            {
                new GadgetDefinition.CraftCost
                {
                    id = resourceIds.ANGEL_ESSENCE,
                    amount = 1,
                },
                new GadgetDefinition.CraftCost
                {
                    id = resourceIds.DEMON_ESSENCE,
                    amount = 1,
                },
                new GadgetDefinition.CraftCost
                {
                    id = resourceIds.SPIRIT_ESSENCE,
                    amount = 1,
                },
            };
            Extractor.ProduceEntry[] ADCPE = new Extractor.ProduceEntry[]
            {
                new Extractor.ProduceEntry
                {
                    id = Ids.ANGEMON_SLIME,
                    weight = 1f,
                },
            };
            Resource.CreateExtractor(Gadget.Id.EXTRACTOR_PUMP_ABYSSAL, gadgetIds.ANGEL_DEMON_COMBINER, "Angel-Demon Combiner", Util.CreateSprite(Util.LoadImage("BsSpiritIcon.png")), "Combines the Angel and Demon slimes using the essence of both, as well as the essence of a Spirit slime.", 95, 999, ADCCC, ADCPE, ProgressDirector.ProgressType.UNLOCK_DESERT, 24f, 1, 1, 1, 168f, false); 
            //Ask B to make a new icon
            Color32[] ADCEC1 = new Color32[]
            {
                new Color32(225, 225, 225, 255),
                new Color32(196, 196, 196, 255),
                new Color32(168, 168, 168, 255),
                new Color32(139, 139, 139, 255),
                new Color32(111, 111, 111, 255),
                new Color32(82, 82, 82, 255),
                new Color32(54, 54, 54, 255),
                new Color32(25, 25, 25, 255),
            };
            Color32[] ADCMC = new Color32[]
            {
                new Color32(212, 175, 55, 255),
                new Color32(214, 182, 79, 255),
                new Color32(216, 189, 104, 255),
                new Color32(218, 196, 128, 255),
                new Color32(219, 204, 152, 255),
                new Color32(221, 211, 176, 255),
                new Color32(223, 218, 201, 255),
                new Color32(225, 225, 225, 255),
            };
            Color32[] ADCEC2 = new Color32[]
            {
                new Color32(225, 25, 25, 255),
                new Color32(196, 25, 25, 255),
                new Color32(168, 25, 25, 255),
                new Color32(139, 25, 25, 255),
                new Color32(111, 25, 25, 255),
                new Color32(82, 25, 25, 255),
                new Color32(54, 25, 25, 255),
                new Color32(25, 25, 25, 255),
            };
            Resource.ColorExtractor(gadgetIds.ANGEL_DEMON_COMBINER, ADCMC, ADCEC1, ADCEC2, 2, false, true, false);

            SRML.Console.Console.RegisterCommand(new SpiritMode());
            SRML.Console.Console.RegisterCommand(new SpiritRandom());
            SRML.Console.Console.RegisterCommand(new AbilityGiving());

            /*TranslationPatcher.AddActorTranslation("l.angel_toy", "Halo Plush");
            var slimeDataAssets = slimeData.LoadAllAssets();
            GameObject haloToyObj = (GameObject)slimeDataAssets.FirstOrDefault(obj => obj.name == "AngelToy");
            ToyDefinition haloToyDef = (ToyDefinition)slimeDataAssets.FirstOrDefault(obj => obj.name == "AngelHaloToy");
            haloToyDef.toyId = toyIds.HALO_TOY;
            haloToyObj.GetComponent<Identifiable>().id = toyIds.HALO_TOY;
            LookupRegistry.RegisterToy(haloToyDef);
            LookupRegistry.RegisterIdentifiablePrefab(haloToyObj);
            GameContext.Instance.LookupDirector.RegisterToy(haloToyDef, haloToyObj);*/

            //Zones.angelGordo = Angel.AngelGordo().Item2;
        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {
            
        }
    }
}