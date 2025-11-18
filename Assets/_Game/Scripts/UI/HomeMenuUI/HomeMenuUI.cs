using Cysharp.Threading.Tasks;
using NFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    public class HomeMenuUI : UIView
    {
        [SerializeField] private Button _settingsBTN;
        [SerializeField] private Button _dragonBTN;
        [SerializeField] private Button _flyBTN;
        [SerializeField] private TextMeshProUGUI _highScoreTMP;

        private void Awake()
        {
            _settingsBTN.onClick.AddListener(OnSettingsButtonClick);
            _dragonBTN.onClick.AddListener(OnDragonButtonClick);
            _flyBTN.onClick.AddListener(OnFlyButtonClick);
        }

        private void OnFlyButtonClick()
        {
            CloseSelf();
            GameManager.I.StartGame();
        }

        private void OnDragonButtonClick()
        {
            UIManager.OpenAddressables(UIDefine.DRAGON_SHOP_POPUP_UI).Forget();
        }

        private void OnSettingsButtonClick()
        {

        }

        public override void OnOpen(UIInputData inputData)
        {
            base.OnOpen(inputData);
            UpdateScore();
        }

        private void UpdateScore()
        {
            _highScoreTMP.SetText(GameData.GetSaveable<UserSaveData>(Define.SaveKey.UserSaveData).HighScore.ToString());
        }
    }
}
