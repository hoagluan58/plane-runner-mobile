using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    public class SkinItemUI : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _colorIMG;
        [SerializeField] private GameObject _highlightGo;

        private Action _onClick;

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnEnable()
        {
            DragonShopPopupUI.OnSkinChanged += DragonShopPopupUI_OnSkinChanged;
        }

        private void OnDisable()
        {
            DragonShopPopupUI.OnSkinChanged -= DragonShopPopupUI_OnSkinChanged;
        }

        private void DragonShopPopupUI_OnSkinChanged()
        {
            ShowHighlight(false);
        }

        public void SetData(Color color, Action onClick = null)
        {
            _onClick = onClick;
            _colorIMG.color = color;
        }

        public void ShowHighlight(bool isShow) => _highlightGo.SetActive(isShow);

        private void OnButtonClick()
        {
            _onClick?.Invoke();
            ShowHighlight(true);
        }
    }
}
