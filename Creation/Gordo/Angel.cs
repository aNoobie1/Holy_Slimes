using HolySlimes.Utility;
using UnityEngine;
using System.Collections.Generic;
namespace HolySlimes.Creation.Gordo
{
    internal class Angel
    {
        public static (SlimeDefinition, GameObject) AngelGordo()
        {
            var gordo = ShortcutLib.Shortcut.Slime.CreateGordo(Identifiable.Id.PINK_GORDO, ModdedIds.Ids.ANGEL_SLIME, ModdedIds.gordoIds.ANGEL_GORDO, Util.CreateSprite(Util.LoadImage("BsAngelIcon.png")), "gordoAngel", "markerGordoAngel", ZoneDirector.Zone.RANCH, 60, new List<GameObject>(0));
            return gordo;
        }
    }
}
