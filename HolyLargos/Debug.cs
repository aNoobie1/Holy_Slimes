using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRML.Console;
using SRML.Console.Commands;
using SRML.Utils;
using static ShortcutLib.Shortcut;

namespace HolyLargos
{
    internal class Debug
    {
        public class SpawnAllLargosOfSlimeType : ConsoleCommand
        {
            public override string ID => "spawnholylargos";
            public override string Usage => "spawnholylargos <baseslime>";
            public override string Description => "!!DEBUG COMMAND!!";
            public override bool Execute(string[] args)
            {
                string baseslime = args[0];
                List<string> enumsToSpawn = new List<string>();
                
                foreach (var enumName in Enum.GetNames(typeof(Identifiable.Id)))
                {
                    if (enumName.Contains("ANGEL") || enumName.Contains("DEMON") || enumName.Contains("SPIRIT"))
                    {
                        if (enumName.Contains(baseslime))
                        {
                            enumsToSpawn.Add(enumName);
                        }
                    }
                }
                if (enumsToSpawn.Count > 0)
                {
                    foreach (var enumName in enumsToSpawn)
                    {
                        SRBehaviour.InstantiateActor(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(EnumP.ParseID(enumName)), MonomiPark.SlimeRancher.Regions.RegionRegistry.RegionSetId.HOME, SceneContext.Instance.Player.transform.position, SceneContext.Instance.Player.transform.rotation);
                    }
                    return true;
                }
                return false;
            }
        }public class SpawnAllLargosOfHolyType : ConsoleCommand
        {
            public override string ID => "spawnholylargos2";
            public override string Usage => "spawnholylargos2 <baseholy>";
            public override string Description => "!!DEBUG COMMAND!!";
            public override bool Execute(string[] args)
            {
                string baseslime = args[0];
                List<string> enumsToSpawn = new List<string>();
                
                foreach (var enumName in Enum.GetNames(typeof(Identifiable.Id)))
                {
                    if (enumName.Contains("PINK") || enumName.Contains("ROCK") || enumName.Contains("TABBY") || enumName.Contains("PHOSPHOR") || enumName.Contains("RAD") || enumName.Contains("BOOM") || enumName.Contains("HONEY") || enumName.Contains("HUNTER") || enumName.Contains("CRYSTAL") || enumName.Contains("QUANTUM") || enumName.Contains("DERVISH") || enumName.Contains("TANGLE") || enumName.Contains("MOSAIC") || enumName.Contains("GOLD") || enumName.Contains("LUCKY") || enumName.Contains("PUDDLE") || enumName.Contains("FIRE") || enumName.Contains("GLITCH") || enumName.Contains("QUICKSILVER"))
                    {
                        if (enumName.Contains(baseslime))
                        {
                            enumsToSpawn.Add(enumName);
                        }
                    }
                }
                if (enumsToSpawn.Count > 0)
                {
                    foreach (var enumName in enumsToSpawn)
                    {
                        SRBehaviour.InstantiateActor(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(EnumP.ParseID(enumName)), MonomiPark.SlimeRancher.Regions.RegionRegistry.RegionSetId.HOME, SceneContext.Instance.Player.transform.position, SceneContext.Instance.Player.transform.rotation);
                    }
                    return true;
                }
                return false;
            }
        }
    }
}
