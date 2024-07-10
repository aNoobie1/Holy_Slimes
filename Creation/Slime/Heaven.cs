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
    internal class Heaven
    {
        internal static AssetBundle customHalo = Util.LoadCustomStructure("angelhalo");

        public static (SlimeDefinition, GameObject) AngelSlime()
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
            ModdedIds.foodIds.BLESSED_CARROT_VEGGIE
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
            /*slimeObject.AddComponent<AngelHeal>();
            slimeObject.GetComponent<AngelHeal>().healthPerSecond = 1 / Time.deltaTime;*/
            slimeObject.GetComponent<Identifiable>().id = ModdedIds.Ids.ANGEL_SLIME;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            //Appearance
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME);
            SlimeDefinition slimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PHOSPHOR_SLIME);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(phosphorSlimeDefinition.AppearancesDefault[0]);
            ///slimeAppearance.Name = "Classic";
            slimeAppearance.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(slimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
            };
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            SlimeAppearance.SlimeBone[] haloAttachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };
            (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) haloStructure = Structure.CreateBasicStructure(customHalo, "haloangel", "slime_halo", SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, haloAttachedBones, RubberBoneEffect.RubberType.Slime);
            AssetsLib.MeshUtils.GenerateBoneData(slimeObject.GetComponent<SlimeAppearanceApplicator>(), haloStructure.Item2, 0.5f);
            Structure.SetStructureElement("slimeHalo", slimeAppearance, new SlimeAppearanceObject[] { haloStructure.Item2 }, 3, true, false);
            Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            material.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
            material.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            material.SetFloat("_Shininess", 1f);
            material.SetFloat("_Gloss", 1f);
            material.name = "slimeAngelBase";
            structures[0].DefaultMaterials[0] = material;
            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            material2.SetColor("_MiddleColor", new Color32(212, 175, 54, 255));
            material2.SetColor("_EdgeColor", new Color32(25, 25, 25, 25));
            structures[1].DefaultMaterials[0] = material2;
            Material material3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
            material3.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            material3.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
            material3.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            structures[2].DefaultMaterials[0] = material3;
            Material material4 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material4.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            material4.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
            material4.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            slimeAppearance.Structures[3].DefaultMaterials[0] = material4;
            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(35, 160, 209, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(178, 226, 245, 255));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(35, 160, 209, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(35, 160, 209, 255));
                }
            }
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(225, 225, 225, 255),
                Middle = new Color32(225, 225, 225, 255),
                Bottom = new Color32(225, 225, 225, 255),
                Ammo = new Color32(225, 225, 225, 255)
            };
            slimeAppearance.Icon = Util.CreateSprite(Util.LoadImage("BsAngelIcon.png"));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;


            //Slimepedia
            PediaRegistry.RegisterIdEntry(ModdedIds.Ids.ANGEL_ENTRY, Util.CreateSprite(Util.LoadImage("BsAngelIcon.png")));

            var aura = new GameObject("AngelHealSource");
            aura.transform.parent = slimeObject.transform;
            aura.AddComponent<SphereCollider>().radius = 3;
            aura.GetComponent<SphereCollider>().isTrigger = true;
            aura.AddComponent<AngelHeal>().health = 1;

            return (slimeDefinition, slimeObject);
        }

        public static (SlimeDefinition, GameObject) BlessedSlime()
        {
            //Definition
            SlimeDefinition puddleSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME);
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(puddleSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
            ModdedIds.foodIds.BLESSED_CARROT_VEGGIE
            };

            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[2]
            {
            SlimeEat.FoodGroup.FRUIT,
            SlimeEat.FoodGroup.MEAT
            };

            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0];

            slimeDefinition.Diet.Favorites = new Identifiable.Id[0];

            slimeDefinition.Diet.EatMap?.Clear();
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[0];
            slimeDefinition.Name = "Blessed Slime";
            slimeDefinition.IdentifiableId = ModdedIds.Ids.BLESSED_SLIME;
            //Object
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PUDDLE_SLIME));
            slimeObject.name = "slimeBlessed";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = ModdedIds.Ids.BLESSED_SLIME;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<SlimeEatWater>());
            UnityEngine.Object.Destroy(slimeObject.GetComponent<DestroyOnTouching>());
            UnityEngine.Object.Destroy(slimeObject.GetComponent<GotoWater>());
            //Appearance
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.ANGEL_SLIME);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(puddleSlimeDefinition.AppearancesDefault[0]);
            slimeAppearance.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3]),
            };
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material.SetColor("_TopColor", new Color32(218, 200, 140, 255));
            material.SetColor("_MiddleColor", new Color32(221, 212, 182, 255));
            material.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            material.SetColor("_SpecColor", new Color32(218, 200, 140, 255));
            material.SetFloat("_Shininess", 1f);
            material.SetFloat("_Gloss", 1f);
            structures[0].DefaultMaterials[0] = material;
            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material2.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            material2.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
            material2.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            structures[1].DefaultMaterials[0] = material2;
            structures[2].DefaultMaterials[0] = material2;

            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(35, 160, 209, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(178, 226, 245, 255));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(35, 160, 209, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(135, 206, 235, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(35, 160, 209, 255));
                }
            }
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(212, 175, 55, 255),
                Middle = new Color32(212, 175, 55, 255),
                Bottom = new Color32(212, 175, 55, 255)
            };
            slimeAppearance.Icon = Util.CreateSprite(Util.LoadImage("BsBlessedIcon.png"));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            //Slimepedia
            PediaRegistry.RegisterIdEntry(ModdedIds.Ids.BLESSED_ENTRY, Util.CreateSprite(Util.LoadImage("BsBlessedIcon.png")));

            return (slimeDefinition, slimeObject);
        }
    }
}
