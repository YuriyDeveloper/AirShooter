using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBulletButtonsController : MonoBehaviour
{
    [SerializeField] private MainPlayerBulletLauncher _mainPlayerBulletLauncher;
    [SerializeField] private List<BulletContainer> _mainPlayerBulletContainers;

    public void OnEnable()
    {
        MainPlayerBulletTypeButton.OnActivationBUlletContainer += BulletContainerActivated;
    }

    private void BulletContainerActivated(int containerIndex)
    {
        if (containerIndex == 2)
        {
             _mainPlayerBulletLauncher.LauncherType = LauncherType.MoreOne;
        }
        else
        {
            _mainPlayerBulletLauncher.LauncherType = LauncherType.One;
        }
      
        _mainPlayerBulletLauncher.BulletContainer = _mainPlayerBulletContainers[containerIndex - 1];
        _mainPlayerBulletLauncher.StartLaunch();
    }


}
