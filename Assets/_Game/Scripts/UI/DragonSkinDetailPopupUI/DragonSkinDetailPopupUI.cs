using NFramework;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    public class DragonSkinDetailPopupUI : UIView
    {
        [SerializeField] private Button _closeBTN;

        private void Awake()
        {
            _closeBTN.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            CloseSelf();
        }
    }
}
