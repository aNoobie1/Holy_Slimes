using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolySlimes.Utility;
using UnityEngine;
using HarmonyLib;
using MonomiPark.SlimeRancher.Regions;
namespace HolySlimes
{
    [HarmonyPatch(typeof(ZoneDirector), "GetRegionSetId")]
    internal static class PatchZones
    {
        // Token: 0x06000030 RID: 48 RVA: 0x0000A690 File Offset: 0x00008890
        internal static bool Prefix(ZoneDirector.Zone zone, ref RegionRegistry.RegionSetId __result)
        {
            var inb = zone == ModdedIds.zoneIds.INBETWEEN || zone == ModdedIds.zoneIds.HADES || zone == ModdedIds.zoneIds.HEAVEN;
            if (inb)
            {
                __result = RegionRegistry.RegionSetId.HOME;
                return false;
            }
            return true;
        }
    }
    internal class Zones
    {
        /*public static GameObject angelGordo;*/

        public static GameObject inbetweenObject;
        internal static AssetBundle inBetween = Util.LoadCustomZone("inbetweenzone");

        /*private static void Gordos()
        {
            if (angelGordo != null)
            {
                var angel = UnityEngine.Object.Instantiate(angelGordo);
                angel.transform.position = new Vector3(-117.1639f, -1.0307f, -261.2177f);
                angel.transform.eulerAngles = new Vector3(0, 155.1125f, 0);
            }
        }*/

        public static void Init(SceneContext t)
        {
            inbObjects = inBetween.LoadAllAssets<GameObject>();
            GameObject inbZone = inbObjects.FirstOrDefault(obj => obj.name == "zoneBETWEEN");

            if (inbZone != null)
            {
                InbetweenLoad(inbZone, t);
            }
            //Gordos();
        }

        private static GameObject[] inbObjects;

        private static void PrepSpawner(DirectedSlimeSpawner ss)
        {
            foreach (var ssm in ss.constraints[0].slimeset.members)
            {
                ssm.prefab = GameContext.Instance.LookupDirector.GetPrefab((Identifiable.Id)Enum.Parse(typeof(Identifiable.Id), ssm.prefab.name));
            }
        }

        private static void Spawners(GameObject zone)
        {
            foreach (var ss in zone.GetComponentsInChildren<DirectedSlimeSpawner>(true))
            {
                PrepSpawner(ss);
            }
        }

        private static void InbetweenLoad(GameObject prefab, SceneContext t)
        {
            prefab.GetComponent<ZoneDirector>().zone = ModdedIds.zoneIds.INBETWEEN;

            Spawners(prefab);

            var inb = UnityEngine.Object.Instantiate(prefab);
            //inb.SetActive(false);


            inb.transform.position = t.player.transform.position;
            inb.transform.position = new Vector3(inb.transform.position.x, -250, inb.transform.position.z);

            var inbSea = inb.FindChild("SoulSea").FindChild("Floor");

            var inbSeaFollow = inbSea.transform.parent.gameObject.AddComponent<seaFollowCamera>();

            inbSeaFollow.mainCamera = Camera.current;

            var inbSeaKill = inbSea.AddComponent<KillOnTrigger>();
            var inbSeaFX = inbObjects.FirstOrDefault(obj => obj.name == "FX_SoulSeaDeath");

            inbSeaKill.playerKillFx = inbSeaFX;
            inbSeaKill.killFX = inbSeaFX;

            inbetweenObject = inb;
        }
    }
}
