using NFramework;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneRunner
{
    public class EvolutionConfigSO : GoogleSheetConfigSO<EvolutionConfigData>
    {
        public EvolutionConfigData GetConfig(int level) => _datas.Find(x => x.Level == level);

        public List<EvolutionConfigData> GetConfigs() => _datas;
    }

    [System.Serializable]
    public class EvolutionConfigData
    {
        public int Level;
        public int CoinRequirement;
        public int ScoreMultiplier;
        public GameObject DragonPrefab;
    }
}
