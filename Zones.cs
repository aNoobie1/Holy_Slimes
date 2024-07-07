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
        internal static AssetBundle inBetween = Util.LoadCustomZone("inbetweenzone");

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
        }
    }
}
