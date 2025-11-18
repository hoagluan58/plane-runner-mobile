using NFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneRunner
{
    public class UserSaveData : SingletonMono<UserSaveData>, ISaveable
    {
        public static event Action OnCoinChanged;

        [SerializeField] private SaveData _saveData;

        public int Coin
        {
            get => _saveData.Coin;
            set
            {
                _saveData.Coin = value;
                OnCoinChanged?.Invoke();
                DataChanged = true;
            }
        }

        public int HighScore
        {
            get => _saveData.HighScore;
            set
            {
                _saveData.HighScore = value;
                DataChanged = true;
            }
        }

        public int EvolutionLevel
        {
            get => _saveData.EvolutionLevel;
            set
            {
                _saveData.EvolutionLevel = value;
                DataChanged = true;
            }
        }

        public List<string> UnlockedSkins => _saveData.UnlockedSkins;

        public void AddUnlockedSkin(string skinName)
        {
            _saveData.UnlockedSkins.Add(skinName);
            DataChanged = true;
        }

        #region ISaveable

        [System.Serializable]
        public class SaveData
        {
            public int Coin = 0;
            public int HighScore = 0;
            public int EvolutionLevel = 1;
            public List<string> UnlockedSkins = new List<string>();
        }
        public string SaveKey => Define.SaveKey.UserSaveData;

        public bool DataChanged { get; set; }

        public object GetData()
        {
            return _saveData;
        }

        public void OnAllDataLoaded()
        {
        }

        public void SetData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                _saveData = new SaveData();
                DataChanged = true;
            }
            else
            {
                _saveData = JsonUtility.FromJson<SaveData>(data);
            }
        }
        #endregion
    }
}
