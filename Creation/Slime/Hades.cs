using SRML.SR;
using SRML.Utils;
using UnityEngine;
using ModdedIds;
using static ShortcutLib.Shortcut;
using System.Collections.Generic;
using HolySlimes.Behaviors;
using HolySlimes.Utility;
using System.Runtime.Remoting.Channels;
using SRML;


namespace HolySlimes.Creation.Slime
{
    internal class Hades
    {
        internal static AssetBundle customHorns = Util.LoadCustomStructure("demonhorns");

        public static (SlimeDefinition, GameObject) DemonSlime()
        {
            //Definition
            SlimeDefinition hunterSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME);
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(hunterSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
            Ids.DEMON_PLORT
            };

            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
            {
            SlimeEat.FoodGroup.MEAT
            };

            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0];

            slimeDefinition.Diet.Favorites = new Identifiable.Id[1]
            {
            foodIds.CURSED_HEN
            };

            slimeDefinition.Diet.EatMap?.Clear();
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[0];
            slimeDefinition.Name = "Demon Slime";
            slimeDefinition.IdentifiableId = Ids.DEMON_SLIME;
            //Object
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObject.name = "slimeDemon";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.AddComponent<DemonDrain>();
            slimeObject.GetComponent<DemonDrain>().health = 1;
            slimeObject.GetComponent<DemonDrain>().repeatTime = Time.deltaTime;
            slimeObject.AddComponent<StalkConsumable>();
            slimeObject.GetComponent<Identifiable>().id = Ids.DEMON_SLIME;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            //Appearance
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.FIRE_SLIME);
            SlimeDefinition slimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(hunterSlimeDefinition.AppearancesDefault[0]);
            slimeAppearance.name = "Classic";
            slimeAppearance.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(slimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
            };
            SlimeAppearanceElement slimeElem = ScriptableObject.CreateInstance<SlimeAppearanceElement>();
            slimeElem.name = "DemonFlames";
            slimeElem.Name = "DemonFlames";
            List<SlimeAppearanceObject> slimeAppObjList = new List<SlimeAppearanceObject>();
            GameObject slimeFireObj = PrefabUtils.CopyPrefab(slimeByIdentifiableId.AppearancesDefault[0].Structures[1].Element.Prefabs[0].gameObject);
            slimeFireObj.name = "demon_flames";
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            SlimeAppearance.SlimeBone[] hornsAttachedBones = new SlimeAppearance.SlimeBone[]
            {
            SlimeAppearance.SlimeBone.JiggleBack,
            SlimeAppearance.SlimeBone.JiggleBottom,
            SlimeAppearance.SlimeBone.JiggleFront,
            SlimeAppearance.SlimeBone.JiggleLeft,
            SlimeAppearance.SlimeBone.JiggleRight,
            SlimeAppearance.SlimeBone.JiggleTop
            };
            (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) hornsStructure = Structure.CreateBasicStructure(customHorns, "hornsdemon", "slime_horns", SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, hornsAttachedBones, RubberBoneEffect.RubberType.Slime);
            AssetsLib.MeshUtils.GenerateBoneData(slimeObject.GetComponent<SlimeAppearanceApplicator>(), hornsStructure.Item2, 0.5f);
            Structure.SetStructureElement("slimeHorns", slimeAppearance, new SlimeAppearanceObject[] { hornsStructure.Item2 }, 3, true, false);
            Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            material.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            material.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            material.SetFloat("_Shininess", 1f);
            material.SetFloat("_Gloss", 1f);
            material.name = "slimeDemonBase";
            structures[0].DefaultMaterials[0] = material;
            Material material2 = slimeFireObj.GetComponentInChildren<MeshRenderer>().sharedMaterial.Instantiate(false);
            material2.SetColor("_ColorOutside", new Color32(225, 25, 25, 255));
            material2.SetColor("_ColorInside", new Color32(25, 25, 25, 255));
            slimeFireObj.GetComponentInChildren<MeshRenderer>().sharedMaterial = material2;
            slimeAppObjList.Add(slimeFireObj.GetComponent<SlimeAppearanceObject>());
            slimeElem.Prefabs = slimeAppObjList.ToArray();
            structures[1].Element = slimeElem;
            Material material3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            material3.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            material3.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            material3.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            structures[2].DefaultMaterials[0] = material3;
            Material material4 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material4.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            material4.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            material4.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            slimeAppearance.Structures[3].DefaultMaterials[0] = material4;
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
                Top = new Color32(25, 25, 25, 255),
                Middle = new Color32(25, 25, 25, 255),
                Bottom = new Color32(25, 25, 25, 255),
                Ammo = new Color32(25, 25, 25, 255)
            };
            slimeAppearance.Icon = Util.CreateSprite(Util.LoadImage("BsDemonIcon.png"));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            //Slimepedia
            PediaRegistry.RegisterIdEntry(ModdedIds.Ids.DEMON_ENTRY, Util.CreateSprite(Util.LoadImage("BsDemonIcon.png")));

            return (slimeDefinition, slimeObject);
        }

        public static (SlimeDefinition, GameObject) CursedSlime()
        {
            //Definition
            SlimeDefinition puddleSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME);
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(puddleSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
            ModdedIds.foodIds.CURSED_HEN
            };

            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[2]
            {
            SlimeEat.FoodGroup.FRUIT,
            SlimeEat.FoodGroup.VEGGIES
            };

            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0];

            slimeDefinition.Diet.Favorites = new Identifiable.Id[0];

            slimeDefinition.Diet.EatMap?.Clear();
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[0];
            slimeDefinition.Name = "Cursed Slime";
            slimeDefinition.IdentifiableId = ModdedIds.Ids.CURSED_SLIME;
            //Object
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PUDDLE_SLIME));
            slimeObject.name = "slimeCursed";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = ModdedIds.Ids.CURSED_SLIME;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<SlimeEatWater>());
            UnityEngine.Object.Destroy(slimeObject.GetComponent<DestroyOnTouching>());
            UnityEngine.Object.Destroy(slimeObject.GetComponent<GotoWater>());
            //Appearance
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.DEMON_SLIME);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(puddleSlimeDefinition.AppearancesDefault[0]);
            slimeAppearance.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3])
            };
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            material.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            material.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            material.SetFloat("_Shininess", 1f);
            material.SetFloat("_Gloss", 1f);
            structures[0].DefaultMaterials[0] = material;
            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            material2.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            material2.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            material2.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            structures[1].DefaultMaterials[0] = material2;
            structures[2].DefaultMaterials[0] = material2;

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
                Top = new Color32(25, 25, 25, 255),
                Middle = new Color32(25, 25, 25, 255),
                Bottom = new Color32(25, 25, 25, 255),
                Ammo = new Color32(25, 25, 25, 255)
            };
            slimeAppearance.Icon = Util.CreateSprite(Util.LoadImage("BsCursedIcon.png"));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            //Slimepedia
            PediaRegistry.RegisterIdEntry(ModdedIds.Ids.CURSED_ENTRY, Util.CreateSprite(Util.LoadImage("BsCursedIcon.png")));

            return (slimeDefinition, slimeObject);
        }
    }
}
