using Cysharp.Threading.Tasks;
using NFramework;
using UnityEngine;

namespace PlaneRunner
{
    public class BootManager : MonoBehaviour
    {
        private void Start()
        {
            Initialize().Forget();
        }

        private async UniTaskVoid Initialize()
        {
            await UniTask.Yield();

            Application.targetFrameRate = 60;
            Input.multiTouchEnabled = false;

            RegisterSaveData();

            await AddressablesManager.Initialize();
            await SoundManager.Initialize();
            await SoundManager.CacheSoundGroupAddressables(SoundDefine.SoundGroupKey.SOUND);
            await SceneLoader.LoadAddressables(Define.SceneName.MAIN, true, true);
        }

        private void RegisterSaveData()
        {
            GameData.RegisterSaveable(UserSaveData.I);
            GameData.RegisterSaveable(SoundManager.I);
            GameData.RegisterSaveable(VibrationManager.I);
            LocalSaveManager.Load();
        }
    }
}
