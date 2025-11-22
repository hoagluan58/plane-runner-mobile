using NFramework;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    public class ButtonClickSFX : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            if (_button == null) return;
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            SoundManager.PlaySfx(SoundDefine.SoundEntryKey.SFX_BUTTON_CLICK);
        }
    }
}
