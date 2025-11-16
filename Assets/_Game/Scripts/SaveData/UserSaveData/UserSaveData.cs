using NFramework;
using UnityEngine;

namespace PlaneRunner
{
    public class UserSaveData : ISaveable
    {
        public int Coin
        {
            get => _coin;
            set
            {
                _coin = value;
                DataChanged = true;
            }
        }

        public int HighScore
        {
            get => _highScore;
            set
            {
                _highScore = value;
                DataChanged = true;
            }
        }

        private UserSaveData _saveData;
        private int _coin;
        private int _highScore;

        #region ISaveable

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
                _saveData = new UserSaveData();
                DataChanged = true;
                Debug.Log("New");
            }
            else
            {
                _saveData = JsonUtility.FromJson<UserSaveData>(data);
                Debug.Log(_saveData.Coin);
            }
        }
        #endregion
    }
}
