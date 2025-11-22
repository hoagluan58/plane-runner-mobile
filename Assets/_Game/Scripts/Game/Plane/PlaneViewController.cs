using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneRunner
{
    public class PlaneViewController : MonoBehaviour
    {
        [SerializeField] private GameObject _container;

        private GameObject _currentView;

        private void OnEnable()
        {
            if (_currentView != null)
            {
                Destroy(_currentView);
            }

            var playerEvolutionLevel = UserSaveData.I.EvolutionLevel;
            var evolutionConfig = ConfigManager.I.EvolutionConfigSO.GetConfig(playerEvolutionLevel);
            _currentView = Instantiate(evolutionConfig.DragonPrefab, _container.transform);
            _currentView.SetActive(true);
        }
    }
}
