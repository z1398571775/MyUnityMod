using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace _7DaysToDieMod
{
    //EffectManager.GetValue
    internal class LocalPlayerApi
    {
        public static EntityPlayer _player;

        /// <summary>
        /// 
        /// 获取本地玩家
        /// </summary>
        /// <returns></returns>
        public static EntityPlayer getLocalplayer()
        {
            try
            {
                if (_player != null)
                {
                    return _player;
                }
                else
                {
                    GameManager gameManager = GameManagerApi.GetGameManager();
                    if (gameManager != null)
                    {

                        World world = gameManager.World;
                        if (world != null)
                        {
                            List<EntityPlayer> entityPlayers = world.GetPlayers();
                            foreach (EntityPlayer player in entityPlayers)
                            {
                                if (player is EntityPlayerLocal)
                                {
                                    
                                    _player = player;

                                }
                            }
                        }
                        else
                        {
                            Melon<MyMod>.Logger.Error("world has not been loaded!");
                        }
                    }
                    else
                    {
                        Melon<MyMod>.Logger.Error("gameManager has not been loaded!");
                    }
                    return _player;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static void setPlayerState()
        {
            if( _player != null )
            {
                //_player.Stamina = 1000;

                if (_player.Health <= 40)
                {
                    _player.Health = _player.GetMaxHealth();
                }

               
                //    _player.Water = 1000;

                //    EntityStats entityStats = _player.Stats;
                //    Stat stat = entityStats.Health;
                //    stat.OriginalMax = 1000;
                //    stat.BaseMax = 1000;

                //Stat foodStat = entityStats.Food;
                //foodStat.Value = 1000;


            }
            else
            {
                getLocalplayer();
            }
        }

        public static void getSkills()
        {
            try
            {
                FieldInfo info = _player.Progression.GetType().GetField("ProgressionValueQuickList", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                if(info != null )
                {
                    List<ProgressionValue> ProgressionValueQuickList = (List<ProgressionValue>)info.GetValue(_player.Progression);
                    if (ProgressionValueQuickList != null)
                    {
                        foreach (ProgressionValue progressionValue in ProgressionValueQuickList)
                        {
                            Melon<MyMod>.Logger.Msg($"name:{progressionValue.Name} \t level:{progressionValue.Level}");
                            progressionValue.Level = 9999;
                        }
                    }
                    else
                    {
                        Melon<MyMod>.Logger.Error("ProgressionValueQuickList is null!");
                    }
                }
                else
                {
                    Melon<MyMod>.Logger.Error("info is null!");
                }
                
            }
            catch(Exception e)
            {
                Melon<MyMod>.Logger.Error(e.Message);
            }
            
        }

        //public static void getBuff()
        //{
        //    StreamWriter sw = new StreamWriter("E:\\c#\\7DaysToDieMod\\Test.txt");
        //    try
        //    {
        //        CaseInsensitiveStringDictionary<BuffClass> Buffs = BuffManager.Buffs;
        //        if (Buffs != null)
        //        {
        //            foreach (var item in Buffs)
        //            {
        //                BuffClass buffClass = item.Value;
        //                sw.WriteLine($"name:{buffClass.Name} \t  Description:{buffClass.Description}");
        //            }

        //            sw.Close();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Melon<MyMod>.Logger.Error(e.Message);
        //    }

        //    List<BuffValue> buffValues = _player.Buffs.ActiveBuffs;
        //    float _buffDuration = 999999;
        //    BuffClass buff = BuffManager.GetBuff("god");
        //    if (buff == null)
        //    {
        //        Melon<MyMod>.Logger.Error("buff is null");
        //    }
        //    for (int i = 0; i < _player.Buffs.ActiveBuffs.Count; i++)
        //    {
        //        BuffValue buffValue = _player.Buffs.ActiveBuffs[i];
        //        if (buffValue.BuffClass.Name == buff.Name)
        //        {
        //            if (_buffDuration >= 0f)
        //            {
        //                buffValue.BuffClass.DurationMax = _buffDuration;
        //            }
        //            switch (buff.StackType)
        //            {
        //                case BuffEffectStackTypes.Ignore:
        //                    if (buffValue.Remove)
        //                    {
        //                        buffValue.Remove = false;
        //                    }
        //                    break;
        //                case BuffEffectStackTypes.Duration:
        //                    {
        //                        float num2 = _buffDuration - buffValue.DurationInSeconds;
        //                        float num3 = buffValue.BuffClass.InitialDurationMax;
        //                        if (_buffDuration >= 0f)
        //                        {
        //                            num3 = _buffDuration;
        //                        }
        //                        if (num2 > num3)
        //                        {
        //                            num3 = num2;
        //                        }
        //                        buffValue.DurationInTicks = 0U;
        //                        buffValue.BuffClass.DurationMax = num3;
        //                        _player.Buffs.FireEvent(MinEventTypes.onSelfBuffStack, buff, _player.Buffs.parent.MinEventContext);
        //                        break;
        //                    }
        //                case BuffEffectStackTypes.Effect:
        //                    {
        //                        BuffValue buffValue2 = buffValue;
        //                        int stackEffectMultiplier = buffValue2.StackEffectMultiplier;
        //                        buffValue2.StackEffectMultiplier = stackEffectMultiplier + 1;
        //                        _player.Buffs.FireEvent(MinEventTypes.onSelfBuffStack, buff, _player.Buffs.parent.MinEventContext);
        //                        break;
        //                    }
        //                case BuffEffectStackTypes.Replace:
        //                    buffValue.DurationInTicks = 0U;
        //                    _player.Buffs.FireEvent(MinEventTypes.onSelfBuffStack, buff, _player.Buffs.parent.MinEventContext);
        //                    break;
        //            }
        //            return;
        //        }
        //        else
        //        {
        //            BuffValue buffValue3 = new BuffValue(buff.Name, -1, buff);
        //            if (_buffDuration >= 0f)
        //            {
        //                buffValue3.BuffClass.DurationMax = _buffDuration;
        //            }
        //            else
        //            {
        //                buffValue3.BuffClass.DurationMax = buffValue3.BuffClass.InitialDurationMax;
        //            }
        //            _player.Buffs.ActiveBuffs.Add(buffValue3);
        //        }
        //    }

        //}
    }
}
