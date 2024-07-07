using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolySlimes.Utility;
using UnityEngine;

namespace HolySlimes
{
    internal class Zones
    {
        public static GameObject angelGordo;
        internal static AssetBundle inBetween = Util.LoadCustomZone("inbetweenzone");

        private static void Gordos()
        {
            if (angelGordo != null)
            {
                var angel = UnityEngine.Object.Instantiate(angelGordo);
                angel.transform.position = new Vector3(-117.1639f, -1.0307f, -261.2177f);
                angel.transform.eulerAngles = new Vector3(0, 155.1125f, 0);
            }
        }

        public static void Init(SceneContext t)
        {
            var inbObjects = inBetween.LoadAllAssets<GameObject>();
            GameObject inbZone = inbObjects.FirstOrDefault(obj => obj.name == "zoneBETWEEN");

            if (inbZone != null)
            {
                var inb = UnityEngine.Object.Instantiate(inbZone);
                inb.SetActive(false);
                inb.transform.position = new Vector3(0, -200, 0);

                var inbSea = inb.FindChild("SoulSea").FindChild("Floor");

                var inbSeaKill = inbSea.AddComponent<KillOnTrigger>();
                var inbSeaFX = inbObjects.FirstOrDefault(obj => obj.name == "FX_SoulSeaDeath");
                inbSeaKill.playerKillFx = inbSeaFX;
                inbSeaKill.killFX = inbSeaFX;
            }
            Gordos();
        }
    }
}
