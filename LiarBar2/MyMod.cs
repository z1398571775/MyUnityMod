using MelonLoader;
using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;
using System.Numerics;

namespace LiarBar2
{
    public class MyMod : MelonMod

    {
        private PlayerStats _playerStats;
        private CharController _charController;
        private readonly float _acceleration = 10f;
        private readonly float _deceleration = 100f;
        private readonly float _bodySpeed = 5f;
        private UnityEngine.Vector3 _headSpeed;
        private UnityEngine.Vector3 _initHeadPosition;
        private UnityEngine.Vector3 _initBodyPosition;
        private UnityEngine.Quaternion _initBodyRotation;
        private bool _isControllable = false;
        private bool _showControlStatus = true;
        private bool _showKeyHints = true;
        public RouletteGamePlay rouletteGamePlay;


        public override void OnInitializeMelon()
        {
            HarmonyLib.Harmony.CreateAndPatchAll(typeof(CharMoveablePatch), nameof(CharMoveablePatch));
            LoggerInstance.Msg("开始!!!!!!!!!!!!!!!");
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {

                Manager instance = Manager.Instance;
                List<PlayerStats> playerList = instance.Players;
                playerList.ForEach(player =>
                {
                    player.NetworkHealth = 6;
                    player.NetworkDead = false;
                    LoggerInstance.Msg("当前玩家:" + player.PlayerName + ",ID号为:" + player.Player_Id + ",网络名称为:" + player.NetworkPlayerName);

                });

                //RouletteGameManager rouletteGameManager =  instance.RouletteGame;
                //RouletteGamePlay rouletteGamePlayInstance = FindObjectOfType<RouletteGamePlay>();
                //RouletteGamePlay rouletteGamePlay = UnityEngine.Object.FindObjectOfType<RouletteGamePlay>();
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {

                Manager instance = Manager.Instance;
                List<PlayerStats> playerList = instance.Players;
                playerList.ForEach(player =>
                {
                    player.NetworkHealth = 0;
                    player.NetworkDead = true;
                    LoggerInstance.Msg("当前玩家:" + player.PlayerName + ",ID号为:" + player.Player_Id + ",网络名称为:" + player.NetworkPlayerName);

                });

            }
        }
    }
}
