using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolySlimes.Utility;
using SimpleSRmodLibrary.Creation;
using UnityEngine;
using HarmonyLib;
using MonomiPark.SlimeRancher.Regions;
namespace HolySlimes
{
    [HarmonyPatch(typeof(PlayerZoneTracker), "OnEntered")]
    internal class Patch_ZoneTracker
    {
        private static void Postfix(ZoneDirector.Zone zone)
        {
            if (zone == ModdedIds.zoneIds.INBETWEEN)
            {
                SRSingleton<SceneContext>.Instance.PediaDirector.MaybeShowPopup(ModdedIds.zoneIds.INBETWEEN_ENTRY);
            }
            else if (zone == ModdedIds.zoneIds.HADES)
            {
                SRSingleton<SceneContext>.Instance.PediaDirector.MaybeShowPopup(ModdedIds.zoneIds.HADES_ENTRY);
            }
            else if (zone == ModdedIds.zoneIds.HEAVEN)
            {
                SRSingleton<SceneContext>.Instance.PediaDirector.MaybeShowPopup(ModdedIds.zoneIds.HEAVEN_ENTRY);
            }

        }
    }

    [HarmonyPatch(typeof(Region), "OnRegionSetDeactivated")]
    internal class Patch_DebugPrintRegionDeactivation
    {
        private static bool Prefix(Region __instance)
        {
            if(__instance.regionReg.GetCurrentRegionSetId() == RegionRegistry.RegionSetId.HOME)
            {
                return !DebugConfig.DEV_STOP_HOME_CELL_DEACTIVATION;
            }
            return true;
        }
        private static void Postfix(Region __instance)
        {
            SRML.Console.Console.Log("Deactiving cell \"" + __instance.gameObject.name + "\"!");
        }
    }

    [HarmonyPatch(typeof(ZoneDirector), "GetRegionSetId")]
    internal static class PatchZones
    {
        internal static bool Prefix(ZoneDirector.Zone zone, ref RegionRegistry.RegionSetId __result)
        {
            var z = zone == ModdedIds.zoneIds.INBETWEEN || zone == ModdedIds.zoneIds.HADES || zone == ModdedIds.zoneIds.HEAVEN;
            if (z)
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
            if (inbetweenObject == null)
            {
                inbObjects = inBetween.LoadAllAssets();
                var inbGObjectsL = new List<GameObject>();

                foreach (var obj in inbObjects)
                    if (obj is GameObject gobj)
                        inbGObjectsL.Add(gobj);

                inbGObjects = inbGObjectsL.ToArray();

                var inbZoneObj = inbGObjects.FirstOrDefault(obj => obj.name == "zoneBETWEEN");

                if (inbZoneObj != null)
                {
                    InbetweenLoad(inbZoneObj, t);
                }
            }
            //Gordos();
        }

        private static void PrepMaterials(UnityEngine.Object[] zoneData)
        {
            foreach(var obj in zoneData)
            {
                if (obj is Material mat)
                {
                    var sname = mat.shader.name;
                    mat.shader = Resources.FindObjectsOfTypeAll<Shader>().FirstOrDefault(s => s.name == sname);
                }
            }
        }
        private static GameObject[] inbGObjects;
        private static UnityEngine.Object[] inbObjects;


        public static (GameObject, GameObject) inbetweenEffects;

        private static void PrepSpawner(DirectedSlimeSpawner ss)
        {

            if (ss.gameObject.name.Contains("SpawnerQ"))
            {
                ss.spawnFX = GameContext.Instance.LookupDirector.GetPrefab(Identifiable.Id.QUANTUM_SLIME).GetComponent<QuantumSlimeSuperposition>().SuperposeParticleFx;
                ss.slimeSpawnFX = GameContext.Instance.LookupDirector.GetPrefab(Identifiable.Id.QUANTUM_SLIME).GetComponent<QuantumSlimeSuperposition>().SuperposeParticleFx;
            }
            foreach (var ssm in ss.constraints[0].slimeset.members)
                try
                {
                    ssm.prefab = GameContext.Instance.LookupDirector.GetPrefab((Identifiable.Id)Enum.Parse(typeof(Identifiable.Id), ssm.prefab.name));
                }
                catch { }
        }

        private static void PrepCells(GameObject zone, AmbianceDirector.Zone amb)
        {
            foreach (var cd in zone.GetComponentsInChildren<CellDirector>(true))
            {
                cd.ambianceZone = amb;
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
            var amb = (inbObjects.FirstOrDefault(obj => obj.name == "AmbianceDirectorZoneSetting_BETWEEN") as AmbianceDirectorZoneSetting);
            amb.zone = ModdedIds.ambianceIds.INBETWEEN;

            SceneContext.Instance.AmbianceDirector.zoneSettings.AddItem<AmbianceDirectorZoneSetting>(amb);
            PrepMaterials(inbObjects);
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
            var inbSeaFX = inbGObjects.FirstOrDefault(obj => obj.name == "FX_SoulSeaDeath");

            inbSeaKill.playerKillFx = inbSeaFX;
            inbSeaKill.killFX = inbSeaFX;
            var worldObjectsCreation = SceneContext.Instance.gameObject.AddComponent<WorldObjectsCreation>();
            var gadCount = 0;
            foreach (var gadgetSite in inb.GetComponentsInChildren<GadgetSite>())
            {
                worldObjectsCreation.BuildGadgetSite(gadgetSite.transform.parent.parent.gameObject, "INB" + gadCount, gadgetSite.gameObject);
                gadCount++;
            }            
            inbetweenEffects = (inb.FindChild("SoulSea").FindChild("Effects"), inb.FindChild("SoulSea").FindChild("SkyEffects"));

            inbetweenEffects.Item1.SetActive(ParticleConfig.SHOW_PARTICLES_INBETWEEN);
            inbetweenEffects.Item2.SetActive(ParticleConfig.SHOW_PARTICLES_INBETWEEN);

            inbetweenObject = inb;
        }
    }
}
