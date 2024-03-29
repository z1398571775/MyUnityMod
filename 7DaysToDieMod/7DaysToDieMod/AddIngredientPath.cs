using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7DaysToDieMod
{
    [HarmonyPatch(typeof(Recipe), nameof(Recipe.AddIngredient))]
    internal class AddIngredientPath
    {
        [HarmonyPrefix]
        static bool Prefix(Recipe __instance, ItemValue _itemValue, int _count)
        {
            _itemValue = ItemClass.GetItem("resourceWood");
            //Melon<MyMod>.Logger.Msg($"id: {_itemValue.ItemClass.Id} ,name: {_itemValue.ItemClass.Name}");
            if (__instance.ingredients.Count < 1)
            {
                __instance.ingredients.Add(new ItemStack(_itemValue, _count));
            }
            return false;

        }
    }
}
