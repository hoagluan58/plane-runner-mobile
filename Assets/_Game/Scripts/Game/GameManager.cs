using Cysharp.Threading.Tasks;
using NFramework;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;

namespace PlaneRunner
{
    public class GameManager : SingletonMono<GameManager>
    {
        public static event Action<EGameState> OnGameStateChanged;
        public static event Action<int> OnScoreChanged;

        private const int BASE_SCORE = 10;

        [SerializeField] private float _gameSpeed = 100;

        // Session Data
        [SerializeField, ReadOnly]
        private SessionData _sessionData;

        private Coroutine _countingCoroutine = null;

        public float GameSpeed => _gameSpeed;

        public async void StartGame()
        {
            await SceneLoader.LoadAddressables(Define.SceneName.GAMEPLAY, true, true);
            _gameSpeed = 100;
            _sessionData = new SessionData();
            UIManager.OpenAddressables(UIDefine.GAMEPLAY_POPUP_UI).Forget();
            PlaneController.I.EnableUpdate(true);
            CameraController.I.EnableUpdate(true);
            _countingCoroutine = StartCoroutine(StartCounting());
        }

        public async void Quit()
        {
            UIManager.Close(UIDefine.GAMEPLAY_POPUP_UI);
            await SceneLoader.UnloadAddressables(Define.SceneName.GAMEPLAY);
        }

        public async void Restart()
        {
            UIManager.Close(UIDefine.GAMEPLAY_POPUP_UI);
            await SceneLoader.UnloadAddressables(Define.SceneName.GAMEPLAY);
            StartGame();
        }

        public async void GameOver()
        {
            _gameSpeed = 0;
            CameraController.I._shakeEnabled = false;
            CameraController.I.EnableUpdate(false);

            var saveData = GameData.GetSaveable<UserSaveData>(Define.SaveKey.UserSaveData);
            var score = CalculateScore();
            var resultPopup = await UIManager.OpenAddressables<ResultPopupUI>(UIDefine.RESULT_POPUP_UI);
            var isNewHighScore = saveData.HighScore < score;

            resultPopup.SetData(score, _sessionData.CoinCollected, isNewHighScore);

            if (isNewHighScore)
            {
                saveData.HighScore = score;
            }
            if (_countingCoroutine != null)
            {
                StopCoroutine(_countingCoroutine);
                _countingCoroutine = null;
            }
        }

        public void OnCollectCoin()
        {
            UserSaveData.I.Coin += 1;
            _sessionData.CoinCollected += 1;
        }

        private IEnumerator StartCounting()
        {
            var waitForSeconds = new WaitForSeconds(1f);
            while (true)
            {
                _sessionData.TimeElapsed += 1;
                yield return waitForSeconds;
                CalculateScore();
            }
        }

        private int CalculateScore()
        {
            var score = BASE_SCORE * _sessionData.TimeElapsed;
            _sessionData.Score = score;
            OnScoreChanged?.Invoke(score);
            return score;
        }
    }

    public enum EGameState
    {
        None = 0,
        Playing,
        Pause,
        Lose,
    }

    [System.Serializable]
    public class SessionData
    {
        public int CoinCollected = 0;
        public int TimeElapsed = 0;
        public int Score = 0;
    }
}
