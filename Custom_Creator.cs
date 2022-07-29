using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using System.Reflection;
using SimpleSRmodLibrary.Ids;
using SimpleSRmodLibrary.Creation;
using ModdedIds;

namespace HolySlimesCreation
{
    public class Slimes
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

        public static (SlimeDefinition, GameObject) AngelSlime(Identifiable.Id SlimeId, String slimeAngel)
        {
            //Definition
            SlimeDefinition phosphorSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PHOSPHOR_SLIME);
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(phosphorSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
            ModdedIds.Ids.ANGEL_PLORT
            };

            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
            {
            SlimeEat.FoodGroup.VEGGIES
            };

            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0];

            slimeDefinition.Diet.Favorites = new Identifiable.Id[1]
            {
            Identifiable.Id.CARROT_VEGGIE
            };

            slimeDefinition.Diet.EatMap?.Clear();
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[0];
            slimeDefinition.Name = "Angel Slime";
            slimeDefinition.IdentifiableId = ModdedIds.Ids.ANGEL_SLIME;
            //Object
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObject.name = "slimeAngel";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = ModdedIds.Ids.ANGEL_SLIME;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            //Appearance
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME);
            SlimeDefinition slimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PHOSPHOR_SLIME);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(phosphorSlimeDefinition.AppearancesDefault[0]);
            slimeAppearance.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(slimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
            };
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
            {
                Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                    material.SetColor("_TopColor", new Color32(212, 175, 55, 255));
                    material.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
                    material.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
                    material.SetColor("_SpecColor", new Color32(218, 200, 140, 255));
                    material.SetFloat("_Shininess", 1f);
                    material.SetFloat("_Gloss", 1f);
                    slimeAppearanceStructure.DefaultMaterials[0] = material;
                    Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                    material2.SetColor("_MiddleColor", new Color32(212, 175, 54, 255));
                    material2.SetColor("_EdgeColor", new Color32(212, 175, 54, 255));
                    slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
                    Material material3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                    material3.SetColor("_TopColor", new Color32(212, 175, 55, 255));
                    material3.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
                    material3.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
                    slimeAppearance.Structures[2].DefaultMaterials[0] = material3;
                }
            };
            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
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
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(212, 175, 55, 255),
                Middle = new Color32(218, 200, 140, 255),
                Bottom = new Color32(225, 225, 225, 255)
            };
            slimeAppearance.Icon = CreateSprite(LoadImage("angel_slime_icon.png"));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            //Slimepedia
            PediaRegistry.RegisterIdEntry(ModdedIds.Ids.ANGEL_ENTRY, CreateSprite(LoadImage("angel_slime_icon.png")));

            return (slimeDefinition, slimeObject);
        }
        public static (SlimeDefinition, GameObject) DemonSlime(Identifiable.Id SlimeId, String slimeDemon)
        {
            //Definition
            SlimeDefinition hunterSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME);
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(hunterSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
            ModdedIds.Ids.DEMON_PLORT
            };

            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
            {
            SlimeEat.FoodGroup.MEAT
            };

            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0];

            slimeDefinition.Diet.Favorites = new Identifiable.Id[1]
            {
            Identifiable.Id.HEN
            };

            slimeDefinition.Diet.EatMap?.Clear();
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[0];
            slimeDefinition.Name = "Demon Slime";
            slimeDefinition.IdentifiableId = ModdedIds.Ids.DEMON_SLIME;
            //Object
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObject.name = "slimeDemon";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = ModdedIds.Ids.DEMON_SLIME;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            //Appearance
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.FIRE_SLIME);
            SlimeDefinition slimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(hunterSlimeDefinition.AppearancesDefault[0]);
            slimeAppearance.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(slimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
            };
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            material.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            material.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            material.SetColor("_SpecColor", new Color32(125, 25, 25, 255));
            material.SetFloat("_Shininess", 1f);
            material.SetFloat("_Gloss", 1f);
            structures[0].DefaultMaterials[0] = material;
            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            material2.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            material2.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            material2.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            structures[2].DefaultMaterials[0] = material2;
            Material material3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.FIRE_SLIME).AppearancesDefault[0].Structures[1].Element.Prefabs[0].GetComponentInChildren<MeshRenderer>().sharedMaterial);
            material3.SetColor("_ColorOutside", new Color32(225, 25, 25, 255));
            material3.SetColor("_ColorInside", new Color32(25, 25, 25, 255));
            structures[1].Element.Prefabs[0].GetComponentInChildren<MeshRenderer>().sharedMaterial = material3;
            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(102, 0, 0, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(102, 0, 0, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(102, 0, 0, 255));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(102, 0, 0, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(102, 0, 0, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(102, 0, 0, 255));
                }
            }
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(192, 192, 192, 255),
                Middle = new Color32(108, 108, 108, 255),
                Bottom = new Color32(25, 25, 25, 255)
            };
            slimeAppearance.Icon = CreateSprite(LoadImage("devil_slime_icon.png"));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            //Slimepedia
            PediaRegistry.RegisterIdEntry(ModdedIds.Ids.DEMON_ENTRY, CreateSprite(LoadImage("devil_slime_icon.png")));

            return (slimeDefinition, slimeObject);
        }
        public static (SlimeDefinition, GameObject) SpiritSlime(Identifiable.Id SlimeId, String slimeSpirit)
        {
            //Definition
            SlimeDefinition pinkSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME);
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(pinkSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
            ModdedIds.Ids.SPIRIT_PLORT
            };

            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
            {
            SlimeEat.FoodGroup.FRUIT
            };

            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0];

            slimeDefinition.Diet.Favorites = new Identifiable.Id[1]
            {
            Identifiable.Id.POGO_FRUIT
            };

            slimeDefinition.Diet.EatMap?.Clear();
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[0];
            slimeDefinition.Name = "Spirit Slime";
            slimeDefinition.IdentifiableId = ModdedIds.Ids.SPIRIT_SLIME;
            //Object
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObject.name = "slimeSpirit";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = ModdedIds.Ids.SPIRIT_SLIME;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            //Appearance
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(pinkSlimeDefinition.AppearancesDefault[0]);
            slimeAppearance.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
            };
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.QUANTUM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material.SetColor("_TopColor", new Color32(25, 25, 25, 255));
            material.SetColor("_MiddleColor", new Color32(125, 125, 125, 255));
            material.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            material.SetColor("_SpecColor", new Color32(125, 125, 125, 255));
            material.SetFloat("_Shininess", 1f);
            material.SetFloat("_Gloss", 1f);
            structures[0].DefaultMaterials[0] = material;
            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            material2.SetColor("_BottomColor", new Color32(125, 125, 125, 255));//tried MiddleColor, TopColor,
            structures[1].DefaultMaterials[0] = material2;

            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(135, 206, 235, 255));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(102, 0, 0, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(102, 0, 0, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(102, 0, 0, 255));
                }
            }
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(225, 225, 225, 255),
                Middle = new Color32(125, 125, 125, 255),
                Bottom = new Color32(25, 25, 25, 255)
            };
            slimeAppearance.Icon = CreateSprite(LoadImage("spirit_slime_icon.png"));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            //Slimepedia
            PediaRegistry.RegisterIdEntry(ModdedIds.Ids.SPIRIT_ENTRY, CreateSprite(LoadImage("spirit_slime_icon.png")));

            return (slimeDefinition, slimeObject);
        }
    }
    public class Plorts
    {
        public static GameObject AngelPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT));
            Prefab.name = "AngelPlort";

            Prefab.GetComponent<Identifiable>().id = ModdedIds.Ids.ANGEL_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = UnityEngine.Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);   
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", new Color32(225, 225, 225, 255));

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
        public static GameObject DemonPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT));
            Prefab.name = "DemonPlort";

            Prefab.GetComponent<Identifiable>().id = ModdedIds.Ids.DEMON_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = UnityEngine.Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", new Color32(25, 25, 25, 255));

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
        public static GameObject SpiritPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT));
            Prefab.name = "SpiritPlort";

            Prefab.GetComponent<Identifiable>().id = ModdedIds.Ids.SPIRIT_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = UnityEngine.Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", new Color32(25, 25, 25, 255));
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", new Color32(125, 125, 125, 255));
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", new Color32(225, 225, 225, 255));

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }
    public class Foods
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
        public static GameObject CursedHen()
        {
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
            return HenHenPrefab;
        }
    }
}
