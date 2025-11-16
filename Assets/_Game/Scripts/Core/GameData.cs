using NFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneRunner
{
    public static class GameData
    {
        private static Dictionary<string, ISaveable> _saveableDictionary = new Dictionary<string, ISaveable>();

        public static void RegisterSaveable(ISaveable saveable)
        {
            _saveableDictionary.Add(saveable.SaveKey, saveable);
            LocalSaveManager.RegisterSaveData(saveable);
        }

        public static T GetSaveable<T>(string key) where T : class => _saveableDictionary[key] as T;
    }
}
