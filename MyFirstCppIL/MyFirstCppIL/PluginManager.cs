using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using UnityEngine;
using Il2Cpp;
using MelonLoader;
using static MelonLoader.MelonLogger;
using Il2CppInterop.Runtime;

namespace MyFirstCppIL
{
    internal class PluginManager : MonoBehaviour
    {
        public static PluginManager instance;
        public PluginManager(IntPtr ptr) : base(ptr)
        {
            instance = this;
        }

        internal static GameObject Create(string name)
        {
            var gameObject = new GameObject(name);
            DontDestroyOnLoad(gameObject);

            // Create mono component at runtime
            var component = new PluginManager(gameObject.AddComponent(Il2CppType.Of<PluginManager>()).Pointer);

            // 解除 Event 绑定
            //SceneManager.sceneLoaded -= Il2cppModTemplate.Instance.LoadAction;
            return gameObject;
        }


        private void Update()
        {
            //Melon<MyMod>.Logger.Msg("OnUpdate");
            if (Input.GetKeyUp(KeyCode.T))
            {
                Melon<MyMod>.Logger.Msg("T");
                TestText.getText();
            }
        }
        
        
    }
}
