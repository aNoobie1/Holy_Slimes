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
using ShortcutLib;


namespace HolySlimes.Creation.Slime
{
    internal class Purified
    {
        public static (SlimeDefinition, GameObject, SlimeAppearance) PAngemonSlime()
        {
            Color32 IAeyes = new Color32(118, 103, 117, 255);
            Color32 IAmouth = new Color32(118, 103, 117, 255);

            (SlimeDefinition, GameObject, SlimeAppearance) IAngemonSlime = Shortcut.Slime.CreateSlime(Identifiable.Id.HUNTER_SLIME, Identifiable.Id.PINK_SLIME, Ids.PURIFIED_ANGEMON_SLIME, "Purified Angemon Slime", Util.CreateSprite(Util.LoadImage("BsAngemonIcon.png")), new Color32(125, 125, 125, 255), new Color32(125, 125, 125, 255));
            SlimeDefinition IAslimeDef = IAngemonSlime.Item1;
            GameObject IAslimeObj = IAngemonSlime.Item2;
            SlimeAppearance IAslimeApp = IAngemonSlime.Item3;
            IAslimeObj.name = "slimePurifiedAngemon";
            IAslimeObj.AddComponent<DemonDrain>();
            IAslimeObj.GetComponent<DemonDrain>().health = 2;
            IAslimeObj.GetComponent<DemonDrain>().repeatTime = Time.deltaTime;
            IAslimeObj.AddComponent<StalkConsumable>();
            IAslimeDef.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[] { SlimeEat.FoodGroup.VEGGIES, SlimeEat.FoodGroup.MEAT };
            IAslimeDef.Diet.Favorites = new Identifiable.Id[] { foodIds.BLURSED_PEAR_FRUIT };
            IAslimeDef.Diet.Produces = new Identifiable.Id[] { Ids.PURIFIED_ANGEMON_PLORT };
            IAslimeDef.Diet.AdditionalFoods = new Identifiable.Id[] { foodIds.BLURSED_PEAR_FRUIT };
            SlimeDefinition IAslimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.ANGEL_SLIME);
            SlimeDefinition IAslimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.DEMON_SLIME);
            IAslimeApp.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(IAslimeApp.Structures[0]),
                new SlimeAppearanceStructure(IAslimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(IAslimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(IAslimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
                new SlimeAppearanceStructure(IAslimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
                new SlimeAppearanceStructure(IAslimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3]),
                new SlimeAppearanceStructure(IAslimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3])
            };
            SlimeAppearanceElement IAslimeElem = ScriptableObject.CreateInstance<SlimeAppearanceElement>();
            IAslimeElem.name = "PAngemonFlames";
            IAslimeElem.Name = "PAngemonFlames";
            List<SlimeAppearanceObject> IAslimeAppObjList = new List<SlimeAppearanceObject>();
            GameObject IAslimeFireObj = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.FIRE_SLIME).AppearancesDefault[0].Structures[1].Element.Prefabs[0].gameObject);
            IAslimeFireObj.name = "pangemon_flames";
            IAslimeDef.AppearancesDefault[0] = IAslimeApp;
            SlimeAppearanceStructure[] IAstructures = IAslimeApp.Structures;
            Material IAmat = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            IAmat.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IAmat.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IAmat.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IAmat.SetFloat("_Shininess", 1f);
            IAmat.SetFloat("_Gloss", 1f);
            IAmat.name = "slimePAngemonBase";
            IAstructures[0].DefaultMaterials[0] = IAmat;
            Material IAmat1 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            IAmat1.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IAmat1.SetColor("_EdgeColor", new Color32(25, 25, 25, 25));
            IAstructures[1].DefaultMaterials[0] = IAmat1;
            Material IAmat2 = IAslimeFireObj.GetComponentInChildren<MeshRenderer>().sharedMaterial.Instantiate(false);
            IAmat2.SetColor("_ColorOutside", new Color32(218, 100, 40, 255));
            IAmat2.SetColor("_ColorInside", new Color32(125, 125, 125, 255));
            IAslimeFireObj.GetComponentInChildren<MeshRenderer>().sharedMaterial = IAmat2;
            IAslimeAppObjList.Add(IAslimeFireObj.GetComponent<SlimeAppearanceObject>());
            IAslimeElem.Prefabs = IAslimeAppObjList.ToArray();
            IAstructures[2].Element = IAslimeElem;
            Material IAmat3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
            IAmat3.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IAmat3.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IAmat3.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IAstructures[3].DefaultMaterials[0] = IAmat3;
            Material IAmat4 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            IAmat4.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IAmat4.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IAmat4.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IAstructures[4].DefaultMaterials[0] = IAmat4;
            Material IAmat5 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            IAmat5.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IAmat5.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IAmat5.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IAstructures[5].DefaultMaterials[0] = IAmat5;
            Material IAmat6 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            IAmat6.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IAmat6.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IAmat6.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IAstructures[6].DefaultMaterials[0] = IAmat6;
            IAslimeApp.ColorFace(IAeyes, IAeyes, IAeyes, IAmouth, IAmouth, IAmouth);
            PediaRegistry.RegisterIdEntry(Ids.PURIFIED_ANGEMON_ENTRY, Util.CreateSprite(Util.LoadImage("BsAngemonIcon.png")));
            var IAaura = new GameObject("AngelHealSource");
            IAaura.transform.parent = IAslimeObj.transform;
            IAaura.AddComponent<SphereCollider>().radius = 3;
            IAaura.GetComponent<SphereCollider>().isTrigger = true;
            IAaura.AddComponent<AngelHeal>().health = 1;
            return (IAslimeDef, IAslimeObj, IAslimeApp);
        }

        public static (SlimeDefinition, GameObject, SlimeAppearance) PBlursedSlime()
        {
            Color32 Beyes = new Color32(118, 103, 117, 255);
            Color32 Bmouth = new Color32(118, 103, 117, 255);
            (SlimeDefinition, GameObject, SlimeAppearance) IBlursedSlime = Shortcut.Slime.CreateSlime(Identifiable.Id.PUDDLE_SLIME, Identifiable.Id.PUDDLE_SLIME, Ids.PURIFIED_BLURSED_SLIME, "Purified Blursed Slime", Util.CreateSprite(Util.LoadImage("BsBlursedIcon.png")), new Color32(125, 125, 125, 255), new Color32(125, 125, 125, 255));
            SlimeDefinition IBslimeDef = IBlursedSlime.Item1;
            GameObject IBslimeObj = IBlursedSlime.Item2;
            SlimeAppearance IBslimeApp = IBlursedSlime.Item3;
            IBslimeObj.name = "slimePurifiedBlursed";
            UnityEngine.Object.Destroy(IBslimeObj.GetComponent<SlimeEatWater>());
            UnityEngine.Object.Destroy(IBslimeObj.GetComponent<DestroyOnTouching>());
            UnityEngine.Object.Destroy(IBslimeObj.GetComponent<GotoWater>());
            IBslimeDef.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[] { SlimeEat.FoodGroup.FRUIT, SlimeEat.FoodGroup.VEGGIES, SlimeEat.FoodGroup.MEAT };
            IBslimeDef.Diet.Favorites = new Identifiable.Id[] { };
            IBslimeDef.Diet.Produces = new Identifiable.Id[] { foodIds.BLURSED_PEAR_FRUIT };
            IBslimeDef.Diet.AdditionalFoods = new Identifiable.Id[] { };
            SlimeDefinition IBslimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.ANGEL_SLIME);
            SlimeDefinition IBslimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.DEMON_SLIME);
            IBslimeApp.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(IBslimeApp.Structures[0]),
                new SlimeAppearanceStructure(IBslimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
                new SlimeAppearanceStructure(IBslimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
                new SlimeAppearanceStructure(IBslimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3]),
                new SlimeAppearanceStructure(IBslimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3])
            };
            IBslimeDef.AppearancesDefault[0] = IBslimeApp;
            SlimeAppearanceStructure[] IBstructures = IBslimeApp.Structures;
            Material IBmat = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            IBmat.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IBmat.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IBmat.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IBmat.SetFloat("_Shininess", 1f);
            IBmat.SetFloat("_Gloss", 1f);
            IBmat.name = "slimePBlursedBase";
            IBstructures[0].DefaultMaterials[0] = IBmat;
            Material IBmat2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
            IBmat2.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IBmat2.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IBmat2.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IBstructures[1].DefaultMaterials[0] = IBmat2;
            Material IBmat3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            IBmat3.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IBmat3.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IBmat3.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IBstructures[2].DefaultMaterials[0] = IBmat3;
            Material IBmat4 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            IBmat4.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IBmat4.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IBmat4.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IBstructures[3].DefaultMaterials[0] = IBmat4;
            Material IBmat5 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            IBmat5.SetColor("_TopColor", new Color32(218, 100, 40, 255));
            IBmat5.SetColor("_MiddleColor", new Color32(172, 113, 83, 255));
            IBmat5.SetColor("_BottomColor", new Color32(125, 125, 125, 255));
            IBstructures[4].DefaultMaterials[0] = IBmat5;
            IBslimeApp.ColorFace(Beyes, Beyes, Beyes, Bmouth, Bmouth, Bmouth);
            PediaRegistry.RegisterIdEntry(Ids.PURIFIED_BLURSED_ENTRY, Util.CreateSprite(Util.LoadImage("BsBlursedIcon.png")));
            return (IBslimeDef, IBslimeObj, IBslimeApp);
        }
    }
}
