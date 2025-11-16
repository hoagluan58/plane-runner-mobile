using Cysharp.Threading.Tasks;
using NFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    public class ResultPopupUI : UIView
    {
        [SerializeField] private Button _homeBTN;
        [SerializeField] private Button _restartBTN;
        [SerializeField] private GameObject _highscoreGO;
        [SerializeField] private TextMeshProUGUI _scoreTMP;
        [SerializeField] private TextMeshProUGUI _coinTMP;


        private void Awake()
        {
            _homeBTN.onClick.AddListener(OnHomeButtonClick);
            _restartBTN.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            CloseSelf();
            GameManager.I.Restart();
        }

        private void OnHomeButtonClick()
        {
            CloseSelf();
            UIManager.OpenAddressables(UIDefine.HOME_MENU_UI).Forget();
            GameManager.I.Quit();
        }

        public void SetData(int score, int coin, bool isHighscore)
        {
            _scoreTMP.SetText(score.ToString());
            _coinTMP.SetText(coin.ToString());
            _highscoreGO.SetActive(isHighscore);
        }
    }
}
