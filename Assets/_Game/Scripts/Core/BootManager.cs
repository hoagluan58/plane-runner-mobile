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
            await SceneLoader.LoadAddressables(Define.SceneName.GAME, true, true);
        }

        private void RegisterSaveData()
        {
            GameData.RegisterSaveable(new UserSaveData());
            LocalSaveManager.Load();
        }
    }
}
