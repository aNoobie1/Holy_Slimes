using MonomiPark.SlimeRancher.Regions;
using SRML.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShortcutLib.Shortcut;
using UnityEngine;
using ModdedIds;
using HolySlimes.Behaviors;
using HolySlimes.Utility;

namespace HolySlimes.Commands
{
    public class SpiritRandom : ConsoleCommand
    {
        public static List<Identifiable.Id> valid1 = new List<Identifiable.Id>()
        {
            Ids.SPIRIT_SLIME,
            largoIds.SPIRIT_DEMON_LARGO,
        };
        public static List<Identifiable.Id> valid2 = new List<Identifiable.Id>()
        {
            largoIds.SPIRIT_ANGEL_LARGO,
        };

        public override string ID => "spiritrandom";

        public override string Usage => "spiritrandom";

        public override string Description => "Toggles Spirit mode randomization";

        public override bool Execute(string[] args)
        {
            if (args != null)
            {
                Util.LogError("Incorrect number of arguments!");
                return false;
            }

            if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out var hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Identifiable>() != null)
                {
                    if (valid1.Contains(hitInfo.collider.gameObject.GetComponent<Identifiable>().id))
                    {
                        try
                        {
                            hitInfo.collider.gameObject.GetComponent<SpiritHealOrDrain>().randomize = !hitInfo.collider.gameObject.GetComponent<SpiritHealOrDrain>().randomize;
                            Util.Log($"Successfully set randomization of {hitInfo.collider.gameObject.GetComponent<Identifiable>().id} to {hitInfo.collider.gameObject.GetComponent<SpiritHealOrDrain>().randomize}");
                        }
                        catch
                        {
                            Util.LogError("Unknown error!");
                            return false;
                        }
                    }
                    else if (valid2.Contains(hitInfo.collider.gameObject.GetComponent<Identifiable>().id))
                    {
                        try
                        {
                            hitInfo.collider.transform.Find("AngelHealSource(Clone)").gameObject.GetComponent<SpiritHealOrDrainAura>().randomize = !hitInfo.collider.transform.Find("AngelHealSource(Clone)").gameObject.GetComponent<SpiritHealOrDrainAura>().randomize;
                            Util.Log($"Successfully set randomization of {hitInfo.collider.gameObject.GetComponent<Identifiable>().id} to {hitInfo.collider.transform.Find("AngelHealSource(Clone)").gameObject.GetComponent<SpiritHealOrDrainAura>().randomize}");
                        }
                        catch
                        {
                            Util.LogError("Unknown error!");
                            return false;
                        }
                    }
                    else
                    {
                        Util.LogError("Not looking at a valid object!");
                        return false;
                    }
                }
                else
                {
                    Util.LogError("Not looking at a valid object!");
                    return false;
                }
            }
            else
            {
                Util.LogError("Not looking at a valid object!");
                return false;
            }
            return true;
        }
    }
}
