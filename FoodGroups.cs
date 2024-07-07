using System.Collections.Generic;
using System.Linq;
using HarmonyLib;

namespace HolySlimes
{
    [HarmonyPatch(typeof(SlimeEat))]
    [HarmonyPatch("GetFoodGroupIds")]
    internal static class FoodGroupPatch
    {
        public static void Postfix(ref Identifiable.Id[] __result, SlimeEat.FoodGroup group)
        {

            if ((__result == null))
                return;

            List<Identifiable.Id> foodGroupIds = __result.ToList();
            if (group == SlimeEat.FoodGroup.MEAT) //Change to whatever foodgroup you want    
            {
                foodGroupIds.Add(ModdedIds.foodIds.CURSED_HEN);
            }
            if (group == SlimeEat.FoodGroup.VEGGIES) //Change to whatever foodgroup you want    
            {
                foodGroupIds.Add(ModdedIds.foodIds.BLESSED_CARROT_VEGGIE);
            }
            if (group == SlimeEat.FoodGroup.FRUIT) //Change to whatever foodgroup you want    
            {
                foodGroupIds.Add(ModdedIds.foodIds.GHOSTLY_POGO_FRUIT);
                foodGroupIds.Add(ModdedIds.foodIds.AMALGAMANGO_FRUIT);
                foodGroupIds.Add(ModdedIds.foodIds.BLURSED_PEAR_FRUIT);
            }
            __result = foodGroupIds.ToArray();
        }
    }
}
