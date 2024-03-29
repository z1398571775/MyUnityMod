using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Text;
using static BlockPlacement;

namespace _7DaysToDieMod.Patch
{
    [HarmonyPatch(typeof(EffectManager), nameof(EffectManager.GetValue))]

    internal class EffectManagerPatch
    {
        [HarmonyPostfix]
        static void Postfix(PassiveEffects _passiveEffect, EntityAlive _entity, Recipe _recipe, ref float __result)
        {

            if (_entity != null)
            {
                //Melon<MyMod>.Logger.Msg($"name:{_entity.name}");
                EntityPlayer _player = LocalPlayerApi.getLocalplayer();
                if (_player != null && _player.name.Equals(_entity.name))
                {
                    //生命最大值
                    //if (_passiveEffect.Equals(PassiveEffects.HealthMax))
                    //{
                    //    __result = 1000;

                    //}

                    //实体破坏
                    //if (_passiveEffect.Equals(PassiveEffects.EntityDamage))
                    //{
                    //    __result = __result * 10;

                    //}

                    //穿透
                    if (_passiveEffect.Equals(PassiveEffects.EntityPenetrationCount))
                    {
                        __result = __result * 10;

                    }

                    //奔跑速度
                    //if (_passiveEffect.Equals(PassiveEffects.RunSpeed))
                    //{
                    //    __result = __result * 1.5f;

                    //}

                    //制作时间
                    if (_passiveEffect.Equals(PassiveEffects.CraftingTime))
                    {
                        __result = 0.1f;

                    }

                    //制作时间
                    if (_passiveEffect.Equals(PassiveEffects.CraftingSmeltTime))
                    {
                        __result = 0.1f;

                    }

                    //回复
                    //if (_passiveEffect.Equals(PassiveEffects.EntityHeal))
                    //{
                    //    __result = __result * 1000;

                    //}
                    //战利品掉落概率
                    //if (_passiveEffect.Equals(PassiveEffects.LootDropProb))
                    //{
                    //    __result = 100;

                    //}

                    //战利品概率
                    //if (_passiveEffect.Equals(PassiveEffects.LootProb))
                    //{
                    //    __result = 100;

                    //}

                    //战利品掉落数量
                    //if (_passiveEffect.Equals(PassiveEffects.LootQuantity))
                    //{
                    //    __result = 2000;

                    //}

                    //插槽
                    //if (_passiveEffect.Equals(PassiveEffects.CraftingSlots))
                    //{
                    //    __result = 9999;

                    //}

                    //制作等级
                    if (_passiveEffect.Equals(PassiveEffects.CraftingTier))
                    {
                        __result = 6;

                    }

                    //制作成分数量
                    if (_passiveEffect.Equals(PassiveEffects.CraftingIngredientCount))
                    {
                        __result = 1;

                    }

                    //掠夺等级
                    //if (_passiveEffect.Equals(PassiveEffects.LootTier))
                    //{
                    //    __result = 999;

                    //}

                    //技能等级
                    //if (_passiveEffect.Equals(PassiveEffects.SkillLevel))
                    //{
                    //    __result = 999;

                    //}

                    //拾荒等级
                    //if (_passiveEffect.Equals(PassiveEffects.ScavengingTier))
                    //{
                    //    __result = 999;

                    //}

                    //拾荒物品数量
                    //if (_passiveEffect.Equals(PassiveEffects.ScavengingItemCount))
                    //{
                    //    __result = 200;

                    //}

                    //收获数量
                    //if (_passiveEffect.Equals(PassiveEffects.HarvestCount))
                    //{
                    //    __result = 999;

                    //}


                    //收获数量
                    //if (_passiveEffect.Equals(PassiveEffects.BagSize))
                    //{
                    //    __result = 100;

                    //}
                }

            }

        }
    }
}
