using NFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneRunner
{
    public class ConfigManager : SingletonMono<ConfigManager>
    {
        [SerializeField] private EvolutionConfigSO _evolutionConfigSO;
        [SerializeField] private SkinConfigSO _skinConfigSO;

        public EvolutionConfigSO EvolutionConfigSO => _evolutionConfigSO;
        public SkinConfigSO SkinConfigSO => _skinConfigSO;
    }
}
