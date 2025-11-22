using Cysharp.Threading.Tasks;
using NFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    public class GameplayPopupUI : UIView
    {
        [SerializeField] private TextMeshProUGUI _currentScoreTMP;
        [SerializeField] private Button _settingsBTN;

        private void Awake()
        {
            _settingsBTN.onClick.AddListener(OnSettingsButtonClick);
        }

        private void OnEnable()
        {
            GameManager.OnScoreChanged += GameManager_OnScoreChanged;
        }

        private void OnDisable()
        {
            GameManager.OnScoreChanged -= GameManager_OnScoreChanged;
        }

        private void GameManager_OnScoreChanged(int score)
        {
            _currentScoreTMP.SetText(score.ToString());
        }

        private void OnSettingsButtonClick()
        {
            UIManager.OpenAddressables(UIDefine.SETTINGS_POPUP_UI).Forget();
        }
    }
}
