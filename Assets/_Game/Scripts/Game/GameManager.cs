using Cysharp.Threading.Tasks;
using NFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneRunner
{
    public class GameManager : SingletonMono<GameManager>
    {
        public static event Action<EGameState> OnGameStateChanged;

        [SerializeField] private GameObject _rootGameObject;
        [SerializeField] private GameObject _speedParticleGo;

        [SerializeField] private float _gameSpeed = 100;

        public float GameSpeed => _gameSpeed;

        private void Start()
        {
            UIManager.OpenAddressables(UIDefine.HOME_MENU_UI).Forget();
        }

        public void StartGame()
        {
            _rootGameObject.SetActive(true);
            PlaneController.I.EnableUpdate(true);
        }

        public void Quit()
        {
        }

        public void Restart()
        {

        }

        public async void GameOver()
        {
            _gameSpeed = 0;
            _speedParticleGo.SetActive(false);
            CameraController.I.m_ShakeEnabled = false;
            var resultPopup = await UIManager.OpenAddressables<ResultPopupUI>(UIDefine.RESULT_POPUP_UI);
            resultPopup.SetData(100, 1000, false);
        }

    }

    public enum EGameState
    {
        None = 0,
        Playing,
        Pause,
        Lose,
    }
}
