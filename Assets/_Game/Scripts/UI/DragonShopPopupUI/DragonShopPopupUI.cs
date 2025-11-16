using Cysharp.Threading.Tasks;
using NFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    public class DragonShopPopupUI : UIView
    {
        [SerializeField] private Button _backBTN;
        [SerializeField] private Button _evolutionBTN;
        [SerializeField] private SkinItemUI[] _skinItems;

        public static event Action OnSkinChanged;

        private void Awake()
        {
            _backBTN.onClick.AddListener(OnBackButtonClick);
        }

        private void OnBackButtonClick()
        {
            CloseSelf();
        }

        public override void OnOpen(UIInputData inputData)
        {
            base.OnOpen(inputData);
            SetData();
        }

        private void SetData()
        {
            SpawnSkinItems();
        }

        private void SpawnSkinItems()
        {
            foreach (var item in _skinItems)
            {
                item.gameObject.SetActive(true);
                item.SetData(UnityEngine.Random.ColorHSV(), () =>
                {
                    OnSkinChanged?.Invoke();
                    UIManager.OpenAddressables(UIDefine.DRAGON_SKIN_DETAIL_POPUP_UI).Forget();
                });
            }
        }
    }
}
