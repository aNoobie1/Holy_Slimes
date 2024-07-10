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
    public class AbilityGiving : ConsoleCommand
    {
        public static List<Identifiable.Id> nonLargos = new List<Identifiable.Id>()
        {
            Identifiable.Id.PINK_SLIME,
            Identifiable.Id.ROCK_SLIME,
            Identifiable.Id.RAD_SLIME,
            Identifiable.Id.BOOM_SLIME,
            Identifiable.Id.PHOSPHOR_SLIME,
            Identifiable.Id.HONEY_SLIME,
            Identifiable.Id.TANGLE_SLIME,
            Identifiable.Id.GOLD_SLIME,
            Identifiable.Id.LUCKY_SLIME,
            Identifiable.Id.TARR_SLIME,
            Identifiable.Id.MOSAIC_SLIME,
            Identifiable.Id.DERVISH_SLIME,
            Identifiable.Id.CRYSTAL_SLIME,
            Identifiable.Id.QUANTUM_SLIME,
            Identifiable.Id.SABER_SLIME,
            Identifiable.Id.PUDDLE_SLIME,
            Identifiable.Id.FIRE_SLIME,
            Identifiable.Id.HUNTER_SLIME,
            Identifiable.Id.GLITCH_SLIME,
            Identifiable.Id.QUICKSILVER_SLIME,
        };

        public override string ID => "ability";

        public override string Usage => "ability <SLIME>";

        public override string Description => "Toggles Spirit mode randomization";


        public override List<string> GetAutoComplete(int argIndex, string argText)
        {
            List<string> list = new List<string>();
            if (argIndex == 0)
            {
                foreach (var item in nonLargos)
                {
                    list.Add(item.ToString());
                }
                return list;
            }

            return base.GetAutoComplete(argIndex, argText);
        }

        public override bool Execute(string[] args)
        {
            if (args.Count() != 1)
            {
                Util.LogError("Incorrect number of arguments!");
                return false;
            }

            Enum.TryParse<Identifiable.Id>(args[0], out var res);

            if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out var hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Identifiable>() != null)
                {
                    var ident = hitInfo.collider.gameObject.GetComponent<Identifiable>();
                    if (nonLargos.Contains(ident.id) && nonLargos.Contains(res))
                    {
                        var ident2 = GameContext.Instance.LookupDirector.GetPrefab(res);
                        foreach (var mono in ident2.GetComponents<MonoBehaviour>())
                        {
                            var compT = mono.GetType();
                            var comp = ident.GetComponent(compT);
                            if (comp == null)
                            {
                                ident.gameObject.AddComponent(compT);
                            }
                        }
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
