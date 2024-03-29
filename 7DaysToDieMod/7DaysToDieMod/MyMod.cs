using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;

namespace _7DaysToDieMod
{
    public class MyMod : MelonMod
    {
        private bool _openReSetPlayerStatus = false;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Mod has been loaded!");
            var harmony = new HarmonyLib.Harmony("com.company.project.product");
            harmony.PatchAll();

        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
            
        }


        public override void OnUpdate()
        {
            
            if (_openReSetPlayerStatus)
            {
                //每帧重置玩家状态
                LocalPlayerApi.setPlayerState();
            }
            

            if(Input.GetKeyUp(KeyCode.H))
            {
                GameManager gameManager = GameManagerApi.GetGameManager();
                if(gameManager != null)
                {
                    World world = gameManager.World;
                    if(world != null)
                    {
                        List<EntityPlayer> entityPlayers = world.GetPlayers();
                        foreach (EntityPlayer player in entityPlayers)
                        {
                            if (player is EntityPlayerLocal)
                            {
                                //player.Progression.SkillPoints = 100;
                                
                                EntityPlayerLocal playerLocal = (EntityPlayerLocal)player;
                                XUi xui = playerLocal.PlayerUI.xui;
                                
                                
                                List<ItemStack> allItemStacks = xui.PlayerInventory.GetAllItemStacks();
                                foreach (ItemStack item in allItemStacks)
                                {
                                    if(item != null)
                                    {
                                        
                                        
                                        ItemValue itemValue = item.itemValue;
                                        if (itemValue != null) { 
                                            ItemClass itemClass =  itemValue.ItemClass;
                                            if (itemClass != null)
                                            {
                                                
                                                if(itemClass.IsLightSource() || itemClass.IsGun())
                                                {

                                                }
                                                else
                                                {
                                                    item.count = itemClass.Stacknumber.Value;
                                                    //itemClass.Stacknumber.Value = int.MaxValue;


                                                }
                                                
                                                
                                                
                                            }
                                            
                                        }
                                    }
                                    
                                    
                                    
                                }

                                //被动技能全满
                                Dictionary<int, ProgressionValue> progressionDict = player.Progression.GetDict();
                                foreach (var item in progressionDict)
                                {
                                    ProgressionValue progressionValue = item.Value;
                                    if(progressionValue != null)
                                    {
                                        progressionValue.Level = progressionValue.ProgressionClass.MaxLevel;
                                    }
                                }

                                //车辆
                                EntityVehicle entityVehicle = xui.vehicle;
                                if (entityVehicle != null)
                                {
                                    entityVehicle.Stats.Health.BaseMax = 99999;
                                    entityVehicle.Stats.Health.Value = 99999;
                                    Vehicle vehicle = entityVehicle.vehicle;
                                    if (vehicle != null)
                                    {
                                        vehicle.AddFuel(99999999);
                                    }
                                    
                                }
                                
                            }
                            
                       
                            

                        }
                    }
                    else
                    {
                        LoggerInstance.Msg("world has not been loaded!");
                    }
                }
                else
                {
                    LoggerInstance.Msg("gameManager has not been loaded!");
                }
            }

            if (Input.GetKeyUp(KeyCode.F8))
            {
                GamePrefs.Set(EnumGamePrefs.CreativeMenuEnabled, !GamePrefs.GetBool(EnumGamePrefs.CreativeMenuEnabled));
                if (_openReSetPlayerStatus == false)
                {
                    _openReSetPlayerStatus = true;
                }
                else
                {
                    _openReSetPlayerStatus = false;
                }
            }
        }

       
    }
}
