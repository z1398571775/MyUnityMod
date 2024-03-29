using System;
using System.Collections.Generic;
using System.Text;

namespace _7DaysToDieMod
{
    internal class GameManagerApi
    {
        private static GameManager _gameManager;
        public static GameManager GetGameManager()
        {
            if(_gameManager == null)
            {
                _gameManager = GameManager.Instance;
            }
            return _gameManager;
        }
    }
}
