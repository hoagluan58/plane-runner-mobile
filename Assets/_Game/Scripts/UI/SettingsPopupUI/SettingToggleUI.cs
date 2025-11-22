using NFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneRunner
{
    [RequireComponent(typeof(Button))]
    public class SettingToggleUI : MonoBehaviour
    {
        [SerializeField] private EToggleType _type = default;
        [SerializeField] private Image _img = default;
        [SerializeField] private Color[] _colorOnOff = default;
        private bool _isOn;
        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(OnButtonClicked);

        private void Start()
        {
            switch (_type)
            {
                case EToggleType.Vibrate:
                    _isOn = VibrationManager.I.Status;
                    break;
                case EToggleType.SFX:
                    _isOn = SoundManager.SfxStatus;
                    break;
                case EToggleType.BGM:
                    _isOn = SoundManager.BgmStatus;
                    break;
            }

            UpdateUI();
        }

        private void OnDisable() => _button.onClick.RemoveListener(OnButtonClicked);

        private void UpdateUI() => _img.color = _isOn ? _colorOnOff[0] : _colorOnOff[1];

        private void OnButtonClicked()
        {
            _isOn = !_isOn;
            UpdateUI();

            switch (_type)
            {
                case EToggleType.Vibrate:
                    VibrationManager.I.Status = _isOn;
                    break;
                case EToggleType.SFX:
                    SoundManager.SfxStatus = _isOn;
                    break;
                case EToggleType.BGM:
                    SoundManager.BgmStatus = _isOn;
                    break;
            }
            VibrationManager.I.Haptic(VibrationManager.EHapticType.LightImpact);
        }
    }

    public enum EToggleType
    {
        Vibrate,
        SFX,
        BGM
    }
}
