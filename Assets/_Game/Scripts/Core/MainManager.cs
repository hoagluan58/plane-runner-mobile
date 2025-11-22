using Cysharp.Threading.Tasks;
using NFramework;
using UnityEngine;

namespace PlaneRunner
{
    public class MainManager : MonoBehaviour
    {
        private void Start()
        {
            UIManager.OpenAddressables(UIDefine.HOME_MENU_UI).Forget();
            SoundManager.PlayBgm(SoundDefine.SoundEntryKey.BGM);
        }
    }
}
