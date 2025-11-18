using NFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlaneRunner
{
    public class SkinConfigSO : GoogleSheetConfigSO<SkinConfigData>
    {
        public SkinConfigData GetConfig(string id) => _datas.Find(x => x.Id == id);

        public List<SkinConfigData> GetConfigs() => _datas;

        protected override void OnSynced(List<SkinConfigData> googleSheetData)
        {
            base.OnSynced(googleSheetData);

            foreach (var data in googleSheetData)
            {
                data.Material = FileHelper.LoadFirstAssetWithName<Material>(data.MaterialName);
            }
        }
    }

    [System.Serializable]
    public class SkinConfigData
    {
        public string Id;
        public int CoinRequirement;
        public Material Material;

        [HideInInspector]
        public string MaterialName;
    }
}
