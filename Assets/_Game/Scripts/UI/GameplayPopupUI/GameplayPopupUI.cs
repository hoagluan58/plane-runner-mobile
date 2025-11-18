using NFramework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PlaneRunner
{
    public class GameplayPopupUI : UIView
    {
        [SerializeField] private TextMeshProUGUI _currentScoreTMP;

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
    }
}
