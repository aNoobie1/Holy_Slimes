using SRML.Utils.Enum;

namespace ModdedIds
{
    [EnumHolder] //With this, you are indicating SRML that all the `public static readonly` variables are Enums
    public class Ids
    {
        public static readonly Identifiable.Id ANGEL_SLIME;
        public static readonly Identifiable.Id DEMON_SLIME;
        public static readonly Identifiable.Id SPIRIT_SLIME;
        public static readonly Identifiable.Id CURSED_SLIME;
        public static readonly Identifiable.Id BLESSED_SLIME;
        public static readonly Identifiable.Id GHOSTLY_SLIME;
        public static readonly Identifiable.Id ANGEMON_SLIME;
        public static readonly Identifiable.Id BLURSED_SLIME;
        public static readonly Identifiable.Id PURIFIED_ANGEMON_SLIME;
        public static readonly Identifiable.Id PURIFIED_BLURSED_SLIME;

        public static readonly Identifiable.Id ANGEL_PLORT;
        public static readonly Identifiable.Id DEMON_PLORT;
        public static readonly Identifiable.Id SPIRIT_PLORT;
        public static readonly Identifiable.Id ANGEMON_PLORT;
        public static readonly Identifiable.Id PURIFIED_ANGEMON_PLORT;
        
        public static readonly PediaDirector.Id ANGEL_ENTRY;
        public static readonly PediaDirector.Id DEMON_ENTRY;
        public static readonly PediaDirector.Id SPIRIT_ENTRY;
        public static readonly PediaDirector.Id CURSED_ENTRY;
        public static readonly PediaDirector.Id BLESSED_ENTRY;
        public static readonly PediaDirector.Id GHOSTLY_ENTRY;
        public static readonly PediaDirector.Id ANGEMON_ENTRY;
        public static readonly PediaDirector.Id BLURSED_ENTRY;
        public static readonly PediaDirector.Id PURIFIED_ANGEMON_ENTRY;
        public static readonly PediaDirector.Id PURIFIED_BLURSED_ENTRY;
    }
    [EnumHolder]
    public class largoIds
    {
        public static readonly Identifiable.Id SPIRIT_ANGEL_LARGO;
        public static readonly Identifiable.Id SPIRIT_DEMON_LARGO;
        public static readonly Identifiable.Id GHOSTLY_BLESSED_LARGO;
        public static readonly Identifiable.Id GHOSTLY_CURSED_LARGO;
    }
    [EnumHolder]
    public class foodIds
    {
        public static readonly Identifiable.Id BLESSED_CARROT_VEGGIE;
        public static readonly Identifiable.Id GHOSTLY_POGO_FRUIT;
        public static readonly Identifiable.Id CURSED_HEN;
        public static readonly Identifiable.Id AMALGAMANGO_FRUIT;
        public static readonly Identifiable.Id BLURSED_PEAR_FRUIT;
    }
    [EnumHolder]
    public class chromaIds
    {
        public static readonly RanchDirector.Palette ANGEL_CHROMA;
        public static readonly RanchDirector.Palette DEMON_CHROMA;
    }
    [EnumHolder]
    public class zoneIds
    {
        public static readonly ZoneDirector.Zone INBETWEEN;
        public static readonly ZoneDirector.Zone HADES;
        public static readonly ZoneDirector.Zone HEAVEN;
    }
    [EnumHolder]
    public class gordoIds
    {
        public static readonly Identifiable.Id ANGEL_GORDO;
        public static readonly Identifiable.Id DEMON_GORDO;
        public static readonly Identifiable.Id SPIRIT_GORDO;
    }
    [EnumHolder]
    public class resourceIds
    {
        public static readonly Identifiable.Id ANGEL_ESSENCE;
        public static readonly Identifiable.Id DEMON_ESSENCE;
        public static readonly Identifiable.Id SPIRIT_ESSENCE;
        public static readonly Identifiable.Id BLESSED_ESSENCE;
        public static readonly Identifiable.Id CURSED_ESSENCE;
        public static readonly Identifiable.Id GHOSTLY_ESSENCE;
    }
    [EnumHolder]
    public class gadgetIds
    {
        public static readonly Gadget.Id ANGEL_DEMON_COMBINER;
    }

    public enum HealDrainMode
    {
        DRAIN = -1,
        DEFAULT = 0,
        HEAL = 1,
    }
}