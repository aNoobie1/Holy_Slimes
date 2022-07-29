using SRML;
using SRML.SR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MonomiPark.SlimeRancher.Regions;
using System.Reflection;
using HolySlimesCreation;
using static LargoLibrary.LargoGenerator;
using LargoLibrary;
using SRML.SR.Translation;
using SRML.Utils;
using ModdedIds;
using SimpleSRmodLibrary.Creation;

namespace HolySlimes
{
    public class Main : ModEntryPoint
    {
        public static Texture2D LoadImage(string filename)
        {
            var a = Assembly.GetExecutingAssembly();
            var spriteData = a.GetManifestResourceStream(a.GetName().Name + "." + filename);
            var rawData = new byte[spriteData.Length];
            spriteData.Read(rawData, 0, rawData.Length);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(rawData);
            tex.filterMode = FilterMode.Bilinear;
            return tex;
        }
        public static Sprite CreateSprite(Texture2D texture) => Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1);

        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();

            TranslationPatcher.AddActorTranslation("l." + (ModdedIds.Ids.ANGEL_PLORT.ToString().ToLower()), "Angel Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.Ids.ANGEL_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.Ids.ANGEL_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.Ids.ANGEL_PLORT);

            TranslationPatcher.AddActorTranslation("l." + (ModdedIds.Ids.DEMON_PLORT.ToString().ToLower()), "Demon Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.Ids.DEMON_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.Ids.DEMON_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.Ids.DEMON_PLORT);

            TranslationPatcher.AddActorTranslation("l." + (ModdedIds.Ids.SPIRIT_PLORT.ToString().ToLower()), "Spirit Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.Ids.SPIRIT_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.Ids.SPIRIT_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.Ids.SPIRIT_PLORT);

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
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.Ids.ANGEL_SLIME),
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
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.Ids.DEMON_SLIME),
                                weight = 0.25f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
                
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.Ids.ANGEL_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.Ids.ANGEL_ENTRY, ModdedIds.Ids.ANGEL_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.Ids.ANGEL_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.Ids.ANGEL_ENTRY)
                .SetTitleTranslation("Angel Slime")
                .SetIntroTranslation("Slimes from Heaven")
                .SetDietTranslation("Veggies")
                .SetFavoriteTranslation("Carrot")
                .SetSlimeologyTranslation("Angel Slimes are slimes that have descended from heaven to join the other slimes on the Far, Far Range. Their main purpose in life is to destroy the Demon Slimes.")
                .SetRisksTranslation("Angel Slimes will sacrifice themselves to destroy any traces of Demon Slimes. Make sure never to let an Angel Slime near a Demon Plort.")
                .SetPlortonomicsTranslation("Angel Plorts are used on Earth to work miracles for the population. They can cure many diseases, bring water to deserts, and even revive extinct species. In these acts, however, the plort is consumed, so they are in constant demand.");

            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.Ids.DEMON_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.Ids.DEMON_ENTRY, ModdedIds.Ids.DEMON_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.Ids.DEMON_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.Ids.DEMON_ENTRY)
                .SetTitleTranslation("Demon Slime")
                .SetIntroTranslation("Slimes from Hades")
                .SetDietTranslation("Meat")
                .SetFavoriteTranslation("Hen Hens")
                .SetSlimeologyTranslation("Demon Slimes are slimes that have risen from hades to join the other slimes on the Far, Far Range. Their main purpose in life is to destroy the Angel Slimes.")
                .SetRisksTranslation("Demon Slimes will sacrifice themselves to destroy any traces of Angel Slimes. Make sure never to let a Demon Slime near an Angel Plort.")
                .SetPlortonomicsTranslation("Demon Plorts are capable of producing mass catastrophies. In the wrong hands, these plorts can terrorize nations with natural disasters, plagues, and bankruptcy. In scientific hands however, they can be used to study these things. In these acts, however, the plort is consumed, so they are in constant demand.");

            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.Ids.SPIRIT_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.Ids.SPIRIT_ENTRY, ModdedIds.Ids.SPIRIT_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.Ids.SPIRIT_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.Ids.SPIRIT_ENTRY)
                .SetTitleTranslation("Spirit Slime")
                .SetIntroTranslation("Slimes from... uh...")
                .SetDietTranslation("Fruit")
                .SetFavoriteTranslation("Pogofruit")
                .SetSlimeologyTranslation("Spirit Slimes occur when an Angel Slime and a Demon Slime are left within reach of each other. They will eat each other and become this unstable slime.")
                .SetRisksTranslation("In an attempt to revert to their normal states, Spirit Slimes will seek out Angel and Demon Plorts to eat. This, however, always fails and, instead, causes the spirit slime to lose sentience entirely.")
                .SetPlortonomicsTranslation("Spirit plorts are often used in situations of dire emergency, when you need a miracle and are willing to deal with anything to get it. These plorts will work a miracle, but will also work a corresponding disaster alongside it. Desperate people will buy these plorts for extra newbucks, but the risk of losing the slime often isn't worth ranching them.");

        }
        public static GameObject CreateLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            LargoProperties[] array = new LargoProperties[5]
            {
                LargoProperties.SWAP_FACES,
                LargoProperties.RECOLOR_SLIME2_MATS,
                LargoProperties.REPLACE_SLIME2_MATS,
                LargoProperties.GENERATE_LARGO_NAME,
                LargoProperties.GENERATE_ADDON_TRANSFORMATION
            };
            
            return LargoGenerator.CreateLargo(slime1, slime2, largoId, array);
        }
        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {

            (SlimeDefinition, GameObject) ASlimeTuple = Slimes.AngelSlime(ModdedIds.Ids.ANGEL_SLIME, "Angel Slime");

            SlimeDefinition Angel_Slime_Definition = ASlimeTuple.Item1;
            GameObject Angel_Slime_Object = ASlimeTuple.Item2;

            LookupRegistry.RegisterIdentifiablePrefab(Angel_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Angel_Slime_Definition);

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Angel_Slime_Object);
            Sprite Aicon = CreateSprite(LoadImage("angel_slime_icon.png"));
            Color AngelWhite = new Color32(212, 175, 55, byte.MaxValue);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.Ids.ANGEL_SLIME, AngelWhite, Aicon));
            Angel_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.angel_slime", "Angel Slime");


            (SlimeDefinition, GameObject) DSlimeTuple = Slimes.DemonSlime(ModdedIds.Ids.DEMON_SLIME, "Demon Slime");

            SlimeDefinition Demon_Slime_Definition = DSlimeTuple.Item1;
            GameObject Demon_Slime_Object = DSlimeTuple.Item2;

            LookupRegistry.RegisterIdentifiablePrefab(Demon_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Demon_Slime_Definition);

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Demon_Slime_Object);
            Sprite Dicon = CreateSprite(LoadImage("devil_slime_icon.png"));
            Color DemonBlack = new Color32(192, 192, 192, byte.MaxValue);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.Ids.DEMON_SLIME, DemonBlack, Dicon));
            Demon_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.demon_slime", "Demon Slime");


            (SlimeDefinition, GameObject) SSlimeTuple = Slimes.SpiritSlime(ModdedIds.Ids.SPIRIT_SLIME, "Spirit Slime");

            SlimeDefinition Spirit_Slime_Definition = SSlimeTuple.Item1;
            GameObject Spirit_Slime_Object = SSlimeTuple.Item2;

            LookupRegistry.RegisterIdentifiablePrefab(Spirit_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Spirit_Slime_Definition);

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Spirit_Slime_Object);
            Sprite Sicon = CreateSprite(LoadImage("spirit_slime_icon.png"));
            Color SpiritGrey = new Color32(125, 125, 125, byte.MaxValue);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.Ids.SPIRIT_SLIME, SpiritGrey, Sicon));
            Spirit_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.spirit_slime", "Spirit Slime");


            CreateLargo(ModdedIds.Ids.SPIRIT_SLIME, ModdedIds.Ids.ANGEL_SLIME, ModdedIds.largoIds.SPIRIT_ANGEL_LARGO);
            CreateLargo(ModdedIds.Ids.SPIRIT_SLIME, ModdedIds.Ids.DEMON_SLIME, ModdedIds.largoIds.SPIRIT_DEMON_LARGO);


            GameObject AngelPlortTuple = Plorts.AngelPlort();
            GameObject AngelPlortObject = AngelPlortTuple;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, AngelPlortObject);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite APlortIcon = CreateSprite(LoadImage("angel_slime_plort_icon.png"));   
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.Ids.ANGEL_PLORT, AngelWhite, APlortIcon));
            AmmoRegistry.RegisterSiloAmmo((System.Predicate<SiloStorage.StorageType>)(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT), ModdedIds.Ids.ANGEL_PLORT);

            float Aprice = 95f; //Starting price for plort   
            float Asaturation = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(ModdedIds.Ids.ANGEL_PLORT, Aprice, Asaturation); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(ModdedIds.Ids.ANGEL_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(ModdedIds.Ids.ANGEL_PLORT);
            AmmoRegistry.RegisterRefineryResource(ModdedIds.Ids.ANGEL_PLORT); //For if you want to make a gadget that uses it  


            GameObject DemonPlortTuple = Plorts.DemonPlort();
            GameObject DemonPlortObject = DemonPlortTuple;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, DemonPlortObject);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite DPlortIcon = CreateSprite(LoadImage("devil_slime_plort_icon.png"));   
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.Ids.DEMON_PLORT, DemonBlack, DPlortIcon));
            AmmoRegistry.RegisterSiloAmmo((System.Predicate<SiloStorage.StorageType>)(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT), ModdedIds.Ids.DEMON_PLORT);

            float Dprice = 95f; //Starting price for plort   
            float Dsaturation = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(ModdedIds.Ids.DEMON_PLORT, Dprice, Dsaturation); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(ModdedIds.Ids.DEMON_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(ModdedIds.Ids.DEMON_PLORT);
            AmmoRegistry.RegisterRefineryResource(ModdedIds.Ids.DEMON_PLORT); //For if you want to make a gadget that uses it


            GameObject SpiritPlortTuple = Plorts.SpiritPlort();
            GameObject SpiritPlortObject = SpiritPlortTuple;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, SpiritPlortObject);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite SPlortIcon = CreateSprite(LoadImage("spirit_slime_plort_icon.png"));
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.Ids.SPIRIT_PLORT, SpiritGrey, SPlortIcon));
            AmmoRegistry.RegisterSiloAmmo((System.Predicate<SiloStorage.StorageType>)(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT), ModdedIds.Ids.SPIRIT_PLORT);

            float Sprice = 142f; //Starting price for plort   
            float Ssaturation = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(ModdedIds.Ids.SPIRIT_PLORT, Sprice, Ssaturation); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(ModdedIds.Ids.SPIRIT_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(ModdedIds.Ids.SPIRIT_PLORT);
            AmmoRegistry.RegisterRefineryResource(ModdedIds.Ids.SPIRIT_PLORT); //For if you want to make a gadget that uses it


            #region Chick
            GameObject ChickPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CHICK));
            ChickPrefab.name = "Cursed chick";
            SkinnedMeshRenderer mRenderChick = ChickPrefab.transform.Find("Chickadoo/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>();
            Material ChickMat = UnityEngine.Object.Instantiate<Material>(mRenderChick.sharedMaterial);
            ChickMat.SetTexture("_RampGreen", LoadImage("ramp_cursedhen_chickyellow.png"));
            ChickMat.SetTexture("_RampRed", LoadImage("ramp_cursedhen_beak.png"));
            ChickMat.SetTexture("_RampBlue", LoadImage("ramp_cursedhen_chickyellow.png"));
            ChickMat.SetTexture("_RampBlack", LoadImage("ramp_cursedhen_chickyellow.png"));
            mRenderChick.sharedMaterial = ChickMat;
            ChickPrefab.GetComponent<Identifiable>().id = foodIds.CURSED_CHICK;
            ChickPrefab.transform.Find("Chickadoo/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = ChickMat;
            LookupRegistry.RegisterIdentifiablePrefab(ChickPrefab);
            CropCreation.LoadCrop(foodIds.CURSED_CHICK, ChickPrefab, true, false, false, false);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, ChickPrefab, foodIds.CURSED_CHICK, "Cursed Chick", SRSingleton<SceneContext>.Instance.PediaDirector.entries.First((PediaDirector.IdEntry x) => x.id == PediaDirector.Id.HENHEN).icon, new Color32(179, 202, 218, 255));
            #endregion
            #region Hen Hen
            GameObject HenHenPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.HEN));
            HenHenPrefab.name = "Cursed hen";
            SkinnedMeshRenderer mRender = HenHenPrefab.transform.Find("Hen Hen/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>();
            Material HenMat = UnityEngine.Object.Instantiate<Material>(mRender.sharedMaterial);
            HenMat.SetTexture("_RampGreen", LoadImage("ramp_cursedhen_red.png"));
            HenMat.SetTexture("_RampRed", LoadImage("ramp_cursedhen_beak.png"));
            HenMat.SetTexture("_RampBlue", LoadImage("ramp_cursedhen_whitey.png"));
            HenMat.SetTexture("_RampBlack", LoadImage("ramp_cursedhen_whitey.png"));
            mRender.sharedMaterial = HenMat;
            HenHenPrefab.GetComponent<Identifiable>().id = foodIds.CURSED_HEN;
            HenHenPrefab.transform.Find("Hen Hen/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = HenMat;
            HenHenPrefab.GetComponent<Reproduce>().childPrefab = ChickPrefab;
            LookupRegistry.RegisterIdentifiablePrefab(HenHenPrefab);
            CropCreation.LoadCrop(foodIds.CURSED_HEN, HenHenPrefab, false, false, false, true);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, HenHenPrefab, foodIds.CURSED_HEN, "Cursed Hen", SRSingleton<SceneContext>.Instance.PediaDirector.entries.First((PediaDirector.IdEntry x) => x.id == PediaDirector.Id.CHICKADOO).icon, new Color32(179, 202, 218, 255));
            ChickPrefab.GetComponent<TransformAfterTime>().options = new List<TransformAfterTime.TransformOpt>() { new TransformAfterTime.TransformOpt() { targetPrefab = HenHenPrefab, weight = 9 }, ChickPrefab.GetComponent<TransformAfterTime>().options.ElementAt<TransformAfterTime.TransformOpt>(1) };
            #endregion

        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {
            
        }
    }
}