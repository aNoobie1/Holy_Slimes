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
    internal class InBetween
    {
        internal static AssetBundle customOrbs = Util.LoadCustomStructure("spiritorbs");

        public static (SlimeDefinition, GameObject) SpiritSlime()
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
            ModdedIds.foodIds.GHOSTLY_POGO_FRUIT
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
            slimeObject.AddComponent<SpiritHealOrDrain>();
            slimeObject.GetComponent<SpiritHealOrDrain>().health = 1;
            slimeObject.GetComponent<SpiritHealOrDrain>().repeatTime = Time.deltaTime;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            //Appearance
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.MOSAIC_SLIME);
            SlimeDefinition slimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(pinkSlimeDefinition.AppearancesDefault[0]);
            slimeAppearance.name = "Classic";
            slimeAppearance.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(slimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
            };
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            SlimeAppearance.SlimeBone[] orbAttachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };
            (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) angOrbStructure = Structure.CreateBasicStructure(customOrbs, "angorbspirit", "slime_angorb", SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, orbAttachedBones, RubberBoneEffect.RubberType.Slime, true, true);
            angOrbStructure.Item1.AddComponent<vp_Spin>();
            Structure.SetStructureElement("slimeOrbAng", slimeAppearance, new SlimeAppearanceObject[] { angOrbStructure.Item2 }, 3, true, false);
            (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) demOrbStructure = Structure.CreateBasicStructure(customOrbs, "demorbspirit", "slime_demorb", SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, orbAttachedBones, RubberBoneEffect.RubberType.Slime, true, true);
            demOrbStructure.Item1.AddComponent<vp_Spin>();
            Structure.SetStructureElement("slimeOrbDem", slimeAppearance, new SlimeAppearanceObject[] { demOrbStructure.Item2 }, 4, true, false);
            Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material.SetColor("_TopColor", new Color32(25, 25, 25, 255));
            material.SetColor("_MiddleColor", new Color32(125, 125, 125, 255));
            material.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            material.SetFloat("_Shininess", 1f);
            material.SetFloat("_Gloss", 1f);
            material.name = "slimeSpiritBase";
            structures[0].DefaultMaterials[0] = material;
            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            material2.SetColor("_MiddleColor", new Color32(13, 13, 13, 255));
            material2.SetColor("_EdgeColor", new Color32(13, 13, 13, 255));
            structures[1].DefaultMaterials[0] = material2;
            Material material3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material3.SetColor("_TopColor", new Color32(25, 25, 25, 255));
            material3.SetColor("_MiddleColor", new Color32(125, 125, 125, 255));
            material3.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            structures[2].DefaultMaterials[0] = material3;
            Material material4 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material4.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            material4.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
            material4.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            slimeAppearance.Structures[3].DefaultMaterials[0] = material4;
            Material material5 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material5.SetColor("_TopColor", new Color32(225, 25, 25, 255));
            material5.SetColor("_MiddleColor", new Color32(125, 25, 25, 255));
            material5.SetColor("_BottomColor", new Color32(25, 25, 25, 255));
            slimeAppearance.Structures[4].DefaultMaterials[0] = material5;

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
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(66, 0, 0, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(102, 0, 0, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(66, 0, 0, 255));
                }
            }
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(125, 125, 125, 255),
                Middle = new Color32(125, 125, 125, 255),
                Bottom = new Color32(125, 125, 125, 255),
                Ammo = new Color32(125, 125, 125, 255)
            };
            slimeAppearance.Icon = Util.CreateSprite(Util.LoadImage("BsSpiritIcon.png"));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            //Slimepedia
            PediaRegistry.RegisterIdEntry(ModdedIds.Ids.SPIRIT_ENTRY, Util.CreateSprite(Util.LoadImage("BsSpiritIcon.png")));

            return (slimeDefinition, slimeObject);
        }

        public static (SlimeDefinition, GameObject) GhostlySlime()
        {
            //Definition
            SlimeDefinition puddleSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME);
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(puddleSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
            ModdedIds.foodIds.GHOSTLY_POGO_FRUIT
            };

            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[2]
            {
            SlimeEat.FoodGroup.VEGGIES,
            SlimeEat.FoodGroup.MEAT
            };

            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0];

            slimeDefinition.Diet.Favorites = new Identifiable.Id[0];

            slimeDefinition.Diet.EatMap?.Clear();
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[0];
            slimeDefinition.Name = "Ghostly Slime";
            slimeDefinition.IdentifiableId = ModdedIds.Ids.GHOSTLY_SLIME;
            //Object
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PUDDLE_SLIME));
            slimeObject.name = "slimeGhostly";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = ModdedIds.Ids.GHOSTLY_SLIME;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<SlimeEatWater>());
            UnityEngine.Object.Destroy(slimeObject.GetComponent<DestroyOnTouching>());
            UnityEngine.Object.Destroy(slimeObject.GetComponent<GotoWater>());
            //Appearance
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.SPIRIT_SLIME);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(puddleSlimeDefinition.AppearancesDefault[0]);
            slimeAppearance.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                new SlimeAppearanceStructure(slimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
            };
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material.SetColor("_TopColor", new Color32(25, 25, 25, 255));
            material.SetColor("_MiddleColor", new Color32(225, 225, 225, 255));
            material.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            material.SetColor("_SpecColor", new Color32(125, 125, 125, 255));
            material.SetFloat("_Shininess", 1f);
            material.SetFloat("_Gloss", 1f);
            structures[0].DefaultMaterials[0] = material;
            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            material2.SetColor("_TopColor", new Color32(25, 25, 25, 255));
            material2.SetColor("_MiddleColor", new Color32(225, 225, 225, 255));
            material2.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            structures[1].DefaultMaterials[0] = material2;

            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(76, 66, 75, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(118, 103, 117, 255));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(141, 124, 139, 255));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(76, 66, 75, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(118, 103, 117, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(76, 66, 75, 255));
                }
            }
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(125, 125, 125, 255),
                Middle = new Color32(125, 125, 125, 255),
                Bottom = new Color32(125, 125, 125, 255),
                Ammo = new Color32(125, 125, 125, 255)
            };
            slimeAppearance.Icon = Util.CreateSprite(Util.LoadImage("BsGhostlyIcon.png"));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            //Slimepedia
            PediaRegistry.RegisterIdEntry(ModdedIds.Ids.GHOSTLY_ENTRY, Util.CreateSprite(Util.LoadImage("BsGhostlyIcon.png")));

            return (slimeDefinition, slimeObject);
        }
    }
}
