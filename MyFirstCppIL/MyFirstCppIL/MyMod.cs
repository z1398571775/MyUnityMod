using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using static MelonLoader.MelonLogger;

namespace MyFirstCppIL
{
    public class MyMod : MelonMod

    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
            try
            {
                // PluginManager 是我们新创建的类
                ClassInjector.RegisterTypeInIl2Cpp<PluginManager>();
            }
            catch
            {
                LoggerInstance.Error("FAILED to Register Il2Cpp Type!");
            }
            
            try
            {
                var harmony = new HarmonyLib.Harmony("123123");

                #region 方法一：通过hook函数来延迟创建
                var originalHandle = AccessTools.Method(typeof(CanvasScaler), "Handle");
                var postHandle = AccessTools.Method(typeof(BootstrapPatch), "Handle");
                harmony.Patch(originalHandle, postfix: new HarmonyMethod(postHandle));
                #endregion

                var originalHandle1 = AccessTools.Method(typeof(TestText), "getText");
                var postHandle1 = AccessTools.Method(typeof(BootstrapPatch), "TestText");
                harmony.Patch(originalHandle1, prefix: new HarmonyMethod(postHandle1));
            }
            catch
            {
                LoggerInstance.Error("FAILED to Apply Hooks's!");
            }
            
            
        }

       

        class BootstrapPatch
        {
            [HarmonyPostfix]
            static void Handle()
            {
                // 检查并创建 PluginManager
                if (PluginManager.instance == null)
                {
                    Melon<MyMod>.Logger.Msg("Bootstrapping Trainer...");
                    try
                    {
                        PluginManager.Create("PluginManager");
                        if (PluginManager.instance != null)
                        {
                            Melon<MyMod>.Logger.Msg("Trainer Bootstrapped!");
                        }
                    }
                    catch (Exception e)
                    {
                        Melon<MyMod>.Logger.Error($"ERROR Bootstrapping Trainer: {e.Message}");
                    }
                }
            }

            [HarmonyPrefix]
            static void TestText(ref string __result)
            {

                Melon<MyMod>.Logger.Msg("success Hook Method!");
                // 检查并创建 PluginManager
                __result = "Hoook Success!!!!!!!!!!!";
            }
        }
       
    }
}
