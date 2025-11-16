using Cysharp.Threading.Tasks;
using NFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    public class HomeMenuUI : UIView
    {
        [SerializeField] private Button _settingsBTN;
        [SerializeField] private Button _dragonBTN;
        [SerializeField] private Button _flyBTN;

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
    }
}
