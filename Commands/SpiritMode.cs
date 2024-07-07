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
    public class SpiritMode : ConsoleCommand
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

        public override string ID => "spiritmode";

        public override string Usage => "spiritmode <mode>";

        public override string Description => "Sets the mode of the Spirit Slime";

        public override bool Execute(string[] args)
        {
            if (args == null || args.Length > 1)
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
                            hitInfo.collider.gameObject.GetComponent<SpiritHealOrDrain>().mode = (HealDrainMode)Enum.Parse(typeof(HealDrainMode), args[0]);
                            Util.Log($"Successfully set mode of {hitInfo.collider.gameObject.GetComponent<Identifiable>().id} to {args[0]}");
                        }
                        catch
                        {
                            Util.LogError("Invalid mode!");
                            return false;
                        }
                    }
                    else if (valid2.Contains(hitInfo.collider.gameObject.GetComponent<Identifiable>().id))
                    {
                        try
                        {
                            hitInfo.collider.transform.Find("AngelHealSource(Clone)").gameObject.GetComponent<SpiritHealOrDrainAura>().mode = (HealDrainMode)Enum.Parse(typeof(HealDrainMode), args[0]);
                            Util.Log($"Successfully set mode of {hitInfo.collider.gameObject.GetComponent<Identifiable>().id} to {args[0]}");
                        }
                        catch
                        {
                            Util.LogError("Invalid mode!");
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

        public override List<string> GetAutoComplete(int argIndex, string argText)
        {
            if (argIndex == 0)
            {
                return Enum.GetNames(typeof(HealDrainMode)).ToList();
            }

            return base.GetAutoComplete(argIndex, argText);
        }
    }
}
