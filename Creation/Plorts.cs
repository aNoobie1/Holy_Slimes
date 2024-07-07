using SRML.SR;
using SRML.Utils;
using UnityEngine;

namespace HolySlimes.Creation
{
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
}
