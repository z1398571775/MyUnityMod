using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7DaysToDieMod.Patch
{
    [HarmonyPatch(typeof(LootContainer), nameof(LootContainer.SpawnLootItemsFromList))]
    internal class LootContainerPatch
    {
        [HarmonyPrefix]
        static bool Prefix(int numToSpawn, EntityPlayer player)
        {
            if (player is EntityPlayerLocal)
            {
                numToSpawn = -1;

            }
            return true;

        }
    }
}
