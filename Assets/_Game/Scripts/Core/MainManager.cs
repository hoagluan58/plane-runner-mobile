using NFramework;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PlaneRunner
{
    public class MainManager : MonoBehaviour
    {
        private void Start()
        {
            UIManager.OpenAddressables(UIDefine.HOME_MENU_UI).Forget();
        }
    }
}
