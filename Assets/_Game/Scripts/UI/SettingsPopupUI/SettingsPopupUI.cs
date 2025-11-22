using NFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    public class SettingsPopupUI : UIView
    {
        [SerializeField] private Button _closeBTN;
        [SerializeField] private Button _overlayBTN;

        private void Awake()
        {
            _closeBTN.onClick.AddListener(OnCloseButtonClick);
            _overlayBTN.onClick.AddListener(OnOverlayButtonClick);
        }

        private void OnEnable()
        {
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }

        private void OnCloseButtonClick()
        {
            CloseSelf();
        }

        private void OnOverlayButtonClick()
        {
            CloseSelf();
        }
    }
}
