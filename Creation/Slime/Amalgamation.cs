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
    internal class Amalgamation
    {
        public static (SlimeDefinition, GameObject, SlimeAppearance) BlursedSlime()
        {
            Color32 Beyes = new Color32(118, 103, 117, 255);
            Color32 Bmouth = new Color32(118, 103, 117, 255);
            var blursedSlime = ShortcutLib.Shortcut.Slime.CreateSlime(Identifiable.Id.PUDDLE_SLIME, Identifiable.Id.PUDDLE_SLIME, Ids.BLURSED_SLIME, "Blursed Slime", Util.CreateSprite(Util.LoadImage("BsBlursedIcon.png")), new Color32(125, 125, 125, 255), new Color32(125, 125, 125, 255));
            SlimeDefinition BslimeDef = blursedSlime.Item1;
            GameObject BslimeObj = blursedSlime.Item2;
            SlimeAppearance BslimeApp = blursedSlime.Item3;
            BslimeObj.name = "slimeBlursed";
            UnityEngine.Object.Destroy(BslimeObj.GetComponent<SlimeEatWater>());
            UnityEngine.Object.Destroy(BslimeObj.GetComponent<DestroyOnTouching>());
            UnityEngine.Object.Destroy(BslimeObj.GetComponent<GotoWater>());
            BslimeDef.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[] { SlimeEat.FoodGroup.FRUIT, SlimeEat.FoodGroup.VEGGIES, SlimeEat.FoodGroup.MEAT
    };
            BslimeDef.Diet.Favorites = new Identifiable.Id[] { };
            BslimeDef.Diet.Produces = new Identifiable.Id[] { foodIds.AMALGAMANGO_FRUIT };
            BslimeDef.Diet.AdditionalFoods = new Identifiable.Id[] { };
            SlimeDefinition BslimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PHOSPHOR_SLIME);
            SlimeDefinition BslimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME);
            SlimeDefinition BslimeByIdentifiableId3 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.ANGEL_SLIME);
            SlimeDefinition BslimeByIdentifiableId4 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.DEMON_SLIME);
            BslimeApp.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(BslimeApp.Structures[0]),
                new SlimeAppearanceStructure(BslimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
                new SlimeAppearanceStructure(BslimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(BslimeByIdentifiableId3.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3]),
                new SlimeAppearanceStructure(BslimeByIdentifiableId4.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3])
            };
            BslimeDef.AppearancesDefault[0] = BslimeApp;
            SlimeAppearanceStructure[] Bstructures = BslimeApp.Structures;
            Material Bmat = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            Bmat.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Bmat.SetColor("_MiddleColor", new Color32(218, 100, 40, 255));
            Bmat.SetColor("_BottomColor", new Color32(225, 25, 25, 255));
            Bmat.SetFloat("_Shininess", 1f);
            Bmat.SetFloat("_Gloss", 1f);
            Bmat.name = "slimeBlursedBase";
            Bstructures[0].DefaultMaterials[0] = Bmat;
            Material Bmat2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_PHOSPHOR_LARGO).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
            Bmat2.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Bmat2.SetColor("_MiddleColor", new Color32(218, 200, 140, 255));
            Bmat2.SetColor("_BottomColor", new Color32(225, 225, 225, 255));
            Bstructures[1].DefaultMaterials[0] = Bmat2;
            Material Bmat3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_HUNTER_LARGO).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            Bmat3.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Bmat3.SetColor("_MiddleColor", new Color32(218, 100, 40, 255));
            Bmat3.SetColor("_BottomColor", new Color32(225, 25, 25, 255));
            Bstructures[2].DefaultMaterials[0] = Bmat3;
            Material Bmat4 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            Bmat4.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Bmat4.SetColor("_MiddleColor", new Color32(218, 100, 40, 255));
            Bmat4.SetColor("_BottomColor", new Color32(225, 25, 25, 255));
            Bstructures[3].DefaultMaterials[0] = Bmat4;
            Material Bmat5 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            Bmat5.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Bmat5.SetColor("_MiddleColor", new Color32(218, 100, 40, 255));
            Bmat5.SetColor("_BottomColor", new Color32(225, 25, 25, 255));
            Bstructures[4].DefaultMaterials[0] = Bmat5;
            BslimeApp.ColorFace(Beyes, Beyes, Beyes, Bmouth, Bmouth, Bmouth);
            PediaRegistry.RegisterIdEntry(Ids.BLURSED_ENTRY, Util.CreateSprite(Util.LoadImage("BsBlursedIcon.png")));
            return (BslimeDef, BslimeObj, BslimeApp);
        }





        public static (SlimeDefinition, GameObject, SlimeAppearance) AngemonSlime()
        {
            Color32 Aeyes = new Color32(135, 206, 235, 255);
            Color32 Amouth = new Color32(102, 0, 0, 255);
            var angemonSlime = ShortcutLib.Shortcut.Slime.CreateSlime(Identifiable.Id.HUNTER_SLIME, Identifiable.Id.PINK_SLIME, Ids.ANGEMON_SLIME, "Angemon Slime", Util.CreateSprite(Util.LoadImage("BsAngemonIcon.png")), new Color32(125, 125, 125, 255), new Color32(125, 125, 125, 255));
            SlimeDefinition AslimeDef = angemonSlime.Item1;
            GameObject AslimeObj = angemonSlime.Item2;
            SlimeAppearance AslimeApp = angemonSlime.Item3;
            AslimeObj.name = "slimeAngemon";
            AslimeDef.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[] { SlimeEat.FoodGroup.VEGGIES, SlimeEat.FoodGroup.MEAT
    };
            AslimeDef.Diet.Favorites = new Identifiable.Id[] { foodIds.AMALGAMANGO_FRUIT
};
            AslimeDef.Diet.Produces = new Identifiable.Id[] { Ids.ANGEMON_PLORT };
            AslimeDef.Diet.AdditionalFoods = new Identifiable.Id[] { Ids.ANGEL_PLORT, Ids.DEMON_PLORT, foodIds.AMALGAMANGO_FRUIT };
            SlimeDefinition AslimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PHOSPHOR_SLIME);
            SlimeDefinition AslimeByIdentifiableId2 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HUNTER_SLIME);
            SlimeDefinition AslimeByIdentifiableId3 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.ANGEL_SLIME);
            SlimeDefinition AslimeByIdentifiableId4 = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.DEMON_SLIME);
            AslimeApp.Structures = new SlimeAppearanceStructure[]
            {
                new SlimeAppearanceStructure(AslimeApp.Structures[0]),
                new SlimeAppearanceStructure(AslimeByIdentifiableId.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2]),
                new SlimeAppearanceStructure(AslimeByIdentifiableId2.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1]),
                new SlimeAppearanceStructure(AslimeByIdentifiableId3.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3]),
                new SlimeAppearanceStructure(AslimeByIdentifiableId4.GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[3])
            };
            AslimeDef.AppearancesDefault[0] = AslimeApp;
            SlimeAppearanceStructure[] Astructures = AslimeApp.Structures;
            Material Amat = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            Amat.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Amat.SetColor("_MiddleColor", new Color32(218, 100, 40, 255));
            Amat.SetColor("_BottomColor", new Color32(225, 25, 25, 255));
            Amat.SetFloat("_Shininess", 1f);
            Amat.SetFloat("_Gloss", 1f);
            Amat.name = "slimeAngemonBase";
            Astructures[0].DefaultMaterials[0] = Amat;
            Material Amat2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_PHOSPHOR_LARGO).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
            Amat2.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Amat2.SetColor("_MiddleColor", new Color32(218, 100, 40, 255));
            Amat2.SetColor("_BottomColor", new Color32(225, 25, 25, 255));
            Astructures[1].DefaultMaterials[0] = Amat2;
            Material Amat3 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_HUNTER_LARGO).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
            Amat3.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Amat3.SetColor("_MiddleColor", new Color32(218, 100, 40, 255));
            Amat3.SetColor("_BottomColor", new Color32(225, 25, 25, 255));
            Astructures[2].DefaultMaterials[0] = Amat3;
            Material Amat4 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            Amat4.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Amat4.SetColor("_MiddleColor", new Color32(218, 100, 40, 255));
            Amat4.SetColor("_BottomColor", new Color32(225, 25, 25, 255));
            Astructures[3].DefaultMaterials[0] = Amat4;
            Material Amat5 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            Amat5.SetColor("_TopColor", new Color32(212, 175, 55, 255));
            Amat5.SetColor("_MiddleColor", new Color32(218, 100, 40, 255));
            Amat5.SetColor("_BottomColor", new Color32(225, 25, 25, 255));
            Astructures[4].DefaultMaterials[0] = Amat5;
            AslimeApp.ColorFace(Aeyes, Aeyes, Aeyes, Amouth, Amouth, Amouth);
            PediaRegistry.RegisterIdEntry(Ids.ANGEMON_ENTRY, Util.CreateSprite(Util.LoadImage("BsAngemonIcon.png")));

            GameObject AngemonPlort = ShortcutLib.Shortcut.Slime.CreatePlort(Identifiable.Id.ROCK_PLORT, Ids.ANGEMON_PLORT, "Angemon Plort", Util.CreateSprite(Util.LoadImage("BsAngemonPlortIcon.png")), new Color32(125, 125, 125, 255), 1f, 5f);
            ShortcutLib.Shortcut.Slime.ColorPlort(Ids.ANGEMON_PLORT, new Color32(212, 175, 55, 255), new Color32(218, 100, 40, 255), new Color32(225, 25, 25, 255), Identifiable.Id.HONEY_PLORT, new Color32(25, 25, 25, 255), new Color32(125, 125, 125, 255), new Color32(225, 225, 225, 255), true);
            return (AslimeDef, AslimeObj, AslimeApp);
        }
    }
}
