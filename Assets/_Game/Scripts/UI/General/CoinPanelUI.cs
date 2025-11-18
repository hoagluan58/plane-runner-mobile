using TMPro;
using UnityEngine;

namespace PlaneRunner
{
    public class CoinPanelUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _amountTMP;

        private void OnEnable()
        {
            UpdateCoinAmount();
            UserSaveData.OnCoinChanged += UpdateCoinAmount;
        }

        private void OnDisable()
        {
            UserSaveData.OnCoinChanged -= UpdateCoinAmount;
        }

        private void UpdateCoinAmount()
        {
            var userData = GameData.GetSaveable<UserSaveData>(Define.SaveKey.UserSaveData);
            _amountTMP.SetText(userData.Coin.ToString());
        }
    }
}
