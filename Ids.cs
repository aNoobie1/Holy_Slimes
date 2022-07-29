using System;
using SRML.Utils.Enum;

namespace ModdedIds
{
    [EnumHolder] //With this, you are indicating SRML that all the `public static readonly` variables are Enums
    public class Ids
    {
        public static readonly Identifiable.Id ANGEL_SLIME; //You created your first Enum!
        public static readonly Identifiable.Id DEMON_SLIME;
        public static readonly Identifiable.Id SPIRIT_SLIME;
        public static readonly Identifiable.Id ANGEL_PLORT;
        public static readonly Identifiable.Id DEMON_PLORT;
        public static readonly Identifiable.Id SPIRIT_PLORT;
        public static readonly PediaDirector.Id ANGEL_ENTRY;
        public static readonly PediaDirector.Id DEMON_ENTRY;
        public static readonly PediaDirector.Id SPIRIT_ENTRY;
    }
    [EnumHolder]
    internal class largoIds
    {
        public static readonly Identifiable.Id SPIRIT_ANGEL_LARGO;
        public static readonly Identifiable.Id SPIRIT_DEMON_LARGO;
    }
    [EnumHolder]
    internal class foodIds
    {
        public static readonly Identifiable.Id BLESSED_CARROT_VEGGIE;
        public static readonly Identifiable.Id GHOSTLY_POGO_FRUIT;
        public static readonly Identifiable.Id CURSED_HEN;
        public static readonly Identifiable.Id CURSED_CHICK;
    }
}